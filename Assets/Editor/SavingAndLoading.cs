using Assets.Scripts;
using UnityEditor;
using UnityEngine;

namespace Assets.Editor
{
    public class SavingAndLoading : EditorWindow
    {
        private string saveName = "Hejhej";

        [MenuItem("Window/My Window")]
        public static void ShowWindow()
        {
            EditorWindow.GetWindow(typeof(SavingAndLoading));
        }

        private void OnGUI()
        {
            GUILayout.Label("Struten", EditorStyles.boldLabel);
            saveName = EditorGUILayout.TextField("Blueprint Name", saveName);

            if (GUILayout.Button("Save"))
            {
                Blueprint savedBlueprint = BlueprintHandler.MakeBluePrintFromMap(MapController.Instance.map);
                Serializer.SerializeBlueprint(savedBlueprint, saveName);
            };
            if (GUILayout.Button("Load"))
            {
                Blueprint loadedBluePrint = Serializer.DeserializeBlueprint(saveName);
                MapController.Instance.LoadBlueprint(loadedBluePrint);
            }
            //EditorGUILayout.EndToggleGroup();
        }
    }
}