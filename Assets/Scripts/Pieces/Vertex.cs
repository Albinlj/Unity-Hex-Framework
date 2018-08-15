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
    public void Initialize(VertexInfo _newInfo) {
        ChangeCoord(_newInfo);
        UpdatePosition();
    }

    private void UpdatePosition() {
        transform.position = Layout.CubeToWorld(info.Coord.Cube) + new Vector2(0.5f - info.Coord.Index, 0);
    }

    private void ChangeCoord(VertexInfo _vertexInfo) {
        VertexCoord newCoord = _vertexInfo.Coord;
        info.Coord = newCoord;
        int x = newCoord.Cube.x;
        int y = newCoord.Cube.y;
        int z = newCoord.Cube.z;
        transform.name = "Vertex [" + x + ", " + y + ", " + z + "]" + "<" + newCoord.Index + ">";
        MapController.instance.UpdateCoordInMap(this);
    }

    public IInfo GetInfo() {
        return info;
    }
}
