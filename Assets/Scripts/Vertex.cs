using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vertex : MonoBehaviour {

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
    public void Initialize(Vector2Int _offset, int _index) {
        transform.name = "Vertex [" + _offset.x + ", " + _offset.y + "]";
        transform.position = Layout.VertexOffsetToWorld(_offset, _index);
    }

}
