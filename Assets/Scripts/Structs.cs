using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public struct BorderCoord {
    Vector3Int cube;
    int index;

    public BorderCoord(Vector3Int _cube, int _index) {
        cube = _cube;
        index = _index;
    }


    public Vector3Int Cube {
        get { return cube; }
        private set { }
    }

    public int Index {
        get { return index; }
        private set { }
    }

    public static bool operator ==(BorderCoord b1, BorderCoord b2) {
        return b1.Equals(b2);
    }

    public static bool operator !=(BorderCoord b1, BorderCoord b2) {
        return !b1.Equals(b2);
    }

}

public struct VertexCoord {
    Vector3Int cube;
    int index;

    public VertexCoord(Vector3Int _cube, int _index) {
        cube = _cube;
        index = _index;
    }


    public Vector3Int Cube {
        get { return cube; }
        private set { }
    }

    public int Index {
        get { return index; }
        private set { }
    }


}

