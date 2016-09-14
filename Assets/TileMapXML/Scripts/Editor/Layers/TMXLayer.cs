using System.Collections.Generic;
using System.Xml.Serialization;

namespace TileMapXML.Layers
{
    /// <summary>
    /// All<tileset> tags shall occur before the first<layer> tag so that parsers may rely on having the tilesets before needing to resolve tiles.
    /// •	name: The name of the layer.
    /// •	x: The x coordinate of the layer in tiles.Defaults to 0 and can no longer be changed in Tiled Qt.
    /// •	y: The y coordinate of the layer in tiles.Defaults to 0 and can no longer be changed in Tiled Qt.
    /// •	width: The width of the layer in tiles.Traditionally required, but as of Tiled Qt always the same as the map width.
    /// •	height: The height of the layer in tiles.Traditionally required, but as of Tiled Qt always the same as the map height.
    /// •	opacity: The opacity of the layer as a value from 0 to 1. Defaults to 1.
    /// •	visible: Whether the layer is shown (1) or hidden(0). Defaults to 1.
    /// •	offsetx: Rendering offset for this layer in pixels.Defaults to 0. (since 0.14)
    /// •	offsety: Rendering offset for this layer in pixels. Defaults to 0. (since 0.14)
    /// 
    /// Can contain: properties
    /// </summary>
    public class TMXLayer
    {
        #region attributes
        /// <summary>
        /// The name of the layer.
        /// </summary>
        [XmlAttribute]
        public string name;

        /// <summary>
        /// The width of the layer in tiles.
        /// Traditionally required, but as of Tiled Qt always the same as the map width.
        /// </summary>
        [XmlAttribute]
        public float width;

        /// <summary>
        /// The height of the layer in tiles.
        /// Traditionally required, but as of Tiled Qt always the same as the map height.
        /// </summary>
        [XmlAttribute]
        public float height;

        /// <summary>
        /// The opacity of the layer as a value from 0 to 1.
        /// Defaults to 1.
        /// </summary>
        [XmlAttribute]
        public float opacity = 1;

        /// <summary>
        /// Whether the layer is shown (1) or hidden(0).
        /// Defaults to 1.
        /// </summary>
        [XmlAttribute]
        public int visible = 1;

        /// <summary>
        /// Rendering offset for this layer in pixels.
        /// Defaults to 0. (since 0.14)
        /// </summary>
        [XmlAttribute]
        public float offsetx = 0;

        /// <summary>
        /// Rendering offset for this layer in pixels.
        /// Defaults to 0. (since 0.14)
        /// </summary>
        [XmlAttribute]
        public float offsety = 0;
        #endregion

        /// <summary>
        /// Wraps any number of custom properties.
        /// </summary>
        [XmlArray("properties")]
        [XmlArrayItem("property")]
        public List<TMXProperty> properties;
    }//public class TMXLayer
}//namespace TileMapXML.Layers
