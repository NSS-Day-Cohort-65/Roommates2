namespace Roommates.Models;
public class Room
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int MaxOccupancy { get; set; }

    public List<Roommate> Roommates { get; set; }
}