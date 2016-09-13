using System.Collections.Generic;
using System.Xml.Serialization;
using TileMapXML.Layers;

namespace TileMapXML.Tileset
{
    /// <summary>
    /// <tile>
    /// •	id: The local tile ID within its tileset.
    /// •	terrain: Defines the terrain type of each corner of the tile, given as comma-separated indexes in the terrain types array in the order top-left, top-right, bottom-left, bottom-right.Leaving out a value means that corner has no terrain. (optional) (since 0.9)
    /// •	probability: A percentage indicating the probability that this tile is chosen when it competes with others while editing with the terrain tool. (optional) (since 0.9)
    /// 
    /// Can contain: properties, image (since 0.9), objectgroup (since 0.10), animation (since 0.10)
    /// </summary>
    public class TMXTilesetTile
    {
        #region attributes
        /// <summary>
        /// The local tile ID within its tileset.
        /// </summary>
        [XmlAttribute]
        public int id;

        /// <summary>
        /// Defines the terrain type of each corner of the tile,
        /// given as comma-separated indexes in the terrain types array
        /// in the order top-left, top-right, bottom-left, bottom-right.
        /// 
        /// Leaving out a value means that corner has no terrain. (optional) (since 0.9)
        /// </summary>
        [XmlAttribute]
        public string terrain;

        /// <summary>
        /// A percentage indicating the probability that this tile is chosen when it competes with others while editing with the terrain tool. (optional) (since 0.9)
        /// </summary>
        [XmlAttribute]
        public float probability;
        #endregion

        /// <summary>
        /// Wraps any number of custom properties.
        /// </summary>
        [XmlArray("properties")]
        [XmlArrayItem("property")]
        public List<TMXProperty> properties;

        /// <summary>
        /// An image contained in this tile
        /// </summary>
        public TMXImage image;

        /// <summary>
        /// Contains a list of objects that this tile can have
        /// </summary>
        public TMXObjectGroup objectgroup;

        /// <summary>
        /// Contains a list of animation frames.
        /// As of Tiled 0.10, each tile can have exactly one animation associated with it.
        /// In the future, there could be support for multiple named animations on a tile.
        /// </summary>
        [XmlElement("animation")]
        public List<TMXAnimation> animation;
    }//public class TMXTilesetTile
}//namespace TileMapXML.Tileset
