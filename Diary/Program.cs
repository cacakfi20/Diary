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
            Console.WriteLine("1 - přidat, 2 - zobrazit od nejbližších, zobrazit - nejnovější");
            char choice = Console.ReadKey().KeyChar;
            Console.WriteLine();
            switch (choice)
            {
                case '1':
                    var cultureInfo = new CultureInfo("de-DE");
                    Console.WriteLine("Napiš název události");
                    string name = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("Napiš popis události (nepovinné)");
                    string descrip = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("Napiš datum (den mesic rok)");
                    string date = Console.ReadLine();
                    Console.Clear();
                    DateTime datee = DateTime.Parse(date, cultureInfo, DateTimeStyles.NoCurrentDateDefault);
                    MainClass.Save(name, descrip, datee);
                    break;
                case '2':
                    MainClass.Read();
                    break;
                case '3':
                    break;
            }
        }
    }
}

