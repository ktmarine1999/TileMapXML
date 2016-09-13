using System.Xml.Serialization;

namespace TileMapXML
{
    /// <summary>
    /// <property>
    /// •	name: The name of the property.
    /// •	type: The type of the property.Can be string (default), int, float or bool. (since 0.16)
    /// •	value: The value of the property.
    /// 
    /// Boolean properties have a value of either "true" or "false".
    /// 
    /// When a string property spans contains newlines, 
    /// the current versions of Tiled Java and Tiled Qt will write out the 
    /// value as characters contained inside the property element rather than 
    /// as the value attribute.However, it is at the moment not really possible 
    /// to edit properties consisting of multiple lines with Tiled.
    /// It is possible that a future version of the TMX format will switch to 
    /// always saving property values inside the element rather than as an attribute.
    /// </summary>
    public class TMXProperty
    {
        #region attributes
        /// <summary>
        /// The name of the property
        /// </summary>
        [XmlAttribute()]
        public string name;

        /// <summary>
        /// The type of the property.Can be string (default), int, float or bool. (since 0.16)
        /// </summary>
        [XmlAttribute()]
        public string type = "string";

        /// <summary>
        /// The value of the property
        /// </summary>
        [XmlAttribute()]
        public string value;
        #endregion
    }//public class TMXProperty
}//namespace TileMapXML
