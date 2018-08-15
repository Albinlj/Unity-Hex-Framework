using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using System.IO;
using UnityEngine;

public class Cell : Piece, IHasInfo {

    //Event Actions
    static public event Action<Cell, bool> ClickedEvent;

    [SerializeField]
    private CellInfo info = new CellInfo();
    public CellInfo Info {
        get { return info; }
        set { info = value; }
    }

    private PolygonCollider2D polyCollider;

    //Properties

    public Vector3Int Coord {
        get { return info.Coord; }
        private set { }
    }

    public List<Border> Borders {
        get { return MapController.instance.GetBorders(Hex.GetCellBorderNeighbors(info.Coord)); }
        private set { }
    }

    //Use this for initialization
    private void Start() {
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

    //Is called after Instantiation, kind of like a constructor.
    public void Initialize(CellInfo _cellInfo) {
        ChangeCoord(_cellInfo);
        UpdatePosition(_cellInfo);
    }

    private void UpdatePosition(CellInfo _cellInfo) {
        transform.position = Layout.CubeToWorld(_cellInfo.Coord);
    }

    private void ChangeCoord(CellInfo _cellInfo) {
        info = _cellInfo;
        int x = _cellInfo.Coord.x;
        int y = _cellInfo.Coord.y;
        int z = _cellInfo.Coord.z;
        transform.name = "Cell [" + x + ", " + y + ", " + z + "]";
        MapController.instance.UpdateCoordInMap(this);
    }

    public IInfo GetInfo() {
        return info;
    }
}