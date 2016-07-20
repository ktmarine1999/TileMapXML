using System.Xml.Serialization;
using System.IO;

namespace TileMapXML
{
    /// <summary>
    /// Loads in a map created in Tiled using xml serialization.
    /// Stores the map in a variable called map
    /// </summary>
    public class TMX
    {
        /// <summary>
        /// The tmx map
        /// </summary>
        public TMXMap map;

        /// <summary>
        /// Loads A TMX file from xml using serialization
        /// </summary>
        /// <param name="tmxFilePath">The path of the file to load</param>
        public void Load(string tmxFilePath)
        {
            // Load the map from the xml file at tmxFilePath
            XmlSerializer serializer = new XmlSerializer(typeof(TMXMap));
            using(FileStream stream = new FileStream(tmxFilePath, FileMode.Open))
                map = serializer.Deserialize(stream) as TMXMap;
        }//public void Load
    }//public class TMX
}//namespace TileMapXML
