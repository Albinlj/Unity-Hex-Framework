using Assets.Scripts.Pieces;
using UnityEngine;

namespace Assets.Scripts
{
    public static class Moves
    {
        public static void DeleteVertexBorders(Vertex vertex)
        {
            foreach (Border border in vertex.Borders)
            {
                Object.Destroy(border.gameObject);
            }
        }

        //public static void RotateVertexBorders(Vertex vertex, bool clockwise)
        //{
        //    foreach (Border border in vertex.Borders)
        //    {
        //        border.RotateAround(vertex, clockwise);
        //    }
        //}

        internal static void RotateCellBorders(Cell cell, bool clockwise)
        {
            foreach (Border border in cell.Borders)
            {
                border.RotateAround(cell, clockwise);
            }
        }
    }
}