using Assets.Scripts.Coords;
using Assets.Scripts.Pieces;
using UnityEngine;

namespace Assets.Scripts
{
    public static class PieceInfoFactory
    {
        public static CellInfo CreateCellInfo(AxialCoord coord)
        {
            var info = ScriptableObject.CreateInstance<CellInfo>();
            info.Coord = coord;
            return info;
        }

        public static CellInfo CreateCellInfo(int x, int y) => CreateCellInfo(new AxialCoord(x, y));

        public static BorderInfo CreateBorderInfo(BorderCoord coord)
        {
            var info = ScriptableObject.CreateInstance<BorderInfo>();
            info.Coord = coord;
            return info;
        }

        public static BorderInfo CreateBorderInfo(int x, int y, int i) => CreateBorderInfo(new BorderCoord(x, y, i));

        public static VertexInfo CreateVertexInfo(VertexCoord coord)
        {
            var info = ScriptableObject.CreateInstance<VertexInfo>();
            info.Coord = coord;
            return info;
        }

        public static VertexInfo CreateVertexInfo(int x, int y, int i) => CreateVertexInfo(new VertexCoord(x, y, i));
    }
}