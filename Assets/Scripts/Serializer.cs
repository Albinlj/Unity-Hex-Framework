using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using UnityEngine;

[Serializable]
public static class Serializer {
    private const string folder = "Assets/Text/";

    public static string SerializeBlueprint(Blueprint _blueprint, string _filename) {
        string json = JsonUtility.ToJson(_blueprint, true);
        Debug.Log(json);
        string path = folder + _filename + ".json";
        File.WriteAllText("Assets/Text/saveJsonTest.json", json);
        return json;
    }

    public static Blueprint DeserializeBlueprint(string _filename) {
        string path = folder + _filename + ".json";
        Blueprint deserializedBlueprint = JsonUtility.FromJson<Blueprint>(path);
        return deserializedBlueprint;
    }
}


