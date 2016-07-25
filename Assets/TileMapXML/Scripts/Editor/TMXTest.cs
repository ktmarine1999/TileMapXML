using NUnit.Framework;
using TileMapXML;

public class TMXTest
{
    /// <summary>
    /// The path to the map file to use for testing
    /// </summary>
    const string TMX_FILE_PATH = @"Assets/TileMapXML/Maps/TestRunnerMap.tmx";

    /// <summary>
    /// The tmx file
    /// public get private set
    /// </summary>
    public TMX tmx { get; private set; }

    /// <summary>
    /// Load the passed in file into tmx
    /// </summary>
    /// <param name="filePath">The path of the file to load</param>
    public void LoadTMXFile(string filePath)
    {
        tmx = new TMX();
        tmx.Load(filePath);
    }//public void LoadTMXFile

    /// <summary>
    /// Runs before every NUnit test, this makes sure that we have a clean environment.
    /// </summary>
    [SetUp]
    public void Init()
    {
        LoadTMXFile(TMX_FILE_PATH);
    }//void Init()

    /// <summary>
    /// Verify that the tmx variable is not null
    /// </summary>
    [Test]
    public void TMXIsNotNull()
    {
        Assert.IsNotNull(tmx, "Failed to load tmx file, " + TMX_FILE_PATH);
    }//void TMXIsNotNull()

    /// <summary>
    /// Verify that the map is not null
    /// </summary>
    [Test]
    public void TMXMapIsNotNull()
    {
        Assert.IsNotNull(tmx.map, "Failed to load map from " + TMX_FILE_PATH);
    }//void TMXMapIsNotNull
}//public class TMXTest
