using Microsoft.AspNetCore.Identity;

namespace wheel_wise.Model;

public class User 
{
    public IdentityUser IdentityUser { get; set; }
    public int Id { get; init; }
    public int ZipCode { get; set; }
    public ICollection<FavouriteAd> FavoriteAdvertisements { get; set; } = new List<FavouriteAd>();
}