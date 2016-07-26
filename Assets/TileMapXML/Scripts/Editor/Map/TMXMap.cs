using System.Collections.Generic;
using System.Xml.Serialization;
using TileMapXML.Layers;
using TileMapXML.Map;
using TileMapXML.Properties;
using TileMapXML.Tileset;

namespace TileMapXML
{
    /// <summary>
    /// <map>
    /// •	version: The TMX format version, generally 1.0.
    /// •	orientation: Map orientation.
    ///         Tiled supports "orthogonal", "isometric", "staggered" (since 0.9)
    ///         and "hexagonal" (since 0.11).
    /// •	renderorder: The order in which tiles on tile layers are rendered.
    ///         Valid values are right-down(the default), right-up, left-down and left-up.
    ///         In all cases, the map is drawn row-by-row. 
    ///         (since 0.10, but only supported for orthogonal maps at the moment)
    /// •	width: The map width in tiles.
    /// •	height: The map height in tiles.
    /// •	tilewidth: The width of a tile.
    /// •	tileheight: The height of a tile.
    /// •	hexsidelength: Only for hexagonal maps.
    ///         Determines the width or height (depending on the staggered axis)
    ///         of the tile's edge, in pixels.
    /// •	staggeraxis: For staggered and hexagonal maps, 
    ///         determines which axis("x" or "y") is staggered. (since 0.11)
    /// •	staggerindex: For staggered and hexagonal maps,
    ///         determines whether the "even" or "odd" indexes along the staggered axis are shifted. (since 0.11)
    /// •	backgroundcolor: The background color of the map. 
    ///         (since 0.9, optional, may include alpha value since 0.15 in the form #AARRGGBB)
    /// •	nextobjectid: Stores the next available ID for new objects.
    ///         This number is stored to prevent reuse of the same ID after objects have been removed. (since 0.11)
    /// 
    /// The tilewidth and tileheight properties determine the general grid size of the map.
    /// The individual tiles may have different sizes.
    /// Larger tiles will extend at the top and right(anchored to the bottom left).
    /// 
    /// A map contains three different kinds of layers.
    /// Tile layers were once the only type, and are simply called layer, 
    /// object layers have the objectgroup tag and image layers use the imagelayer tag.
    /// The order in which these layers appear is the order in which the layers are rendered by Tiled.
    /// 
    /// Can contain: properties, tileset, layer, objectgroup, imagelayer
    /// </summary>
    [XmlRoot("map")]
    public class TMXMap
    {
        #region Attributes
        /// <summary>
        /// The TMX format version, generally 1.0
        /// </summary>
        [XmlAttribute()]
        public float version = 0;

        /// <summary>
        /// Map orientation. 
        /// Tiled supports "orthogonal", "isometric", "staggered" (since 0.9) and "hexagonal" (since 0.11).
        /// </summary>
        [XmlAttribute()]
        public TMXMapOrientation orientation = TMXMapOrientation.none;

        /// <summary>
        /// The order in which tiles on tile layers are rendered.
        /// Valid values are right-down(the default), right-up, left-down and left-up.
        /// In all cases, the map is drawn row-by-row. (since 0.10, but only supported for orthogonal maps at the moment)
        /// </summary>
        [XmlAttribute()]
        public TMXRenderOrder renderorder = TMXRenderOrder.none;

        /// <summary>
        /// The map width in tiles
        /// </summary>
        [XmlAttribute()]
        public int width = 0;

        /// <summary>
        /// The map height in tiles.
        /// </summary>
        [XmlAttribute()]
        public int height = 0;

        /// <summary>
        /// The width of a tile.
        /// </summary>
        [XmlAttribute()]
        public int tilewidth = 0;

        /// <summary>
        /// The height of a tile.
        /// </summary>
        [XmlAttribute()]
        public int tileheight = 0;

        /// <summary>
        /// Only for hexagonal maps.
        /// Determines the width or height (depending on the staggered axis) of the tile's edge, in pixels.
        /// </summary>
        [XmlAttribute()]
        public int hexsidelength = -1;

        /// <summary>
        /// For staggered and hexagonal maps, determines which axis("x" or "y") is staggered. (since 0.11)
        /// </summary>
        [XmlAttribute()]
        public TMXStaggerAxis staggeraxis = TMXStaggerAxis.none;

        /// <summary>
        /// For staggered and hexagonal maps, determines whether the "even" or "odd" indexes along the staggered axis are shifted. (since 0.11)
        /// </summary>
        [XmlAttribute()]
        public TMXStaggerIndex staggerindex = TMXStaggerIndex.none;

        /// <summary>
        /// The background color of the map. (since 0.9, optional, may include alpha value since 0.15 in the form #AARRGGBB)
        /// </summary>
        [XmlAttribute()]
        public string backgroundcolor = "";// = new Color32(128, 128, 128, 255);

        /// <summary>
        /// Stores the next available ID for new objects. This number is stored to prevent reuse of the same ID after objects have been removed. (since 0.11)
        /// </summary>
        [XmlAttribute()]
        public int nextobjectid = 0;
        #endregion

        /// <summary>
        /// Wraps any number of custom properties.
        /// </summary>
        public TMXProperties properties;

        /// <summary>
        /// The Tilesets that this map contains
        /// </summary>
        [XmlElement("tileset")]
        public List<TMXTileset> tilesets;

        /// <summary>
        /// The Layers on this map
        /// </summary>
        [XmlElement("layer", typeof(TMXLayer))]
        [XmlElement("objectgroup", typeof(TMXLayer))]
        [XmlElement("imagelayer", typeof(TMXLayer))]
        public List<object> layers;
    }//public class TMXMap
}//namespace TileMapXML
