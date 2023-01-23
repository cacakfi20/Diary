namespace Diary;
using System.Globalization;

class Diary
{
    static void Main()
    {
        bool menu = true;
        // While loop na menu
        while (menu)
        {
            // Zobrazení dnešních akcí
            Console.Clear();
            Console.WriteLine("-----------------");
            Console.WriteLine("DNEŠNÍ AKCE");
            MainClass.Read_By_Today_Date();
            Console.WriteLine("-----------------");
            
            Console.WriteLine("1 - přidat událost");
            Console.WriteLine("2 - zobrazit od nejbližších");
            Console.WriteLine("3 - zobrazit nejnovější");
            Console.WriteLine("4 - zobrazit zítřejší akce");
            Console.WriteLine("5 - vyhledat podle jména");
            Console.WriteLine("6 - smazat událost");
            Console.WriteLine("7 - ukončit");
            char choice = Console.ReadKey().KeyChar;
            Console.WriteLine();
            switch (choice)
            {
                // Přidání události
                case '1':
                    Console.Clear();
                    bool nameB = false;
                    bool dateB = false;
                    var cultureInfo = new CultureInfo("de-DE");
                    string name = "";
                    // Kontrola názvu eventu (nesmí být prádná)
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
                    // event nemusí mít žádný popis
                    Console.WriteLine("Napiš popis události (nepovinné)");
                    string descrip = Console.ReadLine();
                    Console.Clear();
                    // kontrola datumu (musí se jednat o validní datum)
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
                // Nejbližší události
                case '2':
                    Console.Clear();
                    MainClass.Read_By_Date();
                    break;
                // Nejnovější události (podle přidání)
                case '3':
                    Console.Clear();
                    MainClass.Read_By_Id();
                    break;
                // zítřejší události
                case '4':
                    Console.Clear();
                    MainClass.Read_By_Tomm_Date();
                    break;
                // vyhledávání podle jména události (kontrola až ve funkci)
                case '5':
                    Console.Clear();
                    Console.WriteLine("Jakou událost chceš vyhledat?");
                    string eve = Console.ReadLine();
                    MainClass.Read_By_Name(eve);
                    break;
                // mazání podle id
                case '6':
                    Console.Clear();
                    MainClass.Delete();
                    break;
                // ukončí while loop menu -> ukončí aplikaci
                case '7':
                    menu = false;
                    break;
            }
        }
    }
}

