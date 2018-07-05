using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour {
    Vector3Int cubeCoord;
    int directionIndex;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void Initialize(Vector3Int _cube, int _index) {
        cubeCoord = _cube;
        transform.name = "Border [" + _cube.x + ", " + _cube.y + ", " + _cube.z + "]";
        transform.position = Layout.CubeToWorld(cubeCoord) + Layout.CubeToWorld(Hex.cellDirections[_index]) / 2;
        transform.Rotate(new Vector3(0, 0, -60 + 60 * _index));
        directionIndex = _index;
    }

    public bool NeighborCells() {
        List<Cell> neighborList = new List<Cell>();
        if (MapController.instance.isValidCoord(cubeCoord)) {
            neighborList.Add(MapController.instance.GetCell(cubeCoord));
        }
        return true;
    }
}
