namespace Diary;
using Newtonsoft.Json;

class Diary
{
    static void Main()
    {
        TimeOnly time = new TimeOnly(20, 7);
        DateOnly date = new DateOnly(2018, 7, 24);
        Event eve = new Event("Cotije", "Super legrace", date, time);
        
        Console.WriteLine(eve.Date);

        string json = $"{{Name: {eve.Name}, Description: {eve.Description}, Date: {eve.Date}, Time: {eve.Time}}}";
        
        using (StreamWriter file = File.CreateText(@"events.txt"))
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(file, _data);
        }
    }
}

