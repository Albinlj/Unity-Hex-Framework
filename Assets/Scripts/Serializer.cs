using System;
using System.IO;
using UnityEngine;

namespace Assets.Scripts
{
    [Serializable]
    public static class Serializer {
        private const string Folder = "Assets/Text/";

        public static string SerializeBlueprint(Blueprint blueprint, string filename) {
            string json = JsonUtility.ToJson(blueprint, true);
            Debug.Log("Serialized text = " + json);
            string path = Folder + filename + ".json";
            File.WriteAllText(path, json);
            return json;
        }

        public static Blueprint DeserializeBlueprint(string filename) {
            string path = Folder + filename + ".json";
            string json = File.ReadAllText(path);
            Blueprint deserializedBlueprint = JsonUtility.FromJson<Blueprint>(json);
            return deserializedBlueprint;
        }
    }
}


