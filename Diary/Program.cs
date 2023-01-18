namespace Diary;
using System.Globalization;

class Diary
{
    static void Main()
    {
        /*
        string path = @"events.txt";
        File.WriteAllText(path, String.Empty);*/
        bool menu = true;
        while (menu)
        {
            Console.WriteLine("1 - přidat událost");
            Console.WriteLine("2 - zobrazit od nejbližších");
            Console.WriteLine("3 - zobrazit nejnovější");
            Console.WriteLine("4 - vyhledat podle jména");
            Console.WriteLine("5 - smazat událost");
            char choice = Console.ReadKey().KeyChar;
            Console.WriteLine();
            switch (choice)
            {
                case '1':
                    Console.Clear();
                    bool nameB = false;
                    bool dateB = false;
                    var cultureInfo = new CultureInfo("de-DE");
                    string name = "";
                    while (!nameB)
                    {
                        Console.WriteLine("Napiš název události");
                        name = Console.ReadLine();
                        if (!string.IsNullOrEmpty(name) && !string.IsNullOrWhiteSpace(name))
                        {
                            nameB = true;
                        }
                    }
                    Console.Clear();
                    Console.WriteLine("Napiš popis události (nepovinné)");
                    string descrip = Console.ReadLine();
                    Console.Clear();
                    DateTime datee = DateTime.Now;
                    while (!dateB)
                    {
                        Console.WriteLine("Napiš datum (den mesic rok)");
                        string date = Console.ReadLine();
                        try
                        {
                            datee = DateTime.Parse(date, cultureInfo, DateTimeStyles.NoCurrentDateDefault);
                            dateB = true;
                        }
                        catch
                        {
                            Console.WriteLine("Zkontrolujte zda ste napsli datum správně (den měsíc rok)");
                        }
                    }
                    Console.Clear();
                    MainClass.Save(name, descrip, datee);
                    break;
                case '2':
                    Console.Clear();
                    MainClass.Read_By_Date();
                    break;
                case '3':
                    Console.Clear();
                    MainClass.Read_By_Id();
                    break;
                case '4':
                    Console.Clear();
                    Console.WriteLine("Jakou událost chceš vyhledat?");
                    string eve = Console.ReadLine();
                    MainClass.Read_By_Name(eve);
                    break;
                case '5':
                    Console.Clear();
                    Console.WriteLine("Napiš id události, kterou chceš smazat");
                    string id = Console.ReadLine();
                    int idd = int.Parse(id);
                    MainClass.Delete(idd);
                    break;
            }
        }
    }
}

