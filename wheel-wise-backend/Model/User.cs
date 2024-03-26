namespace wheel_wise.Model;

public class User
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public int ZipCode { get; set; }

    private IList<Car> _cars;
    private IList<Car> _favoriteAds;

    public IEnumerable<Car> GetCars()
    {
        return _cars;
    }
}