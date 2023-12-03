using System.Security.Cryptography;

public class CrossWord
{
    List<string> justWords = new List<string>();
    private Random randNumberRow;
    private Random randNumberColumn;
    private Random randNumberWord;
    private int rowIndexRandom;
    private int columnIndexRandom;
    public int randomNumberForChoosingTheWord;
    public string word;
    public char[,] grid;


    public CrossWord(string fileName)
    {
        randNumberRow = new Random();
        rowIndexRandom = randNumberRow.Next(0, 10);
        randNumberColumn = new Random();
        columnIndexRandom = randNumberColumn.Next(0, 10);



        CreateGrid();
        List<string> words = GetWordsForCrossWord(fileName);
        string oneWord = GetRandomWordFromList(words);
        PlaceWordHorizontal(oneWord, rowIndexRandom, columnIndexRandom);
        PrintGrid();
        Console.ReadLine();
    }


    public char[,] CreateGrid()
    {

        int row = 15;
        int column = 15;
        char[,] grid = new char[row, column];
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {
                grid[i, j] = 'a';
            }
        }
        return grid;
    }



    public void PlaceWordHorizontal(string input, int rowIndexRandom, int columnIndexRandom)
    {
        int row = 15;
        int column = 15;
        if (input.Length + columnIndexRandom > row)
        {
            int outside = column - 1 - columnIndexRandom;
            throw new Exception($"\n the word u try to enter is {input}, last column of word is: {input[outside]} last valid column is: {column - 1}");
        }
        else
        {
            try
            {
                for (int i = 0; i < input.Length; i++)
                {
                    grid[rowIndexRandom, columnIndexRandom + i] = input[i];
                }
            }
            catch
            {

            }
        }
    }



    public void PrintGrid()
    {
        int raw = 14;
        int column = 14;
        try
        {
            for (int i = 0; i < raw; i++)
            {

                for (int j = 0; j < column; j++)
                {
                    Console.Write(grid[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        catch
        {

        }
    }


public List<string> GetWordsForCrossWord(string setName)
{

    if (File.Exists(setName))
    {
        string[] listOfWords = File.ReadAllLines(setName);
        for (int i = 0; i < listOfWords.Length; i++)
        {
            string[] wordsSplited = listOfWords[i].Split("-");
            string word1 = wordsSplited[0];
            justWords.Add(word1);
        }
        foreach (string word2 in justWords)
        {
            Console.WriteLine(word2);
        }

    }
    else
    {
        Console.WriteLine("File does not exist!");
    }
    return justWords;
}


public string GetRandomWordFromList(List<string> list)
{
    int numberOfWords = justWords.Count();
    randNumberWord = new Random();
    randomNumberForChoosingTheWord = randNumberWord.Next(1, numberOfWords);
    Console.WriteLine($"the random num for word {randomNumberForChoosingTheWord}");
    Console.WriteLine($"the word chosen {list[randomNumberForChoosingTheWord]}");
    string word = list[randomNumberForChoosingTheWord];
    justWords.Remove(word);
    return word;
}
}
