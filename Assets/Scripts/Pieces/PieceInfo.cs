using Assets.Scripts.Coords;
using System;
using UnityEngine;

namespace Assets.Scripts.Pieces
{
    public class PieceInfo
    {
        private bool isOn;

        public bool IsOn
        {
            get => isOn;
            set => isOn = value;
        }

        private PieceColor color;

        public PieceColor Color
        {
            get => color;
            set => color = value;
        }
    }

    [Serializable]
    public class CellInfo : PieceInfo, IInfo
    {
        [field: SerializeField]
        public AxialCoord Coord { get; set; }

        public CellInfo(AxialCoord coord)
        {
            Coord = coord;
        }

        public CellInfo()
        {
        }
    }

    [Serializable]
    public class BorderInfo : PieceInfo, IInfo
    {
        [SerializeField]
        private BorderCoord coord;

        public BorderCoord Coord
        {
            get => coord;
            set => coord = value;
        }

        public BorderInfo(BorderCoord borderCoord)
        {
            coord = borderCoord;
        }

        public BorderInfo(AxialCoord axial, int index)
        {
            coord = new BorderCoord(axial, index);
        }
    }

    [Serializable]
    public class VertexInfo : PieceInfo, IInfo
    {
        [SerializeField]
        private VertexCoord coord;

        public VertexCoord Coord
        {
            get => coord;
            set => coord = value;
        }

        public VertexInfo(VertexCoord vertexCoord)
        {
            coord = vertexCoord;
        }

        public VertexInfo(Vector3Int cube, int index)
        {
            coord = new VertexCoord((Vector2Int)cube, index);
        }
    }
}