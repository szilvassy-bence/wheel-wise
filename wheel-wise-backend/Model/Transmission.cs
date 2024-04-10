namespace wheel_wise.Model;

public class Transmission
{
    public int Id { get; init; }
    public string Name { get; set; }

    public override string ToString()
    {
        return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}";
    }
}