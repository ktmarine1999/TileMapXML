namespace TileMapXML.Map
{
    /// <summary>
    /// orientation: Map orientation.
    ///         Tiled supports "orthogonal", "isometric", "staggered" (since 0.9)
    ///         and "hexagonal" (since 0.11).
    /// 
    /// Tiled Map Editor Version 0.16.2
    /// orthogonal
    /// isometric
    /// staggered-isometric staggered
    /// hexagonal-hexagonal staggered
    /// </summary>
    [System.Serializable]
    public enum TMXMapOrientation
    {
        none,
        orthogonal,
        isometric,
        staggered,
        hexagonal,
    }//enum MapOrientation
}//namespace TileMapXML.Map
