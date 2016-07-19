using System.Collections.Generic;
using System.Xml.Serialization;

namespace TileMapXML.Tileset
{
    /// <summary>
    /// <tile>
    /// •	id: The local tile ID within its tileset.
    /// •	terrain: Defines the terrain type of each corner of the tile, given as comma-separated indexes in the terrain types array in the order top-left, top-right, bottom-left, bottom-right.Leaving out a value means that corner has no terrain. (optional) (since 0.9)
    /// •	probability: A percentage indicating the probability that this tile is chosen when it competes with others while editing with the terrain tool. (optional) (since 0.9)
    /// 
    /// Can contain: properties, image (since 0.9), objectgroup (since 0.10), animation (since 0.10)
    /// </summary>
    public class TMXTilesetTile
    {
        #region attributes
        #endregion
    }//public class TMXTilesetTile
}//namespace TileMapXML.Tileset
