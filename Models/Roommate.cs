namespace Roommates.Models;
public class Roommate
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int RentPortion { get; set; }
    public DateTime MovedInDate { get; set; }
    public int RoomId { get; set; }
    public Room Room { get; set; }

    public List<Chore> Chores { get; set; }
}