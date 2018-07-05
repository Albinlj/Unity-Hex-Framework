using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour {

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void Initialize(Vector2Int _offset, int _index) {
        transform.name = "Border [" + _offset.x + ", " + _offset.y + "]";

        transform.position = Layout.BorderOffsetToWorld(_offset, _index);
        transform.Rotate(new Vector3(0, 0, -60 + 60 * _index));
    }
}
