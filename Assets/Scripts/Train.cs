using UnityEngine;
using System.Collections;
using System;

public class Train : MonoBehaviour {
    public Path path;
    Vector3Int cubeCoord;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

        if (path.IsStraight) {
            Vector2[] pos = new Vector2[2];
            for (int i = 0; i < 2; i++) {
                pos[i] = Layout.CubeToWorld(cubeCoord) + Layout.CubeToWorld(Hex.cubeDirections[path[i]]) / 2;
            }
            transform.position = Vector2.Lerp(pos[0], pos[1], GameController.instance.roundTime);
        }
    }

    public void Initialize(Vector3Int _cube, Path _path) {
        transform.position = Layout.CubeToWorld(_cube);
        Debug.Log(this);
        MapController.instance.GetCell(_cube).trains.Add(new Train());
        path = _path;
        cubeCoord = _cube;

    }
}
