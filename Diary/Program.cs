namespace Diary;
using System

class Diary
{
    static void Main()
    {
        /*
        string path = @"events.txt";
        File.WriteAllText(path, String.Empty);*/
        Console.WriteLine("1 - přidat, 2 - zobrazit od nejbližších, zobrazit - nejnovější");
        char choice = Console.ReadKey().KeyChar;
        Console.WriteLine();
        switch (choice)
        {
            case '1':
                var cultureInfo = new CultureInfo("de-DE");
                Console.WriteLine("Napiš název události");
                string name = Console.ReadLine();
                Console.WriteLine("Napiš popis události (nepovinné)");
                string descrip = Console.ReadLine();
                Console.WriteLine("Napiš datum a hodinu (rok/mesic/den/hodina)");
                string date = Console.ReadLine();
                
                MainClass.Save();
                break;
            case '2':
                MainClass.Read();
                break;
            case '3':
                break;
        }
    }
}

