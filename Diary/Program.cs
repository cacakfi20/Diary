namespace Diary;


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
                MainClass.Save();
                break;
            case '2':
                MainClass.Read();
                break;
            case '3':
                break;
        }
        MainClass.Save();
    }
}

