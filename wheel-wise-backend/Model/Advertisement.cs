namespace wheel_wise.Model;

public class Advertisement
{
    //frontend: picture formdata object files, dotnet side: contoller attribute [frombody][fromfile] match with formdata naming
    //creates and stores binary stream 
    public int Id { get; init; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool Highlighted { get; set; }
    
    public int? UserId { get; init; }
    public User User { get; init; }
    
    //public ICollection<User> LikedByUsers { get; set; }
    
    public int CarId { get; init; }
    public Car Car { get; set; }
}