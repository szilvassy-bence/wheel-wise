using Microsoft.AspNetCore.Identity;

namespace wheel_wise.Model;

public class User 
{
    public IdentityUser IdentityUser { get; set; }
    public int Id { get; init; }
    public int ZipCode { get; set; }
    
    // one to many relationship
    public ICollection<Advertisement> Advertisements { get; set; }
    
    // many to many relationship
    public ICollection<Advertisement> FavoriteAdvertisements { get; set; }
}