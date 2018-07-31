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

    public static void RotateVertexBorders(Vertex _vertex) {
        foreach (Border border in _vertex.Borders) {
            
        }
    }

}
