using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Border : Piece {
    //Fields
    [SerializeField]
    private BorderCoord coord;
    public BorderCoord Coord {
        get { return coord; }
        private set { }
    }


    //Event Actions
    static public event Action<Border> ClickedEvent;
    //static public event Action<Border> EnterEvent;
    //static public event Action<Border> ExitEvent;
    //static public event Action<Border> UpEvent;




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
        UpdateCoord(new BorderCoord(_cube, _index));
        UpdatePosition();
    }

    private void UpdatePosition() {
        Vector2 position = Layout.CubeToWorld(coord.Cube) + Layout.CubeToWorld(Hex.cubeDirections[coord.Index]) / 2;
        Quaternion rotation = Quaternion.AngleAxis(60 - 60 * coord.Index, Vector3.back);

        transform.SetPositionAndRotation(position, rotation);
    }


    private void UpdateCoord(BorderCoord _newCoord) {
        coord = _newCoord;
        int x = _newCoord.Cube.x;
        int y = _newCoord.Cube.y;
        int z = _newCoord.Cube.z;
        transform.name = "Border [" + x + ", " + y + ", " + z + "]" + "<" + _newCoord.Index + ">";
        MapController.instance.UpdateCoordInMap(this);
    }


    public Boolean RotateAround(Piece _piece, Boolean _clockwise) {
        if (_piece is Vertex) {
            Vertex vertex = (Vertex)_piece;
            BorderCoord newCoord = Hex.FindRotatedCoordAroundVertex(vertex.Coord, coord, _clockwise);
            UpdateCoord(newCoord);
            UpdatePosition();
            return true;
        }
        else if (_piece is Cell) {

            return true;
        }
        return false;
    }



}
