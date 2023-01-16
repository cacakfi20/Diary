using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Diary;

public class MainClass
{
    public static void Save()
    {
        JObject json = new JObject();
        int x = 0;
        string path = @"events.txt";
        var f = new FileInfo(path);
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
        }/*
        else
        {
            Console.WriteLine("soubor je prázdný");
        }*/

        DateTime date = new DateTime(2020, 7, 15, 7, 0, 0);
        Event eve = new Event(x, "chlae", "xsawd", date);
        json.Add(new JProperty(eve.Id.ToString(), eve.Name, eve.Description, eve.Date));

        File.WriteAllText(@"events.txt", json.ToString());

    }

    public static void Read()
    {
        string path = @"events.txt";
        var f = new FileInfo(path);
        if (f.Length != 0)
        {
            using (StreamReader r = new StreamReader(@"events.txt"))
            {
                string json = r.ReadToEnd();
                dynamic array = JsonConvert.DeserializeObject(json);
                
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
                }
            }
        }
        else
        {
            Console.WriteLine("Nemáte žádné akce");
        }
    }   
}

