using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Vertex : Piece, IHasInfo {

    private VertexInfo info = new VertexInfo();
    public VertexInfo Info {
        get { return info; }
        set { info = value; }
    }



    //Event Actions
    static public event Action<Vertex, Boolean> ClickedEvent;

    public List<Border> Borders {
        get { return MapController.instance.GetBorders(Hex.GetVertexBorderNeighbors(info.Coord)); }
        private set { }
    }

    // Use this for initialization
    void Start() {
        Coloring.RandomizeColor(this.gameObject);
    }



    private void OnMouseDown() {
        Debug.Log("Clicked on Vertex[" + info.Coord.Cube.x + ", " + info.Coord.Cube.y + ", " + info.Coord.Cube.z + "], < " + info.Coord.Index + " > ");

        if (Input.GetMouseButtonDown(0)) {
            ClickedEvent(this, true);

        }
        if (Input.GetMouseButtonDown(2)) {
            ClickedEvent(this, false);

        }
    }
    public void Initialize(Vector3Int _cube, int _index) {
        transform.name = "Vertex [" + _cube.x + ", " + _cube.y + ", " + _cube.z + "], <" + _index + ">";
        info.Coord = new VertexCoord(_cube, _index);
        transform.position = Layout.CubeToWorld(info.Coord.Cube) + new Vector2(0.5f - _index, 0);
    }

    public PieceInfo GetInfo() {
        return info;
    }
}
