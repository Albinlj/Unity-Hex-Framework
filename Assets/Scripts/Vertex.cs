using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vertex : MonoBehaviour {
    Vector3Int cubeCoord;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
    public void Initialize(Vector3Int _cube, int _index) {
        transform.name = "Vertex [" + _cube.x + ", " + _cube.y + ", " + _cube.z + "]";
        cubeCoord = _cube;
        transform.position = Layout.CubeToWorld(cubeCoord) + new Vector2(0.5f - _index, 0);
    }

}
