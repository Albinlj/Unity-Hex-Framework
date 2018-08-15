using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[Serializable]
public class PieceInfo {
    [SerializeField]

    private PieceColor color;
    public PieceColor Color {
        get { return color; }
        set { color = value; }
    }
}



[Serializable]
public class CellInfo : PieceInfo, IInfo {
    [SerializeField]
    private Vector3Int coord;
    public Vector3Int Coord {
        get { return coord; }
        set { coord = value; }
    }

    public CellInfo(Vector3Int _coord) {
        coord = _coord;
    }

    public CellInfo() {

    }

}



[Serializable]
public class BorderInfo : PieceInfo, IInfo {
    [SerializeField]

    private BorderCoord coord;
    public BorderCoord Coord {
        get { return coord; }
        set { coord = value; }
    }

    public BorderInfo(BorderCoord _borderCoord) {
        coord = _borderCoord;
    }
    public BorderInfo(Vector3Int _cubeCoord, int _index) {
        coord = new BorderCoord(_cubeCoord, _index);
    }
    public BorderInfo() {

    }
}



[Serializable]
public class VertexInfo : PieceInfo, IInfo {
    [SerializeField]

    private VertexCoord coord;
    public VertexCoord Coord {
        get { return coord; }
        set { coord = value; }
    }

    public VertexInfo(VertexCoord _vertexCoord) {
        coord = _vertexCoord;
    }
    public VertexInfo(Vector3Int _cube, int _index) {
        coord = new VertexCoord(_cube, _index);
    }

    public VertexInfo() {

    }
}