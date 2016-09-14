using System.Xml.Serialization;

namespace TileMapXML.Layers
{
    /// <summary>
    /// <tile>
    /// •	gid: The global tile ID.
    /// 
    /// Not to be confused with the tile element inside a tileset, 
    /// this element defines the value of a single tile on a tile layer. 
    /// This is however the most inefficient way of storing the tile layer data, 
    /// and should generally be avoided.
    /// </summary>
    public class TMXLayerTile
    {
        #region attributes
        [XmlAttribute]
        public int gid = -1;
        #endregion
    }//public class TMXLayerTile
}//namespace TileMapXML.Layers
