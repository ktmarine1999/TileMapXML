using System.Xml.Serialization;

namespace TileMapXML.Tileset
{
    /// <summary>
    /// <image>
    /// •	format: Used for embedded images, in combination with a data child element.Valid values are file extensions like png, gif, jpg, bmp, etc. (since 0.9)
    /// •	id: Used by some versions of Tiled Java.Deprecated and unsupported by Tiled Qt.
    /// •	source: The reference to the tileset image file (Tiled supports most common image formats).
    /// •	trans: Defines a specific color that is treated as transparent(example value: "#FF00FF" for magenta). Up until Tiled 0.12, this value is written out without a # but this is planned to change.
    /// •	width: The image width in pixels (optional, used for tile index correction when the image changes)
    /// •	height: The image height in pixels (optional)
    /// 
    /// Can contain: data (since 0.9)
    /// </summary>
    public class TMXImage
    {
        #region attributes
        /// <summary>
        /// The reference to the tileset image file (Tiled supports most common image formats).
        /// </summary>
        [XmlAttribute]
        public string source;

        /// <summary>
        /// Defines a specific color that is treated as transparent(example value: "#FF00FF" for magenta).
        /// Up until Tiled 0.12, this value is written out without a # but this is planned to change.
        /// </summary>
        [XmlAttribute]
        public string trans;

        /// <summary>
        /// The image width in pixels (optional, used for tile index correction when the image changes)
        /// </summary>
        [XmlAttribute]
        public int width;

        /// <summary>
        /// The image height in pixels (optional)
        /// </summary>
        [XmlAttribute]
        public int height;
        #endregion
    }//public class TMXImage
}//namespace TileMapXML.Tileset
