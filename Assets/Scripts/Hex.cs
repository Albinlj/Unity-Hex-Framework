using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Hex {


    static public Vector3Int[] cellDirections = new Vector3Int[] {
        new Vector3Int(1,0,-1),
        new Vector3Int(0,1,-1),
        new Vector3Int(-1,1,0),
        new Vector3Int(-1,0,1),
        new Vector3Int(0,-1,1),
        new Vector3Int(1,-1,0)
        };

    static public Vector3Int[] cubeDirections = new Vector3Int[] {
        new Vector3Int(1,0,0),
        new Vector3Int(0,0,-1),
        new Vector3Int(0,1,0),
        new Vector3Int(-1,0,0),
        new Vector3Int(0,0,1),
        new Vector3Int(0,-1,0)
    };

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


    static public List<Vector3Int> CellRing(Vector3Int _origin, int radius) {
        List<Vector3Int> coordList = new List<Vector3Int>();
        Vector3Int addCoord = _origin + Hex.cellDirections[4] * radius;
        for (int i = 0; i < 6; i++) {
            for (int j = 0; j < radius; j++) {
                coordList.Add(addCoord);
                addCoord = addCoord + Hex.cellDirections[i];
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

    static public Vector3Int Neighbor(Vector3Int _cube, int _dir) {
        return _cube + Hex.cellDirections[_dir];
    }

    static public List<Vector3Int> BorderCellNeighbors(Vector3Int _cube, int _dir) {
        List<Vector3Int> cubeList = new List<Vector3Int>();
        cubeList.Add(_cube);
        cubeList.Add(Neighbor(_cube, _dir));
        return cubeList;

    }

    static public List<Vector3Int> VertexCellNeighbors(Vector3Int _cube, int _dir) {
        List<Vector3Int> cubeList = new List<Vector3Int>();
        cubeList.Add(_cube);
        switch (_dir) {
            case 0:
                cubeList.Add(_cube + cellDirections[0]);
                cubeList.Add(_cube + cellDirections[5]);
                break;
            case 1:
                cubeList.Add(_cube + cellDirections[2]);
                cubeList.Add(_cube + cellDirections[3]);
                break;
            default:
                break;
        }
        return cubeList;
    }
}
