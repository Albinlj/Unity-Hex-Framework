using System.Collections.Generic;
using UnityEngine;

class Validator {
    private int width;
    public int Width {
        get { return width; }
        private set { width = value; }
    }
    private int height;
    public int Height {
        get { return height; }
        private set { height = value; }
    }

    public Validator(int _width, int _height) {
        width = _width;
        height = _height;
    }


    //Checks if a coord or a list of coords is inside the playarea
    public bool isValidCoord(Vector2Int _offset) {
        if (1 <= _offset.x && _offset.x <= width - 2
            && 1 <= _offset.y && _offset.y <= height - 2) {
            return true;
        }
        else {
            return false;
        }
    }

    public bool isValidCoord(Vector3Int _cube) {
        return isValidCoord(Hex.CellCubeToOffset(_cube));
    }

    public bool isValidCoord(List<Vector3Int> _cubeList) {
        foreach (Vector3Int _cube in _cubeList) {
            if (!isValidCoord(_cube)) {
                return false;
            }
        }
        return true;
    }

    //Checks a list of coords to see if it has one or more coords inside the playarea.
    public bool hasValidCoord(List<Vector3Int> _cubeList) {
        foreach (Vector3Int _cube in _cubeList) {
            if (isValidCoord(_cube)) {
                return true;
            }
        }
        return false;
    }
}

