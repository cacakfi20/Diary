namespace Diary;

public class Event
{
    public string Name { get; }
    public string Description { get; }
    public DateOnly Date { get; }
    public TimeOnly Time { get; }
    
    public Event(string name, string description, DateOnly date, TimeOnly time)
    {
        Name = name;
        Description = description;
        Date = date;
        Time = time;
    }
}