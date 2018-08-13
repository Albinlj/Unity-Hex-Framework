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


    static public Vector3Int CellOffsetToCube(Vector2Int offsetCoord) {
        int x, y, z;
        x = offsetCoord.x;
        y = offsetCoord.y - offsetCoord.x / 2;
        z = -x - y;
        return new Vector3Int(x, y, z);
    }

    static public Vector2Int CellCubeToOffset(Vector3Int _cube) {
        int x, y;
        x = _cube.x;
        y = -_cube.z - (_cube.x + _cube.x % 2) / 2;
        //Debug.Log("cube is " + _cube.x + ", " + _cube.y + ", " + _cube.z);
        //Debug.Log("offset is " + x + ", " + y);
        return new Vector2Int(x, y);
    }


    #endregion

    //Finds neighbors of Cells, Borders and Vertices.
    #region Neighbors

    static public Vector3Int GetCellCellNeighborFromDir(Vector3Int _cube, int _dir) {
        return _cube + Hex.cubeDirections[_dir];
    }

    public static List<BorderCoord> GetCellBorderNeighbors(Vector3Int _cellCoord) {
        return new List<BorderCoord> {
            new BorderCoord(_cellCoord, 0),
            new BorderCoord(_cellCoord, 1),
            new BorderCoord(_cellCoord, 2),
            new BorderCoord(_cellCoord+cubeDirections[3], 0),
            new BorderCoord(_cellCoord+cubeDirections[4], 1),
            new BorderCoord(_cellCoord+cubeDirections[5], 2)

        };
    }


    static public List<Vector3Int> GetBorderCellNeighbors(Vector3Int _cube, int _dir) {
        List<Vector3Int> cubeList = new List<Vector3Int>();
        cubeList.Add(_cube);
        cubeList.Add(_cube + cubeDirections[_dir]);
        return cubeList;

    }

    static public List<VertexCoord> GetBorderVertexNeighbors(BorderCoord _borderCoord) {
        switch (_borderCoord.Index) {
            case 0:
                return new List<VertexCoord> {
                    new VertexCoord(_borderCoord.Cube, 0),
                    new VertexCoord(_borderCoord.Cube + cubeDirections[0], 1)
                };
            case 1:
                return new List<VertexCoord> {
                    new VertexCoord(_borderCoord.Cube + cubeDirections[0], 1),
                    new VertexCoord(_borderCoord.Cube + cubeDirections[2], 0)
                };
            case 2:
                return new List<VertexCoord> {
                    new VertexCoord(_borderCoord.Cube + cubeDirections[2], 0),
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
            borderCoordList.Add(new BorderCoord(_vertexCoord.Cube + cubeDirections[5], 1));
            borderCoordList.Add(new BorderCoord(_vertexCoord.Cube + cubeDirections[5], 2));
        }
        else {
            borderCoordList.Add(new BorderCoord(_vertexCoord.Cube, 2));
            borderCoordList.Add(new BorderCoord(_vertexCoord.Cube + cubeDirections[3], 0));
            borderCoordList.Add(new BorderCoord(_vertexCoord.Cube + cubeDirections[3], 1));
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
    static public int GetCellDir(Vector3Int from, Vector3Int to) {
        Vector3Int vector = to - from;
        return Array.IndexOf(cubeDirections, vector);
    }


    //Finds the new Coord of a Border if it is rotated around one of it's axises
    static public BorderCoord GetBorderCoordRotatedAroundVertex(VertexCoord _vertexCoord, BorderCoord _borderCoord, Boolean _clockwise) {
        //Gets all the borderCoords around the given vertex
        List<BorderCoord> borderCoords = GetVertexBorderNeighbors(_vertexCoord);
        //Then iterates through the borderCoords to find the given borderCoord, and returns the following border
        for (int i = 0; i < 3; i++) {
            if (_borderCoord == borderCoords[i]) {
                if (_clockwise)
                    return borderCoords[(i + 1) % 3];
                else
                    return borderCoords[(i + 2) % 3];
            }
        }
        Debug.LogError("the border param doesn't seem to be a neighbor of the vertex param");
        return new BorderCoord(Vector3Int.zero, 1);
    }


    internal static BorderCoord GetBorderCoordRotatedAroundCell(Vector3Int _cellCoord, BorderCoord _borderCoord, bool _clockwise) {
        List<BorderCoord> cellBorderNeighbors = GetCellBorderNeighbors(_cellCoord);
        for (int i = 0; i < 6; i++) {
            if (_borderCoord == cellBorderNeighbors[i]) {
                if (_clockwise)
                    return cellBorderNeighbors[(i + 5) % 6];
                else
                    return cellBorderNeighbors[(i + 1) % 6];
            }
        }
        Debug.LogError("the border param doesn't seem to be a neighbor of the cell param");
        return new BorderCoord(Vector3Int.zero, 1);
    }




}
