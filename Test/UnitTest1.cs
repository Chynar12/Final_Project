namespace Test;

public class Tests
{

    [Test]
    public void PlaceVerticalWord()
    {
        var fileContents = new string[]{
            "new-taze",
        };
        CrossWord crossWord = new CrossWord(fileContents, 3, 3);
        crossWord.PlaceWordVertical("age", 0, 0);
        crossWord.PlaceAllWordsRandomly();
        Assert.AreEqual('_', crossWord.grid[0,2]);
        Assert.AreEqual('_', crossWord.grid[2,0]);
    }

    [Test]
    public void PlaceHorizontalWord()
    {
        var fileContents = new string[]{
            "new-taze",
        };
        CrossWord crossWord = new CrossWord(fileContents, 3, 3);
        crossWord.PlaceWordHorizontal("age", 1, 0);
        crossWord.PlaceAllWordsRandomly();
        Assert.AreEqual('_', crossWord.grid[1,2]);
        Assert.AreEqual('_', crossWord.grid[2,0]);
    }
}