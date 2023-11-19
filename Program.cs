// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

ListOfWords list = new ListOfWords();
Practice play = new Practice();

while (true)
{
   
    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
    Console.WriteLine("1.Add a new word(inside, choose which set or create new set).\n2.Practice.\n3.Exit");
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
            Environment.Exit(1);
            break;
    }
 Console.Clear();
}