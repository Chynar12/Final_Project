public class ListOfWords
{
    // List<string> word = new List<string>();
    Dictionary<string, string> word = new Dictionary<string, string>();
    public void AddWordToTheList()
    {
        Console.WriteLine("Enter a new word to add:");
        string newWord = Console.ReadLine();
        Console.WriteLine("Enter a definition:");
        string definition = Console.ReadLine();
        word.Add(newWord, definition);
        Console.WriteLine($"The word you added: {newWord}");
        Console.WriteLine($"The definition for {newWord} is \"{definition}\"");
        Console.ReadKey();
    }

}