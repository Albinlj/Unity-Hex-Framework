using Assets.Scripts.Coords;
using Assets.Scripts.Pieces;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Lists
{
    public class PieceList : ScriptableObject
    {
        private static PieceList _inst;

        public static PieceList Ins
        {
            get
            {
                if (_inst == null)
                    _inst = Resources.FindObjectsOfTypeAll<PieceList>().FirstOrDefault();
                if (_inst == null)
                    _inst = CreateInstance<PieceList>();
                return _inst;
            }
        }

        public Dictionary<AxialCoord, Cell> Cells;
        public Dictionary<BorderCoord, Border> Borders;
        public Dictionary<VertexCoord, Vertex> Vertexes;

        private void OnEnable()
        {
            Cells = new Dictionary<AxialCoord, Cell>();
            Borders = new Dictionary<BorderCoord, Border>();
            Vertexes = new Dictionary<VertexCoord, Vertex>();
        }

        public void Add(Piece piece)
        {
            if (piece is Cell cell)
                Cells.Add(cell.Coord, cell);
            if (piece is Border border)
                Borders.Add(border.Coord, border);
            if (piece is Vertex vertex)
                Vertexes.Add(vertex.Coord, vertex);
        }
    }
}