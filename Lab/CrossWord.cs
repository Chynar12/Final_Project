using System.Data;
using System.Security.Cryptography;

public class CrossWord
{
    List<string> justWords = new List<string>();
    private Random randomNumber;
    private Random randNumberWord;
    public int randomNumberForChoosingTheWord;
    public string word;
    public char[,] grid;

    public int Row {get; }
    public int Column{get; }


    public CrossWord(string[] words, int row = 15, int column = 15)
    {
        Row = row;
        Column = column;
        randomNumber = new Random();

        CreateGrid();
        GetWordsForCrossWord(words);

    }


    public void PlaceAllWordsRandomly()
    {
        var counter = justWords.Count();
        for (int i = 0; i < counter; i++)
        {
            var rowIndexRandom = randomNumber.Next(0, 10);
            var columnIndexRandom = randomNumber.Next(0, 10);
            string oneWord = GetRandomWordFromList();
            PlaceWordHorizontal(oneWord, rowIndexRandom, columnIndexRandom);
        }
    }

    public char[,] CreateGrid()
    {
        grid = new char[Row, Column];
        for (int i = 0; i < Row; i++)
        {
            for (int j = 0; j < Column; j++)
            {
                grid[i, j] = ' ';
            }
        }
        return grid;
    }



    public void PlaceWordHorizontal(string input, int rowIndexRandom, int columnIndexRandom)
    {
        if (input.Length + columnIndexRandom > Row)
        {
            int outside = Column - 1 - columnIndexRandom;
            throw new Exception($"\n the word u try to enter is {input}, last column of word is: {input[outside]} last valid column is: {Column - 1}");
        }
        else
        {
            for (int i = 0; i < input.Length; i++)
            {
                grid[rowIndexRandom, columnIndexRandom + i] = input[i];
            }

        }
    }



    public void PrintGrid()
    {
        if (grid == null)
        {
            throw new NullReferenceException("cannot print grid. grid is null");
        }
        for (int i = 0; i < Row; i++)
        {

            for (int j = 0; j < Column; j++)
            {
                Console.Write(grid[i, j] + " ");
            }
            Console.WriteLine();
        }

    }


    public List<string> GetWordsForCrossWord(string[] listOfWords)
    {
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

        return justWords;
    }


    public string GetRandomWordFromList()
    {
        int numberOfWords = justWords.Count();
        randomNumberForChoosingTheWord = randomNumber.Next(0, numberOfWords);
        Console.WriteLine($"the random num for word {randomNumberForChoosingTheWord}");
        Console.WriteLine($"the word chosen {justWords[randomNumberForChoosingTheWord]}");
        string word = justWords[randomNumberForChoosingTheWord];
        justWords.Remove(word);
        return word;
    }
}
