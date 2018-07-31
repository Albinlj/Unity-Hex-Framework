﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Border : MonoBehaviour {
    //Fields
    [SerializeField]
    private BorderCoord coord;
    public BorderCoord Coord {
        get { return coord; }
        private set { }
    }

    //Event Actions
    static public event Action<Border> ClickedEvent;
    static public event Action<Border> EnterEvent;
    static public event Action<Border> ExitEvent;
    static public event Action<Border> UpEvent;




    // Use this for initialization
    void Start() {
        Coloring.RandomizeColor(gameObject);
    }

    // Update is called once per frame
    void Update() {

    }


    private void OnMouseDown() {
        ClickedEvent(this);
    }
    public void Initialize(Vector3Int _cube, int _index) {
        coord = new BorderCoord(_cube, _index);
        transform.name = "Border [" + _cube.x + ", " + _cube.y + ", " + _cube.z + "]";
        transform.position = Layout.CubeToWorld(_cube) + Layout.CubeToWorld(Hex.cubeDirections[_index]) / 2;
        transform.Rotate(new Vector3(0, 0, -60 + 60 * _index));
    }

    public bool NeighborCells() {
        List<Cell> neighborList = new List<Cell>();
        if (MapController.instance.isValidCoord(coord.Cube)) {
            neighborList.Add(MapController.instance.GetCell(coord.Cube));
        }
        return true;
    }
}
