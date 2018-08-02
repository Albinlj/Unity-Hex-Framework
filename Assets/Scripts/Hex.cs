using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Hex {


    static public Vector3Int[] cubeDirections = new Vector3Int[] {
        new Vector3Int(1,0,-1),
        new Vector3Int(0,1,-1),
        new Vector3Int(-1,1,0),
        new Vector3Int(-1,0,1),
        new Vector3Int(0,-1,1),
        new Vector3Int(1,-1,0)
        };



    //Handles Conversions between Cell Coordinates.
    #region Axial/Cube/Offset-conversions

    static public Vector2Int CellOffsetToAxial(Vector2Int _offset) {
        Vector3Int cube = CellOffsetToCube(_offset);
        return new Vector2Int(cube.x, cube.y);
    }

    static public Vector3Int CellOffsetToCube(Vector2Int offsetCoord) {
        int x, y, z;
        x = offsetCoord.x;
        y = offsetCoord.y - offsetCoord.x / 2;
        z = -x - y;
        return new Vector3Int(x, y, z);
    }
    static public Vector2Int CellAxialToOffset(Vector2Int _axial) {
        int x, y;
        x = _axial.x;
        y = _axial.y + _axial.x / 2;
        return new Vector2Int(x, y);
    }
    static public Vector3Int CellAxialToCube(Vector2Int axialCoord) {
        return new Vector3Int(axialCoord.x, axialCoord.y, -axialCoord.x - axialCoord.y);
    }

    static public Vector2Int CellCubeToOffset(Vector3Int _cube) {

        return CellAxialToOffset(CellCubeToAxial(_cube));
    }

    static public Vector2Int CellCubeToAxial(Vector3Int _cube) {
        return new Vector2Int(_cube.x, _cube.y);
    }
    #endregion

    //Finds neighbors of Cells, Borders and Vertices.
    #region Neighbors

    static public Vector3Int GetCellCellNeighborFromDir(Vector3Int _cube, int _dir) {
        return _cube + Hex.cubeDirections[_dir];
    }


    static public List<Vector3Int> GetBorderCellNeighbors(Vector3Int _cube, int _dir) {
        List<Vector3Int> cubeList = new List<Vector3Int>();
        cubeList.Add(_cube);
        cubeList.Add(GetCellCellNeighborFromDir(_cube, _dir));
        return cubeList;

    }

    static public List<VertexCoord> GetBorderVertexNeighbors(BorderCoord _borderCoord) {
        switch (_borderCoord.Index) {
            case 0:
                return new List<VertexCoord> {
                    new VertexCoord(_borderCoord.Cube, 0),
                    new VertexCoord(GetCellCellNeighborFromDir(_borderCoord.Cube, 0), 1)
                };
            case 1:
                return new List<VertexCoord> {
                    new VertexCoord(GetCellCellNeighborFromDir(_borderCoord.Cube, 0), 1),
                    new VertexCoord(GetCellCellNeighborFromDir(_borderCoord.Cube, 2), 0)
                };
            case 2:
                return new List<VertexCoord> {
                    new VertexCoord(GetCellCellNeighborFromDir(_borderCoord.Cube, 2), 0),
                    new VertexCoord(_borderCoord.Cube, 1)
                };
            default:
                return null;
        }
    }


    static public List<BorderCoord> GetVertexBorderNeighbors(VertexCoord _vertexCoord) {
        List<BorderCoord> borderCoordList = new List<BorderCoord>();
        if (_vertexCoord.Index == 0) {
            borderCoordList.Add(new BorderCoord(_vertexCoord.Cube, 0));
            borderCoordList.Add(new BorderCoord(GetCellCellNeighborFromDir(_vertexCoord.Cube, 5), 1));
            borderCoordList.Add(new BorderCoord(GetCellCellNeighborFromDir(_vertexCoord.Cube, 5), 2));
        }
        else {
            borderCoordList.Add(new BorderCoord(_vertexCoord.Cube, 2));
            borderCoordList.Add(new BorderCoord(GetCellCellNeighborFromDir(_vertexCoord.Cube, 3), 0));
            borderCoordList.Add(new BorderCoord(GetCellCellNeighborFromDir(_vertexCoord.Cube, 3), 1));
        }
        return borderCoordList;
    }

    static public List<Vector3Int> GetVertexCellNeighbors(Vector3Int _cube, int _dir) {
        List<Vector3Int> cubeList = new List<Vector3Int>();
        cubeList.Add(_cube);
        switch (_dir) {
            case 0:
                cubeList.Add(_cube + cubeDirections[0]);
                cubeList.Add(_cube + cubeDirections[5]);
                break;
            case 1:
                cubeList.Add(_cube + cubeDirections[2]);
                cubeList.Add(_cube + cubeDirections[3]);
                break;
            default:
                break;
        }
        return cubeList;
    }

    #endregion

    //Returns List of Coords of rings and spirals around given cell
    #region Rings&Spirals
    static public List<Vector3Int> CellRing(Vector3Int _origin, int radius) {
        List<Vector3Int> coordList = new List<Vector3Int>();
        Vector3Int addCoord = _origin + Hex.cubeDirections[4] * radius;
        for (int i = 0; i < 6; i++) {
            for (int j = 0; j < radius; j++) {
                coordList.Add(addCoord);
                addCoord = addCoord + Hex.cubeDirections[i];
            }
        }
        return coordList;
    }

    static public List<Vector3Int> CellSpiral(Vector3Int _origin, int radius) {
        List<Vector3Int> coordList = new List<Vector3Int>();
        coordList.Add(_origin);
        for (int i = 1; i <= radius; i++) {
            coordList.AddRange(CellRing(_origin, i));
        }
        return coordList;
    }

    #endregion







    //Finds Direction from one Cell to another.
    static public int FindCellDir(Vector3Int from, Vector3Int to) {
        Vector3Int vector = to - from;
        return Array.IndexOf(cubeDirections, vector);
    }


    //Finds the new Coord of a Border if it is rotated around one of it's axises
    static public BorderCoord FindRotatedCoordAroundVertex(VertexCoord _vertexCoord, BorderCoord _borderCoord, Boolean _clockwise) {

        List<BorderCoord> borderCoords = GetVertexBorderNeighbors(_vertexCoord);
        for (int i = 0; i < 3; i++) {
            if (_borderCoord == borderCoords[i]) {
                if (_clockwise)
                    return borderCoords[(i + 1) % 3];
                else {
                    if (i == 0) {
                        return borderCoords[2];
                    }
                    else {
                        return borderCoords[i - 1];
                    }
                }
            }
        }
        Debug.LogError("the border param doesn't seem to be a neighbor of the vertex param");
        return new BorderCoord(Vector3Int.zero, 1);
    }



}
