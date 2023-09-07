using Roommates.Models;

List<Room> rooms = new List<Room>
{
    new Room { Id = 1, MaxOccupancy = 2, Name = "Bedroom 1"},
    new Room { Id = 2, MaxOccupancy = 1, Name = "Bedroom 2" },
    new Room { Id = 3, MaxOccupancy = 3, Name = "Den"},
    new Room { Id = 4, MaxOccupancy = 4, Name = "Basement"}
};

List<Roommate> roommates = new List<Roommate>
{
    new Roommate {Id = 1, FirstName = "Nic", LastName = "Lahde", MovedInDate = new DateTime(2021, 1, 25), RentPortion = 20, RoomId = 2 },
    new Roommate {Id = 1, FirstName = "Alex", LastName = "Bishop", MovedInDate = new DateTime(2021, 2, 15), RentPortion = 15, RoomId = 1 },
    new Roommate {Id = 1, FirstName = "Dan", LastName = "Brady", MovedInDate = new DateTime(2021, 2, 10), RentPortion = 10, RoomId = 3 },
};

List<Chore> chores = new List<Chore>
{
    new Chore {Id = 1, Name = "Take Out Trash", RoommateId = 1 },
    new Chore {Id = 2, Name = "Vacuum", RoommateId = 2 },
    new Chore {Id = 2, Name = "Do Dishes"},
};


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


// get all 
app.MapGet("/rooms", () =>
{
    return rooms;
});

// get room by id with roommates

app.MapGet("/rooms/{roomId}", (int roomId) =>
{
    Room foundRoom = rooms.FirstOrDefault(room => room.Id == roomId);
    if (foundRoom == null)
    {
        return Results.NotFound();
    }

    List<Roommate> foundRoommates = roommates.Where(r => r.RoomId == roomId).ToList();

    foundRoom.Roommates = foundRoommates;

    return Results.Ok(foundRoom);
});

// update room 
app.MapPut("/rooms/{roomId}", (int roomId, Room room) =>
{
    Room roomToChange = rooms.FirstOrDefault((r) => r.Id == roomId);
    //make sure that roomToChange is not null.
    if (roomToChange == null)
    {
        return Results.NotFound();
    }
    // check if roomId is equal to the roomId passed in.
    if (roomId != room.Id)
    {
        return Results.BadRequest();
    }
    // update the properties of the roomToChange with the body of the room we are passing in
    roomToChange.Name = room.Name;
    roomToChange.MaxOccupancy = room.MaxOccupancy;
    return Results.NoContent();
});


// delete a room
app.MapDelete("/rooms/{roomId}", (int roomId) =>
{
    Room foundRoom = rooms.FirstOrDefault(r => r.Id == roomId);
    if (foundRoom == null)
    {
        return Results.NotFound();
    }

    IEnumerable<Roommate> roommies = roommates.Where(r => r.RoomId == roomId);

    foreach (Roommate roommate in roommies)
    {
        roommate.RoomId = null;
    }

    rooms.Remove(foundRoom);

    return Results.NoContent();
});

// get roommates

app.MapGet("/roommates", () =>
{
    return roommates;
});

// get roommate with chores
app.MapGet("/roommates/{id}", (int id) =>
{
    // find roommate
    Roommate foundRoommate = roommates.FirstOrDefault(rm => rm.Id == id);

    if (foundRoommate == null)
    {
        return Results.NotFound();
    }

    // find associated chores
    List<Chore> foundChores = chores.Where(c => c.RoommateId == id).ToList();

    foundRoommate.Chores = foundChores;

    return Results.Ok(foundRoommate);
});

// add a roommate 

// assign a roommate to a chore

// calculate rent for each roommate and return a report


app.Run();
