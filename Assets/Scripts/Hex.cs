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


    static public Vector2Int OffsetToAxial(Vector2Int _offset) {
        Vector3Int cube = OffsetToCube(_offset);
        return new Vector2Int(cube.x, cube.y);
    }

    static public Vector3Int OffsetToCube(Vector2Int offsetCoord) {
        int x, y, z;
        x = offsetCoord.x;
        y = offsetCoord.y - (offsetCoord.x - 1) % 2;
        z = -offsetCoord.y - offsetCoord.x % 2;
        return new Vector3Int(x, y, z);
    }
    static public Vector2Int AxialToOffset(Vector2Int _axial) {
        int x, y;
        x = _axial.x - _axial.y;
        y = (_axial.y - 1) % 2;
        return new Vector2Int(x, y);
    }
    static public Vector3Int AxialToCube(Vector2Int axialCoord) {
        return new Vector3Int(axialCoord.x, axialCoord.y, -axialCoord.x - axialCoord.y);
    }

    static public Vector2Int CubeToOffset(Vector3Int _cube) {
        return AxialToOffset(CubeToAxial(_cube));
    }

    static public Vector2Int CubeToAxial(Vector3Int _cube) {
        return new Vector2Int(_cube.x, _cube.y);
    }

    //Returns Strut
    static public Vector3Int[] getNeighbors(Vector3Int _cube) {
        Vector3Int[] neighborCoords = new Vector3Int[6];
        foreach (Vector3Int dir in cubeDirections) {
            neighborCoords[Array.IndexOf(cubeDirections, dir)] = _cube + dir;
        }
        return neighborCoords;
    }

}
