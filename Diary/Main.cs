using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Diary;

public class MainClass
{
    
    public static void Save(string name, string descrip, DateTime datum)
    {
        JObject json = new JObject();
        int x = 0;
        string path = @"events.txt";
        var f = new FileInfo(path);
        if (!File.Exists(path))
        {
            File.Create(path).Dispose();
        }
        if (f.Length != 0)
        {
            using (StreamReader r = new StreamReader(@"events.txt"))
            {
                string jsonn = r.ReadToEnd();
                dynamic array = JsonConvert.DeserializeObject(jsonn);
                foreach(var item in array)
                {
                    x++;
                }
            }

            if (x != 0)
            {
                using (StreamReader r = new StreamReader(@"events.txt"))
                {
                    string jsonn = r.ReadToEnd();
                    dynamic array = JsonConvert.DeserializeObject(jsonn);
                    foreach(var item in array)
                    {
                        json.Add(new JProperty(item));
                    }
                }
            }
            File.WriteAllText(path, String.Empty);
        }
        else
        {
            Console.WriteLine("soubor je prázdný");
        }

        //DateTime date = new DateTime(2020, 7, 15, 7, 0, 0);
        Event eve = new Event(x, name, descrip, datum);
        //json.Add(new JProperty(eve.Id.ToString(), eve.Name, eve.Description, eve.Date));
        string result = JsonConvert.SerializeObject(eve);

        File.WriteAllText(@"events.txt", result);

    }

    public static void Read()
    {
        string path = @"events.txt";
        var f = new FileInfo(path);
        List<Event> events = new List<Event>(); 
        if (f.Length != 0)
        {
            using (StreamReader r = new StreamReader(@"events.txt"))
            {
                string json = r.ReadLine();
                dynamic array = JsonConvert.DeserializeObject(json);
                Console.WriteLine(array);
                Event eve = JsonSerializer.Deserialize<Event>(json);
                Console.WriteLine(eve.Id);
                Console.WriteLine(eve.Date);
/*
                foreach(var item in array)
                {
                    foreach (var co in item)
                    {
                        Console.WriteLine("-----------");
                        foreach (var c in co)
                        {
                            Console.WriteLine(c);
                        }
                    }
                }*/
            }
        }
        else
        {
            Console.WriteLine("Nemáte žádné akce");
        }
    }   
}

