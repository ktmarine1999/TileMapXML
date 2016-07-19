using System.Collections.Generic;
using System.Xml.Serialization;

namespace TileMapXML.Layers
{
    /// <summary>
    /// <imagelayer>
    /// •	name: The name of the image layer.
    /// •	offsetx: Rendering offset of the image layer in pixels.Defaults to 0. (since 0.15)
    /// •	offsety: Rendering offset of the image layer in pixels.Defaults to 0. (since 0.15)
    /// •	x: The x position of the image layer in pixels. (deprecated since 0.15)
    /// •	y: The y position of the image layer in pixels. (deprecated since 0.15)
    /// •	width: The width of the image layer in tiles.Meaningless.
    /// •	height: The height of the image layer in tiles.Meaningless.
    /// •	opacity: The opacity of the layer as a value from 0 to 1. Defaults to 1.
    /// •	visible: Whether the layer is shown(1) or hidden(0). Defaults to 1.
    /// 
    /// A layer consisting of a single image.
    /// 
    /// Can contain: properties, image
    /// </summary>
    public class TMXImageLayer
    {
        #region attributes
        #endregion
    }//public class TMXImageLayer
}//namespace TileMapXML.Layers
