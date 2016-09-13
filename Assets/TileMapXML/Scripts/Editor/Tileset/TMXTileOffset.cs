using System.Xml.Serialization;

namespace TileMapXML.Tileset
{
    /// <summary>
    /// <tileoffset>
    /// •	x: Horizontal offset in pixels
    /// •	y: Vertical offset in pixels(positive is down)
    /// 
    /// This element is used to specify an offset in pixels,
    /// to be applied when drawing a tile from the related tileset.
    /// When not present, no offset is applied.
    /// </summary>
    public class TMXTileOffset
    {
        #region attributes
        /// <summary>
        /// Horizontal offset in pixels
        /// </summary>
        [XmlAttribute]
        public float x;

        /// <summary>
        /// Vertical offset in pixels(positive is down)
        /// </summary>
        [XmlAttribute]
        public float y;
        #endregion
    }//public class TMXTileOffset
}//namespace TileMapXML.Tileset
