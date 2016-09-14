﻿using System.Collections.Generic;
using System.Xml.Serialization;

namespace TileMapXML.Layers
{
    /// <summary>
    /// <data>
    /// •	encoding: The encoding used to encode the tile layer data.
    ///               When used, it can be "base64" and "csv" at the moment.
    /// •	compression: The compression used to compress the tile layer data.
    ///                  Tiled Qt supports "gzip" and "zlib".
    /// 
    /// When no encoding or compression is given, the tiles are stored as individual XML tile elements.
    /// Next to that, the easiest format to parse is the "csv" (comma separated values) format.
    /// The base64-encoded and optionally compressed layer data is somewhat more complicated to parse.
    /// First you need to base64-decode it, then you may need to decompress it.
    /// Now you have an array of bytes, which should be interpreted as an array of unsigned 32-bit integers using little-endian byte ordering.
    /// Whatever format you choose for your layer data, you will always end up with so called "global tile IDs" (gids).
    /// They are global, since they may refer to a tile from any of the tilesets used by the map.
    /// In order to find out from which tileset the tile is you need to find the tileset with the highest firstgid that is still lower or equal than the gid.
    /// The tilesets are always stored with increasing firstgids.
    /// 
    /// Can contain: tile
    /// </summary>
    public class TMXData
    {
        #region attributes
        /// <summary>
        /// The encoding used to encode the tile layer data.
        /// When used, it can be "base64" and "csv" at the moment.
        /// Must be null or empty for use in unity
        /// </summary>
        public string encoding;

        /// <summary>
        /// The compression used to compress the tile layer data.
        /// Tiled Qt supports "gzip" and "zlib".
        /// Must be null or empty for use in unity
        /// </summary>
        public string compression;
        #endregion

        /// <summary>
        /// List of tiles on a tile layer.
        /// </summary>
        [XmlElement("tile")]
        public List<TMXLayerTile> tiles;
    }//public class TMXData
}//namespace TileMapXML.Layers
