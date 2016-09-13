using System.Collections.Generic;
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
                Assert.Greater((int)tmx.map.staggeraxis, 0, "staggeraxis can not be none for hexagonal and staggered maps");
                // staggerindex is only for hexagonal and staggered maps
                Assert.Greater((int)tmx.map.staggerindex, 0, "staggerindex can not be none for hexagonal and staggered maps");
                break;
            case TileMapXML.Map.TMXMapOrientation.hexagonal:
                // hexsidelength is only for hexagonal maps
                Assert.Greater(tmx.map.hexsidelength, -1, "failed to load in a hexsidelength");
                // staggeraxis is only for hexagonal and staggered maps
                Assert.Greater((int)tmx.map.staggeraxis, 0, "staggeraxis can not be none for hexagonal and staggered maps");
                // staggerindex is only for hexagonal and staggered maps
                Assert.Greater((int)tmx.map.staggerindex, 0, "staggerindex can not be none for hexagonal and staggered maps");
                break;
            default:
                Assert.Fail("The orientation is not recognized by the system");
                break;
        }
    }//void MapLoaded

    [Test]
    public void TMXMapPropertiesLoaded()
    {
        // If the map contains no properties then this test fails
        if(tmx.map.properties.Count == 0)
        {
            // IF the map has no properties then properties may not have been loaded correctly.
            Assert.Fail("This map contains no properties, if this is intended then ignore this failure.");
        }

        foreach(TMXProperty property in tmx.map.properties)
            TMXPropertyLoaded(property);

        // If you are using properties to set a value in your map that you need for use in Unity
        // add a check here to make sure that it is included in your map

        Assert.Pass("Map contains " + tmx.map.properties.Count + ", if you have more properties they all did not load in");
    }//void TMXMapPropertiesLoaded()

    void TMXPropertyLoaded(TMXProperty property)
    {
        // Make sure that the property has a name
        Assert.IsNotNullOrEmpty(property.name, "Failed to load a name for the property");
        // Make sure that the property has a type
        // Should default to string if the type in the xml attribute was missing
        Assert.IsNotNullOrEmpty(property.type, "Failed to load a type for the property");
        // Make sure that the property has a value
        Assert.IsNotNullOrEmpty(property.value, "Failed to load the value for the property");

        switch(property.type)
        {
            case "int":
                int intValue;
                Assert.True(int.TryParse(property.value, out intValue));
                break;
            case "float":
                float floatValue;
                Assert.True(float.TryParse(property.value, out floatValue));
                break;
            case "bool":
                bool boolValue;
                Assert.True(bool.TryParse(property.value, out boolValue));
                break;
            case "string":
                // A string type should not convet into an int float or bool
                // if it does then the property did not load in corrrctly
                int intString;
                Assert.False(int.TryParse(property.value, out intString),property.name + "=" + property.value + " is an int make sure you set the type correctly");
                float floatString;
                Assert.False(float.TryParse(property.value, out floatString), property.name + "=" + property.value + " is a float make sure you set the type correctly");
                bool boolString;
                Assert.False(bool.TryParse(property.value, out boolString), property.name + "=" + property.value + " is a bool make sure you set the type correctly");
                break;
            default:
                Assert.Fail(property.type + " is not a vaild type");
                break;
        }//void TMXPropertyLoaded(TMXProperty property)
    }
}//public class TMXTest
