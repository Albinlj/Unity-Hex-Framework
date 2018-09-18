using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Border : Piece, IHasInfo {
    //Fields
    [SerializeField]
    private BorderInfo info = new BorderInfo();
    public BorderInfo Info {
        get { return info; }
        set { info = value; }
    }

    //Event Actions
    static public event Action<Border> ClickedEvent;



    // Use this for initialization
    void Start() {
        Coloring.RandomizeColor(gameObject);
    }


    private void OnMouseDown() {
        ClickedEvent(this);
    }
    public void Initialize(BorderInfo _borderInfo) {
        ChangeCoord(_borderInfo.Coord);
        UpdatePosition();
    }

    private void UpdatePosition() {
        Vector2 position = Layout.CubeToWorld(info.Coord.Cube) + Layout.CubeToWorld(Hex.cubeDirections[info.Coord.Index]) / 2;
        Quaternion rotation = Quaternion.AngleAxis(60 - 60 * info.Coord.Index, Vector3.back);
        transform.SetPositionAndRotation(position, rotation);
    }


    private void ChangeCoord(BorderCoord _newCoord) {
        info.Coord = _newCoord;
        int x = _newCoord.Cube.x;
        int y = _newCoord.Cube.y;
        int z = _newCoord.Cube.z;
        transform.name = "Border [" + x + ", " + y + ", " + z + "]" + "<" + _newCoord.Index + ">";
        MapController.Instance.UpdateCoordInMap(this);
    }


    public Boolean RotateAround(Piece _piece, Boolean _clockwise) {
        if (_piece is Vertex) {
            Vertex vertex = (Vertex)_piece;
            BorderCoord newCoord = Hex.GetBorderCoordRotatedAroundVertex(vertex.Info.Coord, Info.Coord, _clockwise);
            ChangeCoord(newCoord);
            UpdatePosition();
            return true;
        }
        else if (_piece is Cell) {
            Cell cell = (Cell)_piece;
            BorderCoord newCoord = Hex.GetBorderCoordRotatedAroundCell(cell.Coord, Info.Coord, _clockwise);
            ChangeCoord(newCoord);
            UpdatePosition();
            return true;
        }
        return false;
    }


    public IInfo GetInfo() {
        return info;
    }

}
