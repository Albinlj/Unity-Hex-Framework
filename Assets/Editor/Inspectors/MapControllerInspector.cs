using Assets.Scripts;
using UnityEditor;
using UnityEngine;

namespace Assets.Editor
{
    [CustomEditor(typeof(MapController))]
    public class MapControllerInspector : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            var controller = (MapController)target;
            if (GUILayout.Button("Save Blueprint"))
            {
                controller.SaveBlueprint();
            }

            if (GUILayout.Button("Save as new Blueprint"))
            {
                controller.SaveBlueprint();
            }

            if (GUILayout.Button("Load Blueprint"))
            {
                controller.LoadBlueprint();
            }

            if (GUILayout.Button("Reset"))
            {
                controller.Reset();
            }
            DrawDefaultInspector();
        }
    }
}