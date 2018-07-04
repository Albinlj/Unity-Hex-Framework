using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Hex {


    static public Vector3Int[] directions = new Vector3Int[] {
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
        y = offsetCoord.y - offsetCoord.x / 2;
        z = -x - y;
        return new Vector3Int(x, y, z);
    }
    static public Vector2Int AxialToOffset(Vector2Int _axial) {
        int x, y;
        x = _axial.x;
        y = _axial.y + _axial.x / 2;
        return new Vector2Int(x, y);
    }
    static public Vector3Int AxialToCube(Vector2Int axialCoord) {
        return new Vector3Int(axialCoord.x, axialCoord.y, -axialCoord.x - axialCoord.y);
    }

    static public Vector2Int CubeToOffset(Vector3Int _cube) {
        int x, y;
        x = _cube.x;
        y = _cube.y + _cube.x / 2;
        return AxialToOffset(CubeToAxial(_cube));
    }

    static public Vector2Int CubeToAxial(Vector3Int _cube) {
        return new Vector2Int(_cube.x, _cube.y);
    }


    static public List<Vector3Int> Ring(Vector3Int _origin, int radius) {
        List<Vector3Int> coordList = new List<Vector3Int>();
        Vector3Int addCoord = _origin + Hex.directions[4] * radius;
        for (int i = 0; i < 6; i++) {
            for (int j = 0; j < radius; j++) {
                coordList.Add(addCoord);
                addCoord = addCoord + Hex.directions[i];
            }
        }
        return coordList;
    }

    static public List<Vector3Int> Spiral(Vector3Int _origin, int radius) {
        List<Vector3Int> coordList = new List<Vector3Int>();
        coordList.Add(_origin);
        for (int i = 1; i <= radius; i++) {
            coordList.AddRange(Ring(_origin, i));
        }
        return coordList;
    }

}
