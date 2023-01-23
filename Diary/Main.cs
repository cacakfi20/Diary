using Newtonsoft.Json;

namespace Diary;

public class MainClass
{
    
    // Funkce na ukládání události
    public static void Save(string name, string descrip, DateTime datum)
    {
        // proměnné potřebné pro kontrolu a práci s listy
        string path = @"events.txt";
        var f = new FileInfo(path);
        List<string> events = new List<string>();
        List<Event> events_event = new List<Event>();
        int last_id = 0;
        // kontrola zda soubor na ukládání existuje
        if (!File.Exists(path))
        {
            File.Create(path).Dispose();
        }
        // kontrola zda není txt soubor prázdný 
        if (f.Length != 0)
        {
            StreamReader sr = new StreamReader(path);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                events.Add(line);
            }
            sr.Close();

            // zjišťování posledního id které bude poté přiděleno nové události
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
        // instance nové události
        Event eve = new Event(last_id, name, descrip, datum);
        events_event.Add(eve);
        string eventiky = JsonConvert.SerializeObject(eve);
        events.Add(eventiky);
        
        // zápis do souboru
        StreamWriter sw = new StreamWriter(path);
        foreach (string js in events)
        {
            sw.WriteLine(js);
        }
        sw.Close();
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Událost byla přidána");
        Console.ResetColor();
        Console.WriteLine("Pro pokračování stiskni enter-->");
        Console.ReadLine();
    }

    // Funkce na čtení od nejbližší události
    public static void Read_By_Date()
    {
        // Proměnné potřebné pro kontrolu a práci s listy
        string path = @"events.txt";
        var f = new FileInfo(path);
        List<string> events = new List<string>();
        List<Event> events_event = new List<Event>();
        // kontrola zda není txt soubor prázdný 
        if (f.Length != 0)
        {
            // čtení ze souboru
            StreamReader sr = new StreamReader(path);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                events.Add(line);
            }
            sr.Close();

            // deserializace na objekty
            foreach (var a in events)
            {
                Event aaa = JsonConvert.DeserializeObject<Event>(a);
                events_event.Add(aaa);
            }
            
            // seřazení podle data události
            events_event = events_event.OrderBy(p => p.Date).ToList();
            
            // výpis událostí
            foreach (var eve in events_event)
            {
                Console.WriteLine(eve.Name);
                Console.WriteLine(eve.Description);
                Console.WriteLine(eve.Date);
                Console.WriteLine("-----------------"); 
            }
        }
        // je možné že bude soubor zcelá prazdný
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Nemáte žádné akce");
            Console.ResetColor();
        }
        Console.WriteLine("Pro pokračování stiskni enter-->");
        Console.ReadLine();
    }   
   
    // Funkce na seřazení události od nejnovějších (podle ID)
    public static void Read_By_Id()
    {
        // Proměnné potřebné pro kontrolu a práci s listy
        string path = @"events.txt";
        var f = new FileInfo(path);
        List<string> events = new List<string>();
        List<Event> events_event = new List<Event>();
        //  Kontrola zda není txt soubor prázdný
        if (f.Length != 0)
        {
            
            // Čtení ze souboru
            StreamReader sr = new StreamReader(path);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                events.Add(line);
            }
            sr.Close();

            //Deserializace na objekty
            foreach (var a in events)
            {
                Event aaa = JsonConvert.DeserializeObject<Event>(a);
                events_event.Add(aaa);
            }
            
            // Seřazení podle ID od největšího po nejmenší
            events_event = events_event.OrderByDescending(p => p.Id).ToList();

            // Výpis událostí
            foreach (var eve in events_event)
            {
                Console.WriteLine(eve.Name);
                Console.WriteLine(eve.Description);
                Console.WriteLine(eve.Date);
                Console.WriteLine("-----------------"); 
            }
        }
        // Možnost že je soubor prázdný
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Nemáte žádné akce");
            Console.ResetColor();
        }
        Console.WriteLine("Pro pokračování stiskni enter-->");
        Console.ReadLine();
    }   
    
    // Funkce na vyhledání události podle jména
    public static void Read_By_Name(string name)
    {
        // Proměnné potřebné pro kontrolu a práci s listy
        string path = @"events.txt";
        var f = new FileInfo(path);
        List<string> events = new List<string>();
        List<Event> events_event = new List<Event>();
        
        // Kontrola zda jmén není prázdné
        if (!string.IsNullOrEmpty(name) && !string.IsNullOrWhiteSpace(name))
        {
            // Kontrola zda není soubor prázdný
            if (f.Length != 0)
            {
                // Čtení ze souboru
                StreamReader sr = new StreamReader(path);
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    events.Add(line);
                }
                sr.Close();

                // Deserializace na objekty
                foreach (var a in events)
                {
                    Event aaa = JsonConvert.DeserializeObject<Event>(a);
                    events_event.Add(aaa);
                }

                // Vypís nalezené události
                int x = 0;
                foreach (var eve in events_event)
                {
                    if (eve.Name == name)
                    {
                        Console.WriteLine(eve.Name);
                        Console.WriteLine(eve.Description);
                        Console.WriteLine(eve.Date);
                        Console.WriteLine("-----------------");
                        x++;
                    }
                }

                // Pokud nebyla událost nalezena
                if (x == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nenašli jsme tuto událost");
                    Console.ResetColor();
                }
            }
            // Možnost že je soubor prázdný
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Nemáte žádné akce");
                Console.ResetColor();
            }
        }
        // Warning za špatně napsané jméno
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Jméno nemůže být prázdné");
            Console.ResetColor();
        }
        Console.WriteLine("Pro pokračování stiskni enter-->");
        Console.ReadLine();
    }

    // Funkce na mazání události
    public static void Delete()
    {
        
        // Proměnné potřebné pro kontrolu a práci s listy
        string path = @"events.txt";
        List<string> events = new List<string>();
        List<string> updated_events = new List<string>();
        List<Event> events_event = new List<Event>();
        StreamReader sr = new StreamReader(path);
        string line;
        int x = 0;

        // Čtení ze souboru
        while ((line = sr.ReadLine()) != null)
        {
            events.Add(line);
        }
        sr.Close();

        // Deserializace na objekty
        foreach (var a in events)
        {
            Event aaa = JsonConvert.DeserializeObject<Event>(a);
            events_event.Add(aaa);
        }
        
        // Výpis událostí i s IDčkama
        foreach (var eve in events_event)
        {
            Console.WriteLine(eve.Id);
            Console.WriteLine(eve.Name);
            Console.WriteLine(eve.Description);
            Console.WriteLine(eve.Date);
            Console.WriteLine("-----------------");
        }
        
        Console.WriteLine("Napiš id události, kterou chceš smazat");
        string id = Console.ReadLine();
        int idd;
        bool isNumeric;
        // Kontrola zda je ID validní
        if (isNumeric = int.TryParse(id, out idd))
        {
            Console.Clear();

            // Vytvářim dva identické listy s objektama, jeden pak změním aby tam nebylo vybrané ID --- 
            List<Event> eventiky = events_event;
            events_event = events_event.Where(a => a.Id != idd).ToList();
            
            // --- pokud jsou stejné idd neexistuje
            if (eventiky.SequenceEqual(events_event))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Událost s ID {idd} neexistuje");
                Console.ResetColor();
            }
            // info o úspěšném smazání
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Událost s ID {idd} byla úspěsně smazána");
                Console.ResetColor();
            }
        
            // Zápis zpět do souboru
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
        // Warning že se nejedná o validní ID
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Nejedná se o validní ID");
            Console.ResetColor();
        }
        Console.WriteLine("Pro pokračování stiskni enter-->");
        Console.ReadLine();
    }
    
    // Funkce na zobrazení zítřejších událostí 
    public static void Read_By_Tomm_Date()
    {
        
        // Proměnné potřebné pro kontrolu a práci s listy
        string path = @"events.txt";
        var f = new FileInfo(path);
        List<string> events = new List<string>();
        List<Event> events_event = new List<Event>();
        // kontrola zda není soubor prázdný 
        if (f.Length != 0)
        {
   
            // Čtení a deserializace na objekty
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

            //Zobrazení událostí se zítřejším datem
            int x = 0;
            foreach (var eve in events_event)
            {
                if (eve.Date == DateTime.Today.AddDays(1))
                {
                    Console.WriteLine(eve.Name);
                    Console.WriteLine(eve.Description);
                    Console.WriteLine(eve.Date);
                    Console.WriteLine("-----------------");
                    x++;
                }
            }

            // Pokud nenajde žádné akce se zítřejším datem
            if (x == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Na zítřek nemáte žádne akce");
                Console.ResetColor();
            }
        }
        // Případ že je soubor prázdný
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Nemáte žádné akce");
            Console.ResetColor();
        }
        Console.WriteLine("Pro pokračování stiskni enter-->");
        Console.ReadLine();
    }
    
    // Funkce na zobrazení dnešních událostí
    public static void Read_By_Today_Date()
    {
        string path = @"events.txt";
        var f = new FileInfo(path);
        List<string> events = new List<string>();
        List<Event> events_event = new List<Event>();
        if (f.Length != 0)
        {

            // Čtení a deserializace na objekty
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

            //Zobrazení událostí s dnešním datem
            int x = 0;
            foreach (var eve in events_event)
            {
                if (eve.Date == DateTime.Today)
                {
                    Console.WriteLine(eve.Name);
                    Console.WriteLine(eve.Description);
                    Console.WriteLine(eve.Date);
                    Console.WriteLine("-----------------");
                    x++;
                }
            }

            // Pokud nenajde žádné akce s dnešním datem
            if (x == 0)
            {
                Console.WriteLine("Na dnešek nemáte žádné akce");
            }
        }
        // Případ že je soubor prázdný
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Nemáte žádné akce");
            Console.ResetColor();
        }
    }
   
}

