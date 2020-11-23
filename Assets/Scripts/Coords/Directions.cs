namespace Assets.Scripts.Coords
{
    public class Directions
    {
        public static AxialCoord[] HexDirections { get; } =
        {
            new AxialCoord(1, 0),
            new AxialCoord(0, 1),
            new AxialCoord(-1, 1),
            new AxialCoord(-1, 0),
            new AxialCoord(0, -1),
            new AxialCoord(1, -1)
        };
    }
}