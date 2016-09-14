using System;
using System.Collections.Generic;
using NUnit.Framework;
using TileMapXML;
using TileMapXML.Layers;
using TileMapXML.Layers.Objects;
using TileMapXML.Tileset;

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

    #region Basic Test
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
    #endregion

    #region Map Loaded Test
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
    #endregion

    #region Properties Loaded Test
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
            case "color":
                break;
            case "file":
                break;
            case "string":
                // A string type should not convet into an int float or bool
                // if it does then the property did not load in corrrctly
                int intString;
                Assert.False(int.TryParse(property.value, out intString), property.name + "=" + property.value + " is an int make sure you set the type correctly");
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
    #endregion

    #region Tileset Loaded
    [Test]
    public void TMXTilesetsLoaded()
    {
        // If there are no tilesets then fail
        if(tmx.map.tilesets.Count < 1)
            Assert.Fail("Map must contain at least one tileset");

        int firstGID = 1;
        // Loop through all of the tile sets and make sure that they loaded correctly
        foreach(TMXTileset tileset in tmx.map.tilesets)
        {
            // The first gid should be >= firstGID
            Assert.GreaterOrEqual(tileset.firstgid, firstGID, "First Gid must be >= " + firstGID);
            // External Tilesets is not suported
            Assert.IsNullOrEmpty(tileset.source, "External tilesets are not supported");
            // The name sould not be null or empty
            Assert.IsNotNullOrEmpty(tileset.name, "name not loaded");
            // The tile width should be > 0
            Assert.Greater(tileset.tilewidth, 0, "tilewidth not loaded");
            // The width of the tile should be >= the map.tilewidth
            Assert.GreaterOrEqual(tileset.tilewidth, tmx.map.tilewidth, "The width of a tile must be >= the maps tilewidth");
            // The tile height should be > 0
            Assert.Greater(tileset.tileheight, 0, "tileheight not loaded");
            // The height of the tile should be >= the map.tileheight
            Assert.GreaterOrEqual(tileset.tileheight, tmx.map.tileheight, "The height of a tile must be >= the maps tileheight");
            // The tile count should be > 0
            Assert.Greater(tileset.tilecount, 0, "tilecount not loaded");
            firstGID += tileset.tilecount;
            // The columns should be > 0
            Assert.Greater(tileset.columns, 0, "columns not loaded");
        }//foreach(TMXTileset tileset in tmx.map.tilesets)
    }//void TMXTilesetsLoaded()

    [Test]
    public void TMXTilesetsPropertiesLoaded()
    {
        foreach(TMXTileset tileset in tmx.map.tilesets)
        {
            // If you are using properties to set a value in your tileset that you need for use in Unity
            // add a check here to make sure that it is included in your tileset

            foreach(TMXProperty property in tileset.properties)
            {
                TMXPropertyLoaded(property);
            }//foreach(TMXProperty property in tileset.properties)
        }//foreach(TMXTileset tileset in tmx.map.tilesets)
    }//void TMXTilesetsPropertiesLoaded()

    [Test]
    public void TMXTilesetsTileoffsetLoaded()
    {
        foreach(TMXTileset tileset in tmx.map.tilesets)
        {
            // If the tile set has a tile offset
            if(tileset.tileoffset != null)
            {
                Assert.NotNull(tileset.tileoffset.x);
                Assert.NotNull(tileset.tileoffset.y);
            }
        }//foreach(TMXTileset tileset in tmx.map.tilesets)
    }//void TMXTilesetsTileoffsetLoaded()

    #region Tileset Image Loaded
    [Test]
    public void TMXTilesetsImageLoaded()
    {
        foreach(TMXTileset tileset in tmx.map.tilesets)
        {
            TMXImageLoaded(tileset.image);
        }//foreach(TMXTileset tileset in tmx.map.tilesets)
    }//void TMXTilesetsImageLoaded()

    void TMXImageLoaded(TMXImage image)
    {
        // There is a source
        Assert.IsNotNullOrEmpty(image.source, "Needs a source in order to display");
        // The width and height loaded in
        Assert.Greater(image.width, 0, "width not loaded");
        Assert.Greater(image.height, 0, "height not loaded");
    }
    #endregion

    #region Tileset Tile Loaded
    [Test]
    public void TMXTilesetsTilesLoaded()
    {
        foreach(TMXTileset tileset in tmx.map.tilesets)
        {
            foreach(TMXTilesetTile tile in tileset.tiles)
            {
                // The id is the only thing that we need to make sure we have
                // it must be > 0
                Assert.Greater(tile.id, 0, "id failed to load");
            }//foreach(TMXTilesetTile tile in tileset.tiles)
        }//foreach(TMXTileset tileset in tmx.map.tilesets)
    }//void TMXTilesetsTilesLoaded()

    [Test]
    public void TMXTilesetsTilesPropertiesLoaded()
    {
        foreach(TMXTileset tileset in tmx.map.tilesets)
        {
            foreach(TMXTilesetTile tile in tileset.tiles)
            {
                // If you are using properties to set a value in your tileset that you need for use in Unity
                // add a check here to make sure that it is included in your tileset

                foreach(TMXProperty property in tile.properties)
                {
                    TMXPropertyLoaded(property);
                }//foreach(TMXProperty property in tile.properties)
            }//foreach(TMXTilesetTile tile in tileset.tiles)
        }//foreach(TMXTileset tileset in tmx.map.tilesets)
    }//void TMXTilesetsTilesPropertiesLoaded()

    [Test]
    public void TMXTilesetsTilesAnimationsLoaded()
    {
        foreach(TMXTileset tileset in tmx.map.tilesets)
        {
            foreach(TMXTilesetTile tile in tileset.tiles)
            {
                foreach(TMXAnimation animation in tile.animation)
                {
                    foreach(TMXFrame frame in animation.frames)
                    {
                        // The tile Id must be > 0
                        Assert.Greater(frame.tileid, 0, "tileid failed to load");
                        // The duration must not be null
                        Assert.IsNotNull(frame.duration, "duration failed to load");
                    }//foreach(TMXFrame frame in animation.frames)
                }//foreach(TMXAnimation animation in tile.animation)
            }//foreach(TMXTilesetTile tile in tileset.tiles)
        }//foreach(TMXTileset tileset in tmx.map.tilesets)
    }//void TMXTilesetsTilesAnimationsLoaded()
    #endregion
    #endregion

    #region Layer Loaded
    [Test]
    public void TMXLayersLoaded()
    {
        bool hasTileLayer = false;

        foreach(var layer in tmx.map.layers)
        {
            if(layer is TMXObjectGroup)
                TMXObjectGroupLoaded(layer as TMXObjectGroup);

            else if(layer is TMXImageLayer)
                TMXImageLayerLoaded(layer as TMXImageLayer);
            else if(layer is TMXLayer)
            {
                hasTileLayer = true;
                TMXTileLayerLoaded(layer as TMXLayer);
            }//else if(layer is TMXLayer)
        }//foreach(var layer in tmx.map.layers)

        //There must be at least one layer
        Assert.True((tmx.map.layers.Count > 0) && (hasTileLayer), "There needs to be at least on tile layer");
    }//void TMXLayersLoaded()

    [Test]
    public void TMXLayersPropertiesLoaded()
    {
        //foreach(TMXLayer layer in tmx.map.layers)
        //{
        //    // If you are using properties to set a value in your tile layer that you need for use in Unity
        //    // add a check here to make sure that it is included in your tileset

        //    foreach(TMXProperty property in layer.properties)
        //    {
        //        TMXPropertyLoaded(property);
        //    }//foreach(TMXProperty property in layer.properties)
        //}//foreach(TMXLayer layer in tmx.map.layers)
    }//void TMXTilesetsPropertiesLoaded()

    #region Tile Layer Loaded
    public void TMXTileLayerLoaded(TMXLayer layer)
    {
        //Name of the layer must not be null
        Assert.IsNotNullOrEmpty(layer.name, "Layer must have a name");
        //The data is loaded correctly
        TMXLayerDataLoaded(layer.data);
    }//void TMXTileLayerLoaded(TMXLayer layer)

    #region TMXLayerData Loaded
    public void TMXLayerDataLoaded(TMXData data)
    {
        // The encoding and compression must be null
        Assert.IsNullOrEmpty(data.encoding, "Invalid encoding used must be XML");
        Assert.IsNullOrEmpty(data.compression, "Invalid compresseion used must be uncompressed");

        foreach(TMXLayerTile tile in data.tiles)
        {
            TMXLayerTileLoaded(tile);
        }//foreach(TMXLayerTile tile in data.tiles)
    }//void TMXLayerDataLoaded(TMXData data)

    #region TMXLayerTile Loaded
    public void TMXLayerTileLoaded(TMXLayerTile tile)
    {
        //The gid should be > -1
        Assert.Greater(tile.gid, -1, "gid not loaded correctly");
    }//void TMXLayerTileLoaded(TMXLayerTile tile)
    #endregion
    #endregion
    #endregion

    #region Object Group Loaded
    private void TMXObjectGroupLoaded(TMXObjectGroup objectgroup)
    {
        //Name of the objectGroup must not be null
        Assert.IsNotNullOrEmpty(objectgroup.name, "objectgroup must have a name");

        foreach(TMXObject tmxObject in objectgroup.objects)
        {
            // check the object loaded correctly
            TMXObjectLoaded(tmxObject);
        }//foreach(TMXObject tmxObject in objectGroup.objects)
    }//void TMXObjectGroupLoaded(TMXObjectGroup objectGroup)

    #region TMXObject Loaded
    void TMXObjectLoaded(TMXObject tmxObject)
    {
        // The id must be a valid id
        Assert.Greater(tmxObject.id, 0, "id not loaded");

        // if this object is an elipse
        if(tmxObject.ellipse != null)
        {
            // it must have a width and a height
            Assert.Greater(tmxObject.width, 0, "width not loaded");
            Assert.Greater(tmxObject.height, 0, "height not loaded");
        }//object is an elipse
         // else if this object is a polygon
        else if(tmxObject.polygon != null)
        {
            // check the points string is valid
            TMXObjectPointsLoaded(tmxObject.polygon.points);
        }//object is a polygon
         // else if this object is a polyline
        else if(tmxObject.polyline != null)
        {
            // check the points string is valid
            TMXObjectPointsLoaded(tmxObject.polyline.points);
        }//object is a polyline
         // else if this object is an image
        else if(tmxObject.image != null)
        {
            // it must have a valid gid
            Assert.Greater(tmxObject.gid, 0);
            // it must have a width and a height
            Assert.Greater(tmxObject.width, 0, "width not loaded");
            Assert.Greater(tmxObject.height, 0, "height not loaded");
            // make sure the image is vaild
            TMXImageLoaded(tmxObject.image);
        }//object is an image
         // else this object is a rectangle
        else
        {
            // it must have a width and a height
            Assert.Greater(tmxObject.width, 0, "width not loaded");
            Assert.Greater(tmxObject.height, 0, "height not loaded");
        }//object is a rectangle
    }//void TMXObjectLoaded(TMXObject tmxObject)

    void TMXObjectPointsLoaded(string pointsList)
    {
        // seperate the points into pairs of x,y coordinates
        string[] points = pointsList.Split(' ');

        // loop trhough the points array
        foreach(string point in points)
        {
            // seprate the x and y coordinates
            // x=coord[0], y=coord[1]
            string[] coord = point.Split(',');
            // floats to store the x and y coords
            float x, y;
            // make sure the x coord can be parased
            Assert.True(float.TryParse(coord[0], out x), "x coord is invalid");
            // make sure the y coord can be parased
            Assert.True(float.TryParse(coord[1], out y), "y coord is invalid");
        }//foreach(string point in points)
    }//TMXObjectPointsLoaded(string pointsList)

    [Test]
    public void TMXObjectGroupsObjectsPropertiesLoaded()
    {
        // loop through all of the layers on the map
        foreach(var layer in tmx.map.layers)
        {
            // if the layer is an objectgroup
            if(layer is TMXObjectGroup)
            {
                // get a reference  to the layer as an objectgroup
                TMXObjectGroup objectgroup = layer as TMXObjectGroup;
                foreach(TMXObject tmxObject in objectgroup.objects)
                {
                    // check the properties are valid
                    foreach(TMXProperty property in tmxObject.properties)
                    {
                        //check the property is valid
                        TMXPropertyLoaded(property);
                    }//foreach(TMXProperty property in tmxObject.properties)
                }//foreach(TMXObject tmxObject in objectGroup.objects)
            }//if(layer is TMXObjectGroup)
        }//foreach(var layer in tmx.map.layers)
    }//void TMXObjectGroupsObjectsPropertiesLoaded()
    #endregion
    #endregion

    #region Image Layer Loaded
    private void TMXImageLayerLoaded(TMXImageLayer imageLayer)
    {

    }//void TMXImageLayerLoaded(TMXImageLayer imageLayer)
    #endregion
    #endregion
}//public class TMXTest
