using System.Collections.Generic;
using System.Xml.Serialization;

namespace TileMapXML.Layers
{
    /// <summary>
    /// <objectgroup>
    /// •	name: The name of the object group.
    /// •	color: The color used to display the objects in this group.
    /// •	x: The x coordinate of the object group in tiles.Defaults to 0 and can no longer be changed in Tiled Qt.
    /// •	y: The y coordinate of the object group in tiles.Defaults to 0 and can no longer be changed in Tiled Qt.
    /// •	width: The width of the object group in tiles.Meaningless.
    /// •	height: The height of the object group in tiles.Meaningless.
    /// •	opacity: The opacity of the layer as a value from 0 to 1. Defaults to 1.
    /// •	visible: Whether the layer is shown (1) or hidden(0). Defaults to 1.
    /// •	offsetx: Rendering offset for this object group in pixels.Defaults to 0. (since 0.14)
    /// •	offsety: Rendering offset for this object group in pixels. Defaults to 0. (since 0.14)
    /// •	draworder: Whether the objects are drawn according to the order of appearance ("index") or sorted by their y-coordinate ("topdown"). Defaults to "topdown".
    /// 
    /// The object group is in fact a map layer, and is hence called "object layer" in Tiled Qt.
    /// 
    /// Can contain: properties, object
    /// </summary>
    public class TMXObjectGroup
    {
        #region attributes
        #endregion
    }//public class TMXObjectGroup
}//namespace TileMapXML.Layers
