using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public static class Moves {


    public static void DeleteVertexBorders(Vertex _vertex) {
        foreach (Border border in _vertex.Borders) {
            MonoBehaviour.Destroy(border.gameObject);
        }
    }

    public static void RotateVertexBorders(Vertex _vertex, Boolean _clockwise) {
        foreach (Border border in _vertex.Borders) {
            RotateVertexBorder(border, _vertex, _clockwise);
        }
    }

    public static void RotateVertexBorder(Border _border, Vertex _vertex, Boolean _clockwise) {
        BorderCoord newCoord = Hex.FindRotatedCoordAroundVertex(_vertex.Coord, _border.Coord, _clockwise);


    }



}
