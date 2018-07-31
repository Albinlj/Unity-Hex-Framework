﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;

public class Cell : MonoBehaviour {

    //Event Actions
    static public event Action<Cell> ClickedEvent;
    static public event Action<Cell> EnterEvent;
    static public event Action<Cell> ExitEvent;
    static public event Action<Cell> UpEvent;

    //Fields
    public Rail[] rails = new Rail[2];
    public GameObject coordUIPrefab;
    public List<Train> trains = new List<Train>();

    [SerializeField]
    private Vector3Int cubeCoord;
    private PolygonCollider2D polyCollider;
    private MapController mapController = MapController.instance;

    //Properties
    public Vector2Int OffsetCoord {
        get { return Hex.CellCubeToOffset(cubeCoord); }
        private set { }
    }
    public Vector3Int CubeCoord {
        get { return cubeCoord; }
        private set { }
    }

    //Use this for initialization
    private void Start() {
        AddUI();
        Coloring.RandomizeColor(gameObject);
        polyCollider = gameObject.GetComponent<PolygonCollider2D>();
    }

    //Eventhandlers
    private void OnMouseDown() {
        ClickedEvent(this);
        Debug.Log(CubeCoord);
        Debug.Log(trains);
    }

    private void OnMouseEnter() {
        EnterEvent(this);
    }

    private void OnMouseExit() {
        ExitEvent(this);
    }
    private void OnMouseUp() {
        UpEvent(this);
    }
    public void Initialize(Vector3Int _cube) {
        transform.name = "Cell [" + _cube.x + ", " + _cube.y + ", " + _cube.z + "]";
        cubeCoord = _cube;
        transform.position = Layout.CubeToWorld(_cube);
    }

    private void AddUI() {
        GameObject coordUI = Instantiate(coordUIPrefab, transform);

        for (int i = 0; i < 3; i++) {
            coordUI.transform.GetChild(i).gameObject.GetComponent<UnityEngine.UI.Text>().text = cubeCoord[i].ToString();
        }
    }

    public Cell Neighbor(int _dir) {
        return MapController.instance.GetCell(Hex.Neighbor(cubeCoord, _dir));
    }

    public void AddRail(Rail rail) {
        if (rails[0] == null) {
            rails[0] = rail;
        }
        else if (rails[1] == null) {
            rails[1] = rail;
        }

        if (rails[0].path.Sorted == rail.path.Sorted) {

        }


    }
}