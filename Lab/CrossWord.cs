using System.Data;
using System.Security.Cryptography;
//REQUIREMENT #3: third class definition
public class CrossWord
{
    List<string> justWords = new List<string>();
    private Random randomNumber;
    private Random randNumberWord;
    public int randomNumberForChoosingTheWord;
    public string word;
    public char[,] grid;

    //REQUIREMENT #11 properties 
    public int Row { get; }
    public int Column { get; }


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
            if (i % 2 == 0)
            {
                string oneWord = GetRandomWordFromList();
                var rowIndexRandom = randomNumber.Next(0, Row);
                var columnIndexRandom = randomNumber.Next(0, Column - oneWord.Length);
                PlaceWordHorizontal(oneWord, rowIndexRandom, columnIndexRandom);
            }
            else
            {
                string oneWord = GetRandomWordFromList();
                var rowIndexRandom = randomNumber.Next(0, Row - oneWord.Length);
                var columnIndexRandom = randomNumber.Next(0, Column- oneWord.Length);
                PlaceWordVertical(oneWord, rowIndexRandom, columnIndexRandom);
            }
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

            // REQUIREMENT #9: throwing an exception and properly catching it
            throw new Exception($"\n the word u try to enter is {input}, last column of word is: {outside} last valid column is: {Column - 1}");
            
        }
        else
        {
            for (int i = 0; i < input.Length; i++)
            {
                grid[rowIndexRandom, columnIndexRandom + i] = '_';
            }

        }
    }


    public void PlaceWordVertical(string input, int rowIndexRandom, int columnIndexRandom)
    {
        if (input.Length + rowIndexRandom > Column)
        {
            int outside = Row - 1 - rowIndexRandom;
            throw new Exception($"\n the word u try to enter is {input}, last column of word is: {outside} last valid column is: {Row - 1}");
        }
        else
        {
            for (int i = 0; i < input.Length; i++)
            {
                grid[rowIndexRandom + i, columnIndexRandom] = '_';
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

        return justWords;
    }


    public string GetRandomWordFromList()
    {
        int numberOfWords = justWords.Count();
        randomNumberForChoosingTheWord = randomNumber.Next(0, numberOfWords);
        string word = justWords[randomNumberForChoosingTheWord];
        justWords.Remove(word);
        return word;
    }
    public void CheckTheWords()
    {
        for (int i = 0; i < justWords.Count(); i++)
        {
            Console.WriteLine("Enter the word");
            var check = Console.ReadLine();
            if (justWords.Contains(check))
            {
                Console.WriteLine("Correct!");
            }
            else
            {
                Console.WriteLine("Crossword does not contain that word");
            }
        }
    }
}
