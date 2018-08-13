using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using System.IO;
using UnityEngine;

public class Cell : Piece {

    //Event Actions
    static public event Action<Cell, bool> ClickedEvent;
    //static public event Action<Cell> EnterEvent;
    //static public event Action<Cell> ExitEvent;
    //static public event Action<Cell> UpEvent;

    //Fields
    //public Rail[] rails = new Rail[2];

    [SerializeField]
    private Vector3Int coord;
    private PolygonCollider2D polyCollider;

    //Properties
    public Vector2Int OffsetCoord {
        get { return Hex.CellCubeToOffset(coord); }
        private set { }
    }
    public Vector3Int Coord {
        get { return coord; }
        private set { }
    }

    public List<Border> Borders {
        get { return MapController.instance.GetBorders(Hex.GetCellBorderNeighbors(coord)); }
        private set { }
    }

    //Use this for initialization
    private void Start() {
        //AddUI();
        Coloring.RandomizeColor(gameObject);
        polyCollider = gameObject.GetComponent<PolygonCollider2D>();
    }

    //Eventhandlers
    private void OnMouseDown() {
        ClickedEvent(this, true);
        Debug.Log(Coord);

        string jsonified = JsonUtility.ToJson(this);
        File.WriteAllText("Assets/strutz.txt", jsonified);


    }

    //private void OnMouseEnter() {
    //    EnterEvent(this);
    //}

    //private void OnMouseExit() {
    //    ExitEvent(this);
    //}
    //private void OnMouseUp() {
    //    UpEvent(this);
    //}

    //Is called after Instantiation, kind of like a constructor.
    public void Initialize(Vector3Int _cube) {
        transform.name = "Cell [" + _cube.x + ", " + _cube.y + ", " + _cube.z + "]";
        coord = _cube;
        transform.position = Layout.CubeToWorld(_cube);
    }


    public void ChangeCoord(Vector3Int _cube) {
        MapController.instance.cells[Hex.CellCubeToOffset(this.Coord).x, Hex.CellCubeToOffset(this.Coord).y] = this;
    }

    //public void AddRail(Rail rail) {
    //    if (rails[0] == null) {
    //        rails[0] = rail;
    //    }
    //    else if (rails[1] == null) {
    //        rails[1] = rail;
    //    }

    //    if (rails[0].path.Sorted == rail.path.Sorted) {

    //    }


    //}
}