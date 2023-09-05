namespace Roommates.Models;
public class Chore
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? RoommateId { get; set; }
}