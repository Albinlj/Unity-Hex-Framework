using Assets.Scripts.Coords;
using UnityEngine;

namespace Assets.Scripts.Pieces
{
    public class PieceInfo : ScriptableObject
    {
        public PieceColor Color { get; set; }
    }

    //public class PieceInfo<T> : ScriptableObject where T : struct
    //{
    //    public T Coord { get; set; }
    //}

    public class CellInfo : PieceInfo
    {
        public AxialCoord Coord { get; set; }

        public override string ToString() => $"{Coord} / Color:{Color}";
    }

    public class BorderInfo : PieceInfo
    {
        public BorderCoord Coord { get; set; }

        public override string ToString() => $"{Coord} / Color:{Color}";
    }

    public class VertexInfo : PieceInfo
    {
        public VertexCoord Coord { get; set; }

        public override string ToString() => $"{Coord} / Color:{Color}";
    }
}