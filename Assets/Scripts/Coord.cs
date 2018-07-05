﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

struct Coord {
    private Vector2Int offset;
    private Vector2Int axial;
    private Vector3Int cube;


    //Offset Input
    public Coord(Vector2Int _offset) {
        offset = _offset;
        axial = Hex.CellOffsetToAxial(_offset);
        cube = Hex.CellOffsetToCube(_offset);
    }

    public Coord(Vector3Int _cube) {
        offset = Hex.CellCubeToOffset(_cube);
        axial = Hex.CellCubeToAxial(_cube);
        cube = _cube;
    }

    public Vector2Int Offset {
        get { return offset; }
        set { }
    }

    public Vector2Int Axial {
        get { return axial; }
        set { }
    }

    public Vector3Int Cube {
        get { return cube; }
        set { }
    }


}

