// REQUIREMENT #1: Class definition

// REQUIREMENT #6 inheritance 
public class Practice : ListOfWords
{
    ListOfWords list = new ListOfWords();
    public void TypeTheCorrectKey()
    {

        Dictionary<string, string> word = new Dictionary<string, string>() { };
        Console.WriteLine("Enter the set you want to practice:");
        string setName = Console.ReadLine();

        if (File.Exists(setName))
        {
            string[] practice = File.ReadAllLines(setName);
            for (int i = 0; i < practice.Length; i++)
            {
                string[] wordsSplited = practice[i].Split("-");
                string word1 = wordsSplited[0];
                string definition = wordsSplited[1];
                word.Add(word1, definition);

            }

            int correctAnswer = 0;
            int wrongAnswer = 0;
            foreach (KeyValuePair<string, string> k in word)
            {
                Console.WriteLine($"write the word for \"{k.Value}\":");
                string input = Console.ReadLine();
                if (k.Key == input)
                {
                    correctAnswer++;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("correct");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    wrongAnswer++;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("wrong answer");
                    Console.ForegroundColor = ConsoleColor.White;
                }

            }
            Console.WriteLine("^^^^^^^^^^^^^^^^^");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Correct answers: {correctAnswer}");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Wrong answers: {wrongAnswer}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }
        else 
        {
            Console.WriteLine($"File \"{setName}\" does not exist. If you would like to create the file type yes?");
            string input = Console.ReadLine();
            if (input == "yes" || input == "Yes");
            {
                list.CreateNewSet();
            }
        }
    }
}
