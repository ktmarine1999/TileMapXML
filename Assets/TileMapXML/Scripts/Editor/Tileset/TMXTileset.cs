using System.Collections.Generic;
using System.Xml.Serialization;

namespace TileMapXML.Tileset
{
    /// <summary>
    /// <tileset>
    /// •	firstgid: The first global tile ID of this tileset (this global ID maps to the first tile in this tileset).
    /// •	source: If this tileset is stored in an external TSX (Tile Set XML) file, this attribute refers to that file. That TSX file has the same structure as the <tileset> element described here. (There is the firstgid attribute missing and this source attribute is also not there. These two attributes are kept in the TMX map, since they are map specific.)
    /// •	name: The name of this tileset.
    /// •	tilewidth: The (maximum) width of the tiles in this tileset.
    /// •	tileheight: The (maximum) height of the tiles in this tileset.
    /// •	spacing: The spacing in pixels between the tiles in this tileset (applies to the tileset image).
    /// •	margin: The margin around the tiles in this tileset (applies to the tileset image).
    /// •	tilecount: The number of tiles in this tileset (since 0.13)
    /// •	columns: The number of tile columns in the tileset. For image collection tilesets it is editable and is used when displaying the tileset. (since 0.15)
    /// 
    /// If there are multiple <tileset> elements, they are in ascending order of their firstgid attribute.
    /// The first tileset always has a firstgid value of 1.
    /// Since Tiled 0.15, image collection tilesets do not necessarily number their tiles consecutively since gaps can occur when removing tiles.
    /// 
    /// Can contain: tileoffset (since 0.8), properties (since 0.8), image, terraintypes (since 0.9), tile
    /// </summary>
    public class TMXTileset
    {
        #region attributes
        #endregion
    }//public class TMXTileset
}//namespace TileMapXML.Tileset
