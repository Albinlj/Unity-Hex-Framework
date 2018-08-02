using UnityEngine;
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
                foreach (Cell cell in MapController.instance.Spiral(Selection.activeGameObject.GetComponent<Cell>().Coord, 3)) {
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

        if (GUILayout.Button("Move to Cubecoordinate 3, 1, -4")) {
            Selection.activeGameObject.transform.position = Layout.CubeToWorld(new Vector3Int(3, 1, -4));
        }

        if (GUILayout.Button("Clear all Rails")) {
            RailController.instance.DeleteAllRails();
        }
        if (GUILayout.Button("Spawn Train at 0 0 0")) {
            TrainController.instance.SpawnTrain(Vector3Int.zero, new Path(4, 1));
        }

    }
}
