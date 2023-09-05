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


// get all rooms

// get room by id with roomates

// update room 

// delete a room

// get roommates

// get roommate with chores

// add a roommate 

// assign a roommate to a chore

// calculate rent for each roommate and return a report


app.Run();
