public class Practice
{
    ListOfWords list = new ListOfWords();
    public void TypeTheCorrectKey()
    {
        Dictionary<string, string> word = new Dictionary<string, string>()
        {
        { "walk", "action done with slowly moving your legs"},
        { "sing", "action that singer does"},
        { "study", "action done night before exam"}
        };

        foreach (KeyValuePair<string, string> k in word)
        {
            Console.WriteLine($"write the word for \"{k.Value}\":");
            string input = Console.ReadLine();
            if (k.Key == input)
            {
                Console.WriteLine("correct");
            }
            else
            {
                Console.WriteLine("wrong answer");
            }
            Console.WriteLine();
        }
        Console.ReadLine();
    }
}
