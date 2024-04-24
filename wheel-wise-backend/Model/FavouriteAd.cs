namespace wheel_wise.Model;

public class FavouriteAd
{
    public int Id { get; set; }
    public User User { get; set; }
    public int UserId { get; set; }
    public Advertisement Advertisement { get; set; }
    public int AdvertisementId { get; set; }
}