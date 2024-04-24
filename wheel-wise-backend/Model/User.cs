using Microsoft.AspNetCore.Identity;

namespace wheel_wise.Model;

public class User 
{
    public IdentityUser IdentityUser { get; set; }
    public int UserId { get; init; }
    public int ZipCode { get; set; }
    public ICollection<Advertisement> FavoriteAdvertisements { get; set; } = new List<Advertisement>();
}