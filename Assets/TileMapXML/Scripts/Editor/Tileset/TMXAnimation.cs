using System.Collections.Generic;
using System.Xml.Serialization;

namespace TileMapXML.Tileset
{
    /// <summary>
    /// <animation>
    /// Contains a list of animation frames.
    /// As of Tiled 0.10, each tile can have exactly one animation associated with it.
    /// In the future, there could be support for multiple named animations on a tile.
    /// 
    /// Can contain: frame
    /// </summary>
    public class TMXAnimation
    {
        #region attributes
        #endregion

        /// <summary>
        /// The frames in the animation
        /// </summary>
        [XmlElement("frame")]
        public List<TMXFrame> frames;
    }//public class TMXAnimation
}//namespace TileMapXML.Tileset
