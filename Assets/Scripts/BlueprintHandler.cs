using Assets.Scripts.Coords;
using Assets.Scripts.Pieces;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public static class BlueprintHandler
    {
        public static Blueprint MakeBluePrintFromMap(Map map)
        {
            Blueprint newBlueprint = new Blueprint();
            newBlueprint.width = map.cells.GetLength(0);
            newBlueprint.height = map.cells.GetLength(1);
            List<Piece> allPieces = new List<Piece>();

            foreach (Cell cell in map.cells)
            {
                if (cell != null)
                {
                    newBlueprint.cellInfoList.Add(cell.Info);
                }
            }
            foreach (Border[] borders in map.borders)
            {
                foreach (Border border in borders)
                {
                    if (border != null)
                    {
                        newBlueprint.borderInfoList.Add(border.Info);
                    }
                }
            }
            foreach (Vertex[] vertices in map.vertices)
            {
                foreach (Vertex vertex in vertices)
                {
                    if (vertex != null)
                    {
                        newBlueprint.vertexInfoList.Add(vertex.Info);
                    }
                }
            }
            return newBlueprint;
        }

        public static Blueprint CreateRectangularBlueprint(int width, int height)
        {
            Validator validator = new Validator(width, height);
            Blueprint newBluePrint = ScriptableObject.CreateInstance<Blueprint>();
            //new Blueprint();
            newBluePrint.width = width;
            newBluePrint.height = height;
            //Creates cells, borders, and vertexes for the wanted cells, and an
            //additional layer outside in order to get the needed Vertices and Borders.
            //Items are stored as offset in an Array where
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    AxialCoord coord = new OffsetCoord(x, y);

                    if (validator.IsValidCoord(coord))
                    {
                        var newCellInfo = new CellInfo((AxialCoord)coord);
                        newBluePrint.cellInfoList.Add(newCellInfo);
                    }

                    for (int i = 0; i < 3; i++)
                    {
                        if (!validator.IsValidCoord(coord.Neighbors[i])) continue;
                        var newBorderInfo = new BorderInfo(coord, i);
                        newBluePrint.borderInfoList.Add(newBorderInfo);
                    }

                    for (int i = 0; i < 2; i++)
                    {
                        if (!validator.IsValidCoord(coord.Neighbors[i])) continue;
                        var newVertexInfo = new VertexInfo(coord, i);
                        newBluePrint.vertexInfoList.Add(newVertexInfo);
                    }
                }
            }
            return newBluePrint;
        }
    }
}