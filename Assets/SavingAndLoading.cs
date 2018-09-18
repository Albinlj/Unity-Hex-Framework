using UnityEngine;
using UnityEditor;
using System.Collections;

class SavingAndLoading : EditorWindow {

    string saveName = "Hejhej";

    [MenuItem("Window/My Window")]
    public static void ShowWindow() {
        EditorWindow.GetWindow(typeof(SavingAndLoading));
    }

    void OnGUI() {
        GUILayout.Label("Struten", EditorStyles.boldLabel);
        saveName = EditorGUILayout.TextField("Blueprint Name", saveName);

        if (GUILayout.Button("Save")) {
            Blueprint savedBlueprint = BlueprintHandler.MakeBluePrintFromMap(MapController.Instance.map);
            Serializer.SerializeBlueprint(savedBlueprint, saveName);
        };
        if (GUILayout.Button("Load")) {
            Blueprint loadedBluePrint = Serializer.DeserializeBlueprint(saveName);
            MapController.Instance.LoadBlueprint(loadedBluePrint);
        }
        //EditorGUILayout.EndToggleGroup();
    }
}