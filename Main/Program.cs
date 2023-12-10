// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

ListOfWords list = new ListOfWords();
Practice play = new Practice();



Console.Clear();

while (true)
{
    VocabularyReminder reminder = new VocabularyReminder();

    // Set the time for the reminder
    DateTime reminderTime = DateTime.Today.AddHours(18).AddMinutes(30);

    // Start the reminder
    reminder.StartReminder(reminderTime);

    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
    Console.WriteLine("1.Add a new word.\n2.Practice.\n3.Crossword.\n4.Exit.");
    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
    Console.WriteLine("Your choice:");
    int choice = Int32.Parse(Console.ReadLine());
    switch (choice)
    {
        case 1:
            list.AddWordToTheList();
            break;
        case 2:
            play.TypeTheCorrectKey();
            break;
        case 3:
            Console.WriteLine("Type the set name you want to make crossword with:");
            string userInput = Console.ReadLine();
            if (File.Exists(userInput))
            {
                string[] words = File.ReadAllLines(userInput);
                CrossWord crossWord = new CrossWord(words);
                crossWord.PlaceAllWordsRandomly();
                crossWord.PrintGrid();
                Console.ReadLine();
                crossWord.CheckTheWords();
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("File does not exist");
            }
            break;
        case 4:
            Environment.Exit(1);
            break;
    }
    Console.Clear();
}