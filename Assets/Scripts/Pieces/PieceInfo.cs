using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[Serializable]
public class PieceInfo {
    private PieceColor color;
    public PieceColor Color {
        get { return color; }
        set { color = value; }
    }
}

public class CellInfo : PieceInfo {

    private Vector3Int coord;
    public Vector3Int Coord {
        get { return coord; }
        set { coord = value; }
    }
}

public class BorderInfo : PieceInfo {

    private BorderCoord coord;
    public BorderCoord Coord {
        get { return coord; }
        set { coord = value; }
    }



}
public class VertexInfo : PieceInfo {

    private VertexCoord coord;
    public VertexCoord Coord {
        get { return coord; }
        set { coord = value; }
    }
}