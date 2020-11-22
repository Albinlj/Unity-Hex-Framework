using System;
using UnityEngine;

[Serializable]

public struct BorderCoord {
    [SerializeField]
    private Vector3Int cube;
    [SerializeField]
    private int index;

    public BorderCoord(Vector3Int _cube, int _index) {
        cube = _cube;
        index = _index;
    }


    public Vector3Int Cube {
        get { return cube; }
        set { cube = value; }
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