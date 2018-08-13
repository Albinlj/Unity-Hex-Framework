using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Vertex : Piece {
    [SerializeField]
    private VertexCoord coord;
    public VertexCoord Coord { get { return coord; } private set { } }

    //Event Actions
    static public event Action<Vertex, Boolean> ClickedEvent;
    //static public event Action<Vertex> EnterEvent;
    //static public event Action<Vertex> ExitEvent;
    //static public event Action<Vertex> UpEvent;

    public List<Border> Borders {
        get { return MapController.instance.GetBorders(Hex.GetVertexBorderNeighbors(coord)); }
        private set { }
    }

    // Use this for initialization
    void Start() {

        Coloring.RandomizeColor(this.gameObject);
    }

    // Update is called once per frame
    void Update() {

    }



    private void OnMouseDown() {
        Debug.Log("Clicked on Vertex[" + coord.Cube.x + ", " + coord.Cube.y + ", " + coord.Cube.z + "], < " + coord.Index + " > ");

        if (Input.GetMouseButtonDown(0)) {
            ClickedEvent(this, true);

        }
        if (Input.GetMouseButtonDown(2)) {
            ClickedEvent(this, false);

        }
    }
    public void Initialize(Vector3Int _cube, int _index) {
        transform.name = "Vertex [" + _cube.x + ", " + _cube.y + ", " + _cube.z + "], <" + _index + ">";
        coord = new VertexCoord(_cube, _index);
        transform.position = Layout.CubeToWorld(coord.Cube) + new Vector2(0.5f - _index, 0);
    }

}
