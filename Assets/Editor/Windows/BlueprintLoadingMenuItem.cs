using Assets.Scripts.Lists;
using UnityEditor;
using UnityEngine;

namespace Assets.Editor
{
    public class BlueprintLoading : EditorWindow
    {
        private Object blueprintToLoad;
        private string myString = "Hello World";
        private bool groupEnabled;
        private bool myBool = true;
        private float myFloat = 1.23f;

        [MenuItem("Blueprints/Loading and Saving")]
        public static void ShowWindow()
        {
            var window = GetWindow<BlueprintLoading>("Blueprint LLL ANDSS");
            window.Show();
        }

        public void OnGUI()
        {
            GUILayout.Label("Base Settings", EditorStyles.boldLabel);
            myString = EditorGUILayout.TextField("Text Field", myString);

            groupEnabled = EditorGUILayout.BeginToggleGroup("Optional Settings", groupEnabled);
            myBool = EditorGUILayout.Toggle("Toggle", myBool);
            blueprintToLoad = EditorGUILayout.ObjectField(PieceList.Ins, typeof(ScriptableObject), false);
            myFloat = EditorGUILayout.Slider("Slider", myFloat, -3, 3);
            EditorGUILayout.EndToggleGroup();
        }
    }
}