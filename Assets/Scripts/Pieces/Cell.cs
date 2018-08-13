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
    public void Initialize(Vector3Int _cube) {
        transform.name = "Cell [" + _cube.x + ", " + _cube.y + ", " + _cube.z + "]";
        info.Coord = _cube;
        transform.position = Layout.CubeToWorld(_cube);
    }


    public PieceInfo GetInfo() {
        return info;
    }
}