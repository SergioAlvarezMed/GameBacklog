namespace GameBacklog.database;

public record Game(string Name, string Status)
{
    public override string ToString()
    {
        return $"{Name} ({Status})";
    }
};