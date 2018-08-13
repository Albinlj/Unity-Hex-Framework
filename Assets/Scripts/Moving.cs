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


    public static void RotateVertexBorders(Vertex _vertex, bool _clockwise) {
        foreach (Border border in _vertex.Borders) {
            border.RotateAround(_vertex, _clockwise);
        }
    }

    internal static void RotateCellBorders(Cell _cell, bool _clockwise) {
        foreach (Border border in _cell.Borders) {
            border.RotateAround(_cell, _clockwise);
        }
    }
}
