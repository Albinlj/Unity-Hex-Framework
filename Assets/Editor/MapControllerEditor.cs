using Assets.Scripts;
using UnityEditor;
using UnityEngine;

namespace Assets.Editor
{
    [CustomEditor(typeof(MapController))]
    public class MapControllerEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            var controller = (MapController)target;
            if (GUILayout.Button("End"))
            {
                controller.SaveBlueprint();
                //colliderCreator.endTrigger(); // how do i call this?
            }
            DrawDefaultInspector();
        }
    }
}