namespace Diary;

public class Event
{
    public int Id { get; }
    public string Name { get; }
    public string Description { get; }
    public DateTime Date { get; }

    public Event(int id, string name, string description, DateTime date)
    {
        Id = id;
        Name = name;
        Description = description;
        Date = date;
    }
}