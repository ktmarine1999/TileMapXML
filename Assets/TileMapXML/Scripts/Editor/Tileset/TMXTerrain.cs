using System.Xml.Serialization;

namespace TileMapXML.Tileset
{
    /// <summary>
    /// <terrain>
    /// •	name: The name of the terrain type.
    /// •	tile: The local tile-id of the tile that represents the terrain visually.
    /// 
    /// Can contain: properties
    /// </summary>
    public class TMXTerrain
    {
        #region attributes
        [XmlAttribute]
        public string name;

        [XmlAttribute]
        public int tile;
        #endregion
    }//public class TMXTerrain
}//namespace TileMapXML.Tileset
