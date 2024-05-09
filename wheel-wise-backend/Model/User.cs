using Microsoft.AspNetCore.Identity;

namespace wheel_wise.Model;

public class User 
{
    public int Id { get; init; }
    
    public IdentityUser IdentityUser { get; set; }
    
    public string Email { get; set; }
    
    public string UserName { get; set; }
    
    public int? ZipCode { get; set; }
    
    
    // one to many relationship
    public ICollection<Advertisement> Advertisements { get; set; }
    
    // many to many relationship
    public ICollection<Advertisement> FavoriteAdvertisements { get; set; }
}