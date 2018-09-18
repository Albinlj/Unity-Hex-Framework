using System.Collections.Generic;
using UnityEngine;

static class BlueprintHandler {


    public static Blueprint MakeBluePrintFromMap(Map _map) {
        Blueprint newBlueprint = new Blueprint();
        newBlueprint.width = _map.cells.GetLength(0);
        newBlueprint.height = _map.cells.GetLength(1);
        List<Piece> allPieces = new List<Piece>();

        foreach (Cell cell in _map.cells) {
            if (cell != null) {
                newBlueprint.cellInfoList.Add(cell.Info);
            }
        }
        foreach (Border[] borders in _map.borders) {
            foreach (Border border in borders) {
                if (border != null) {
                    newBlueprint.borderInfoList.Add(border.Info);
                }
            }
        }
        foreach (Vertex[] vertices in _map.vertices) {
            foreach (Vertex vertex in vertices) {
                if (vertex != null) {
                    newBlueprint.vertexInfoList.Add(vertex.Info);
                }

            }
        }
        return newBlueprint;
    }

    public static Blueprint CreateRectangularBlueprint(int _width, int _height) {
        Validator validator = new Validator(_width, _height);
        Blueprint newBluePrint = new Blueprint();
        newBluePrint.width = _width;
        newBluePrint.height = _height;
        //Creates cells, borders, and vertexes for the wanted cells, and an 
        //additional layer outside in order to get the needed Vertices and Borders.
        //Items are stored as offset in an Array where 
        for (int x = 0; x < _width; x++) {
            for (int y = 0; y < _height; y++) {

                Vector2Int offset = new Vector2Int(x, y);
                Vector3Int cube = Hex.CellOffsetToCube(offset);

                if (validator.isValidCoord(cube)) {
                    CellInfo newCellInfo = new CellInfo(cube);
                    newBluePrint.cellInfoList.Add(newCellInfo);
                }

                Border[] newBorderArray = new Border[3];
                for (int i = 0; i < 3; i++) {
                    if (validator.hasValidCoord(Hex.GetBorderCellNeighbors(cube, i))) {
                        BorderInfo newBorderInfo = new BorderInfo(cube, i);
                        newBluePrint.borderInfoList.Add(newBorderInfo);
                    }
                }

                for (int i = 0; i < 2; i++) {
                    if (validator.hasValidCoord(Hex.GetVertexCellNeighbors(cube, i))) {
                        VertexInfo newVertexInfo = new VertexInfo(cube, i);
                        newBluePrint.vertexInfoList.Add(newVertexInfo);
                    }
                }
            }
        }
        return newBluePrint;


    }

}
