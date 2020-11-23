using Assets.Scripts.Pieces;

namespace Assets.Scripts
{
    public class Map
    {
        public Cell[,] cells;
        public Border[,][] borders;
        public Vertex[,][] vertices;

        public Map(int width, int height)
        {
            cells = new Cell[width, height];
            borders = new Border[width, height][];
            vertices = new Vertex[width, height][];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    borders[x, y] = new Border[3];
                    vertices[x, y] = new Vertex[2];
                }
            }
        }
    }
}