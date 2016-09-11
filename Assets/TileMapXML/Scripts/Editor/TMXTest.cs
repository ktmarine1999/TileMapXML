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

    [Test]
    public void TMXMapLoaded()
    {
        // Every map has these
        // The version of the map should be 1.0 unless you manually change it
        Assert.AreEqual(1.0f, tmx.map.version);
        // The orientation of the map should not be none
        Assert.AreNotEqual(TileMapXML.Map.TMXMapOrientation.none, tmx.map.orientation, "Failed to load in map orientation");
        // The render-order should not be none
        Assert.AreNotEqual(tmx.map.renderorder, TileMapXML.Map.TMXRenderOrder.none, "Failed to load in render order");
        // The width should be > 0
        Assert.Greater(tmx.map.width, 0, "Failed to load the map width");
        // The height should be > 0
        Assert.Greater(tmx.map.height, 0, "Failed to load the map height");
        // The tilewidth should be > 0
        Assert.Greater(tmx.map.tilewidth, 0, "Failed to load the maps tile width");
        // The tileheight should be > 0
        Assert.Greater(tmx.map.tileheight, 0, "Failed to load the maps tile height");
        // The nextobjectid should be > 0
        Assert.Greater(tmx.map.nextobjectid, 0, "Failed to load the maps next object id");

        // check values based on the maps orientation
        switch(tmx.map.orientation)
        {
            case TileMapXML.Map.TMXMapOrientation.orthogonal:
                // hexsidelength is only for hexagonal maps
                Assert.AreEqual(-1, tmx.map.hexsidelength, "hexsidelength is only for hexagonal maps");
                // staggeraxis is only for hexagonal and staggered maps
                Assert.AreEqual(0, (int)tmx.map.staggeraxis, "staggeraxis is only for hexagonal and staggered maps");
                // staggerindex is only for hexagonal and staggered maps
                Assert.AreEqual(0, (int)tmx.map.staggerindex, "staggerindex is only for hexagonal and staggered maps");
                break;
            case TileMapXML.Map.TMXMapOrientation.isometric:
                // hexsidelength is only for hexagonal maps
                Assert.AreEqual(-1, tmx.map.hexsidelength, "hexsidelength is only for hexagonal maps");
                // staggeraxis is only for hexagonal and staggered maps
                Assert.AreEqual(0, (int)tmx.map.staggeraxis, "staggeraxis is only for hexagonal and staggered maps");
                // staggerindex is only for hexagonal and staggered maps
                Assert.AreEqual(0, (int)tmx.map.staggerindex, "staggerindex is only for hexagonal and staggered maps");
                break;
            case TileMapXML.Map.TMXMapOrientation.staggered:
                // hexsidelength is only for hexagonal maps
                Assert.AreEqual(-1, tmx.map.hexsidelength, "hexsidelength is only for hexagonal maps");
                // staggeraxis is only for hexagonal and staggered maps
                Assert.Greater((int)tmx.map.staggeraxis, 0, "staggeraxis is only for hexagonal and staggered maps");
                // staggerindex is only for hexagonal and staggered maps
                Assert.Greater((int)tmx.map.staggerindex, 0, "staggerindex is only for hexagonal and staggered maps");
                break;
            case TileMapXML.Map.TMXMapOrientation.hexagonal:
                // hexsidelength is only for hexagonal maps
                Assert.Greater(tmx.map.hexsidelength, -1, "failed to load in a hexsidelength");
                // staggeraxis is only for hexagonal and staggered maps
                Assert.Greater((int)tmx.map.staggeraxis, 0, "staggeraxis is only for hexagonal and staggered maps");
                // staggerindex is only for hexagonal and staggered maps
                Assert.Greater((int)tmx.map.staggerindex, 0, "staggerindex is only for hexagonal and staggered maps");
                break;
            default:
                Assert.Fail("The orientation is not recognized by the system");
                break;
        }
    }//void MapLoaded

}//public class TMXTest
