using System.Xml.Serialization;

namespace TileMapXML.Tileset
{
    /// <summary>
    /// <frame>
    /// •	tileid: The local ID of a tile within the parent tileset.
    /// •	duration: How long (in milliseconds) this frame should be displayed before advancing to the next frame.
    /// </summary>
    public class TMXFrame
    {
        #region attributes
        /// <summary>
        /// The local ID of a tile within the parent tileset.
        /// </summary>
        [XmlAttribute]
        public int tileid;

        /// <summary>
        /// How long (in milliseconds) this frame should be displayed before advancing to the next frame.
        /// </summary>
        [XmlAttribute]
        public float duration;
        #endregion
    }//public class TMXFrame
}//namespace TileMapXML.Tileset
