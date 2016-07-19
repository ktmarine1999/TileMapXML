using System.Collections.Generic;
using System.Xml.Serialization;

namespace TileMapXML.Layers.Objects
{
    /// <summary>
    /// <polyline>
    /// •	points: A list of x, y coordinates in pixels.
    /// 
    /// A polyline follows the same placement definition as a polygon object.
    /// Each polyline object is made up of a space-delimited list of x, y coordinates.
    /// The origin for these coordinates is the location of the parent object. 
    /// By default, the first point is created as 0,0 denoting that the point will 
    /// originate exactly where the object is placed.
    /// </summary>
    public class TMXPolyline
    {
        #region attributes
        #endregion
    }//public class TMXPolyline
}//namespace TileMapXML.Layers.Objects
