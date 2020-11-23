using Assets.Scripts.Coords;
using UnityEngine;

namespace Assets.Scripts
{
    public class Hex
    {
        //Handles Conversions between Cell Coordinates.

        //Returns List of Coords of rings and spirals around given cell

        #region Rings&Spirals

        //static public List<Vector3Int> CellRing(Vector3Int _origin, int radius)
        //{
        //    List<Vector3Int> coordList = new List<Vector3Int>();
        //    Vector3Int addCoord = _origin + Hex.cubeDirections[4] * radius;
        //    for (int i = 0; i < 6; i++)
        //    {
        //        for (int j = 0; j < radius; j++)
        //        {
        //            coordList.Add(addCoord);
        //            addCoord = addCoord + Hex.cubeDirections[i];
        //        }
        //    }
        //    return coordList;
        //}

        //static public List<Vector3Int> CellSpiral(Vector3Int _origin, int radius)
        //{
        //    List<Vector3Int> coordList = new List<Vector3Int>();
        //    coordList.Add(_origin);
        //    for (int i = 1; i <= radius; i++)
        //    {
        //        coordList.AddRange(CellRing(_origin, i));
        //    }
        //    return coordList;
        //}

        #endregion Rings&Spirals

        //Finds the new Coord of a Border if it is rotated around one of it's axises
        public static BorderCoord GetBorderCoordRotatedAroundVertex(VertexCoord vertexCoord, BorderCoord borderCoord, bool clockwise)
        {
            //Gets all the borderCoords around the given vertex
            var borderCoords = vertexCoord.Borders;
            //Then iterates through the borderCoords to find the given borderCoord, and returns the following border
            for (int i = 0; i < 3; i++)
            {
                if (borderCoord != borderCoords[i]) continue;
                return clockwise
                    ? borderCoords[(i + 1) % 3]
                    : borderCoords[(i + 2) % 3];
            }
            Debug.LogError("the border param doesn't seem to be a neighbor of the vertex param");
            return new BorderCoord(Vector2Int.zero, 1);
        }

        internal static BorderCoord GetBorderCoordRotatedAroundCell(AxialCoord cellCoord, BorderCoord borderCoord, bool clockwise)
        {
            var cellBorderNeighbors = cellCoord.Borders;
            for (int i = 0; i < 6; i++)
            {
                if (borderCoord != cellBorderNeighbors[i]) continue;
                return clockwise
                    ? cellBorderNeighbors[(i + 5) % 6]
                    : cellBorderNeighbors[(i + 1) % 6];
            }
            Debug.LogError("the border param doesn't seem to be a neighbor of the cell param");
            return new BorderCoord(Vector2Int.zero, 1);
        }
    }
}