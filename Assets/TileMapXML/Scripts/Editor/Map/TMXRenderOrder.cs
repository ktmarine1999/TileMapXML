using System.Xml.Serialization;

namespace TileMapXML.Map
{
    /// <summary>
    /// renderorder: The order in which tiles on tile layers are rendered.
    ///         Valid values are right-down(the default), right-up, left-down and left-up.
    ///         In all cases, the map is drawn row-by-row. 
    ///         (since 0.10, but only supported for orthogonal maps at the moment)
    /// </summary>
    [System.Serializable]
    public enum TMXRenderOrder
    {
        none,
        [XmlEnum("right-down")]
        RightDown,
        [XmlEnum("right-up")]
        RightUp,
        [XmlEnum("left-down")]
        LeftDown,
        [XmlEnum("left-up")]
        LeftUp,
    }//enum TMXRenderOrder
}//namespace TileMapXML.Map
