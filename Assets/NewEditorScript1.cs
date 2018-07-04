﻿using UnityEngine;
using UnityEditor;

public class CellTester : EditorWindow {

    [MenuItem("Tools/Show The Strut")]
    public static void ShowWindow() {
        GetWindow<CellTester>("This is the strut");
    }

    private void OnGUI() {
        GUILayout.Label("Time to find some neighbors");


        if (GUILayout.Button("Move Neighbors!")) {
            if (Selection.activeGameObject != null) {
                foreach (Cell cell in MapController.instance.Spiral(Selection.activeGameObject.GetComponent<Cell>().CubeCoord, 3)) {
                    cell.gameObject.transform.position = new Vector3(-2, -2, -2);
                }

            }
        }
        if (GUILayout.Button("Move this tile!")) {
            if (Selection.activeGameObject != null) {

                Selection.activeGameObject.GetComponent<Cell>().transform.position = new Vector3(-3, -3, -3);

            }
        }
        if (GUILayout.Button("Move 2,2!")) {
            if (Selection.activeGameObject != null) {
                MapController.instance.cells[2, 2].transform.position = new Vector3(-4, -4, -4);

            }
        }




    }
}