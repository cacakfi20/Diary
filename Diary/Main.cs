using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Diary;

public class MainClass
{
    
    public static void Save(string name, string descrip, DateTime datum)
    { 
        int x = 0;
        string path = @"events.txt";
        var f = new FileInfo(path);
        List<string> events = new List<string>();
        List<Event> events_event = new List<Event>();
        int last_id = 0;
        if (!File.Exists(path))
        {
            File.Create(path).Dispose();
        }
        if (f.Length != 0)
        {
            StreamReader sr = new StreamReader(path);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                events.Add(line);
            }
            sr.Close();

            foreach (var a in events)
            {
                Event aaa = JsonConvert.DeserializeObject<Event>(a);
                events_event.Add(aaa);
                last_id = aaa.Id + 1;
            }
        }
        else
        {
            Console.WriteLine("soubor je prázdný");
        }
        Event eve = new Event(last_id, name, descrip, datum);
        events_event.Add(eve);
        string eventiky = JsonConvert.SerializeObject(eve);
        events.Add(eventiky);
        StreamWriter sw = new StreamWriter(path);
        foreach (string js in events)
        {
            sw.WriteLine(js);
        }
        sw.Close();
    }

    public static void Read_By_Date()
    {
        string path = @"events.txt";
        var f = new FileInfo(path);
        List<string> events = new List<string>();
        List<Event> events_event = new List<Event>();
        if (f.Length != 0)
        {

            StreamReader sr = new StreamReader(path);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                events.Add(line);
            }
            sr.Close();

            foreach (var a in events)
            {
                Event aaa = JsonConvert.DeserializeObject<Event>(a);
                events_event.Add(aaa);
            }

            events_event = events_event.OrderBy(p => p.Date).ToList();
            
            foreach (var eve in events_event)
            {
                Console.WriteLine(eve.Id);
                Console.WriteLine(eve.Name);
                Console.WriteLine(eve.Description);
                Console.WriteLine(eve.Date);
                Console.WriteLine("-----------"); 
            }
        }
        else
        {
            Console.WriteLine("Nemáte žádné akce");
        }
    }   
    public static void Read_By_Id()
    {
        string path = @"events.txt";
        var f = new FileInfo(path);
        List<string> events = new List<string>();
        List<Event> events_event = new List<Event>();
        if (f.Length != 0)
        {

            StreamReader sr = new StreamReader(path);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                events.Add(line);
            }
            sr.Close();

            foreach (var a in events)
            {
                Event aaa = JsonConvert.DeserializeObject<Event>(a);
                events_event.Add(aaa);
            }

            events_event = events_event.OrderByDescending(p => p.Id).ToList();
            
            foreach (var eve in events_event)
            {
                Console.WriteLine(eve.Id);
                Console.WriteLine(eve.Name);
                Console.WriteLine(eve.Description);
                Console.WriteLine(eve.Date);
                Console.WriteLine("-----------"); 
            }
        }
        else
        {
            Console.WriteLine("Nemáte žádné akce");
        }
    }   
    public static void Read_By_Name(string name)
    {
        string path = @"events.txt";
        var f = new FileInfo(path);
        List<string> events = new List<string>();
        List<Event> events_event = new List<Event>();
        if (f.Length != 0)
        {

            StreamReader sr = new StreamReader(path);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                events.Add(line);
            }
            sr.Close();

            foreach (var a in events)
            {
                Event aaa = JsonConvert.DeserializeObject<Event>(a);
                events_event.Add(aaa);
            }

            int x = 0;
            foreach (var eve in events_event)
            {
                if (eve.Name == name)
                {
                    Console.WriteLine(eve.Id);
                    Console.WriteLine(eve.Name);
                    Console.WriteLine(eve.Description);
                    Console.WriteLine(eve.Date);
                    Console.WriteLine("-----------");
                    x++;
                }
            }

            if (x == 0)
            {
                Console.WriteLine("Nenašli jsme tuto událost");
            }
        }
        else
        {
            Console.WriteLine("Nemáte žádné akce");
        }
    }

    public static void Delete(int id)
    {
        string path = @"events.txt";
        List<string> events = new List<string>();
        List<string> updated_events = new List<string>();
        List<Event> events_event = new List<Event>();
        StreamReader sr = new StreamReader(path);
        string line;
        
        while ((line = sr.ReadLine()) != null)
        {
            events.Add(line);
        }
        sr.Close();

        foreach (var a in events)
        {
            Event aaa = JsonConvert.DeserializeObject<Event>(a);
            events_event.Add(aaa);
        }
        
        events_event = events_event.Where(a => a.Id != id).ToList();
        
        foreach (var eve in events_event)
        {
            string ev = JsonConvert.SerializeObject(eve);
            updated_events.Add(ev);
        }
        StreamWriter sw = new StreamWriter(path);

        foreach (string js in updated_events)
        {
            sw.WriteLine(js);
        }
        sw.Close();
    }
}

