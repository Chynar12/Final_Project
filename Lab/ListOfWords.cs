using System.Security.Cryptography.X509Certificates;

public class ListOfWords
{

    Dictionary<string, string> word = new Dictionary<string, string>();
    public void AddWordToTheList()
    {
        Console.WriteLine("Would you like to create a new set or use existing one?");
        Console.WriteLine("1.Create new set");
        Console.WriteLine("2.Use existing set");
        int choice = Int32.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                CreateNewSet();
                break;
            case 2:
                UseExistingSet();
                break;
            case 3:
                Environment.Exit(1);
                break;
        }
    }

    public void CreateNewSet()
    {
        Console.WriteLine("Enter a name for your set:");
        string setName = Console.ReadLine();

        Console.WriteLine("Enter a new word to add:");
        string newWord = Console.ReadLine();

        Console.WriteLine("Enter a definition:");
        string definition = Console.ReadLine();

        word.Add(newWord, definition);
        string[] wordsToSavetoTheFile = new string[] { $"{newWord}-{definition}" };

        File.AppendAllLines(setName, wordsToSavetoTheFile);
        Console.WriteLine($"The word you added: {newWord}");
        Console.WriteLine($"The definition for {newWord} is \"{definition}\"");
        Console.ReadKey();
    }

    public void UseExistingSet()
    {
        Console.WriteLine("Enter a set name to use:");
        string setName = Console.ReadLine();

        if (File.Exists(setName))
        {
            Console.WriteLine("Enter a new word to add:");
            string newWord = Console.ReadLine();

            Console.WriteLine("Enter a definition:");
            string definition = Console.ReadLine();

            word.Add(newWord, definition);
            string[] wordsToSavetoTheFile = new string[] { $"{newWord}-{definition}" };

            File.AppendAllLines(setName, wordsToSavetoTheFile);
            Console.WriteLine($"The word you added: {newWord}");
            Console.WriteLine($"The definition for {newWord} is \"{definition}\"");
            Console.ReadKey();
        }
        else 
        {
            Console.WriteLine($"File \"{setName}\" does not exist!");
            Console.ReadLine();
        }
    }

}