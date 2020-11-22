using System;
using UnityEngine;

[Serializable]
public struct VertexCoord
{
    [SerializeField]
    private Vector3Int cube;

    [SerializeField]
    private int index;

    public VertexCoord(Vector3Int _cube, int _index)
    {
        cube = _cube;
        index = _index;
    }

    public Vector3Int Cube
    {
        get { return cube; }
        private set { }
    }

    public int Index
    {
        get { return index; }
        private set { }
    }
}