namespace wheel_wise.Model.DTO;

public class AdvertisementDTO
{
    public int Id { get; init; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool Highlighted { get; set; }
    
    public int? UserId { get; init; }
    public string UserName { get; init; }
    
    public int CarId { get; init; }
    public Car Car { get; set; }
}