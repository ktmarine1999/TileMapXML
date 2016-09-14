using System.Collections.Generic;
using System.Xml.Serialization;

namespace TileMapXML.Layers.Objects
{
    /// <summary>
    /// <object>
    /// •	id: Unique ID of the object. Each object that is placed on a map gets a unique id. Even if an object was deleted, no object gets the same ID. Cannot be changed in Tiled Qt. (since Tiled 0.11)
    /// •	name: The name of the object. An arbitrary string.
    /// •	type: The type of the object. An arbitrary string.
    /// •	x: The x coordinate of the object in pixels.
    /// •	y: The y coordinate of the object in pixels.
    /// •	width: The width of the object in pixels(defaults to 0).
    /// •	height: The height of the object in pixels(defaults to 0).
    /// •	rotation: The rotation of the object in degrees clockwise(defaults to 0). (since 0.10)
    /// •	gid: A reference to a tile(optional).
    /// •	visible: Whether the object is shown(1) or hidden(0). Defaults to 1. (since 0.9)
    /// 
    /// While tile layers are very suitable for anything repetitive aligned to the tile grid, 
    /// sometimes you want to annotate your map with other information, 
    /// not necessarily aligned to the grid.
    /// Hence the objects have their coordinates and size in pixels, 
    /// but you can still easily align that to the grid when you want to.
    /// You generally use objects to add custom information to your tile map, 
    /// such as spawn points, warps, exits, etc.
    /// When the object has a gid set, 
    /// then it is represented by the image of the tile with that global ID.
    /// The image alignment currently depends on the map orientation.
    /// In orthogonal orientation it's aligned to the bottom-left 
    /// while in isometric it's aligned to the bottom-center.
    /// 
    /// Can contain: properties, ellipse (since 0.9), polygon, polyline, image
    /// </summary>
    public class TMXObject
    {
        #region attributes
        /// <summary>
        /// Unique ID of the object.
        /// Each object that is placed on a map gets a unique id.
        /// Even if an object was deleted, no object gets the same ID.
        /// Cannot be changed in Tiled Qt. (since Tiled 0.11)
        /// </summary>
        [XmlAttribute]
        public int id;

        /// <summary>
        /// The name of the object. An arbitrary string.
        /// </summary>
        [XmlAttribute]
        public string name;

        /// <summary>
        /// The type of the object. An arbitrary string.
        /// </summary>
        [XmlAttribute]
        public string type;

        /// <summary>
        /// The x coordinate of the object in pixels.
        /// </summary>
        [XmlAttribute]
        public float x;

        /// <summary>
        /// The y coordinate of the object in pixels.
        /// </summary>
        [XmlAttribute]
        public float y;

        /// <summary>
        /// The width of the object in pixels(defaults to 0).
        /// </summary>
        [XmlAttribute]
        public int width = 0;

        /// <summary>
        /// The height of the object in pixels(defaults to 0).
        /// </summary>
        [XmlAttribute]
        public int height = 0;

        /// <summary>
        /// The rotation of the object in degrees clockwise(defaults to 0). (since 0.10)
        /// </summary>
        [XmlAttribute]
        public float rotation = 0;

        /// <summary>
        /// A reference to a tile(optional).
        /// stored as a long(use bitwise to get gid that has been flipped horizontaly or verticaly)
        /// </summary>
        [XmlAttribute]
        public long gid;

        /// <summary>
        /// Whether the object is shown(1) or hidden(0). Defaults to 1. (since 0.9)
        /// </summary>
        [XmlAttribute]
        public int visible = 1;
        #endregion

        /// <summary>
        /// Wraps any number of custom properties.
        /// </summary>
        [XmlArray("properties")]
        [XmlArrayItem("property")]
        public List<TMXProperty> properties;

        /// <summary>
        /// The ellipse data
        /// Will be null unless this object is an ellipse
        /// </summary>
        public TMXEllipse ellipse;

        /// <summary>
        /// The polygon data
        /// Will be null unless this object is a polygon
        /// </summary>
        public TMXpolygon polygon;

        /// <summary>
        /// The polyline data
        /// Will be null unless this object is a polyline
        /// </summary>
        public TMXPolyline polyline;

        /// <summary>
        /// The image data
        /// Will be null unless this object is an image
        /// </summary>
        public Tileset.TMXImage image;
    }//public class TMXObject
}//namespace TileMapXML.Layers.Objects
