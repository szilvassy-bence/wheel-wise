namespace wheel_wise.Model;

public class User
{
    public int Id { get; init; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public int ZipCode { get; set; }
}