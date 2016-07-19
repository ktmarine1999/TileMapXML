using System.Collections.Generic;
using System.Xml.Serialization;

namespace TileMapXML.Layers
{
    /// <summary>
    /// <layer>
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
    /// Can contain: properties, data
    /// </summary>
    public class TMXLayer
    {
        #region attributes
        #endregion
    }//public class TMXLayer
}//namespace TileMapXML.Layers
