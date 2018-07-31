using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

public class MapController : MonoBehaviour {
    public static MapController instance;
    public GameObject cellPrefab;
    public GameObject borderPrefab;
    public GameObject vertexPrefab;
    private GameObject cellHolder;
    private GameObject borderHolder;
    private GameObject vertexHolder;

    public Cell[,] cells;

    private Border[,][] borders;
    private Vertex[,][] vertices;

    // Use this for initialization
    private void Awake() {

        if (instance != this) {
            instance = this;
        }
        else {
            Debug.LogError("MapController singleton bug");
            Destroy(this);
        }
    }

    void Start() {

        new GameObject();
        cellHolder = new GameObject("CellHolder");
        cellHolder.transform.SetParent(this.transform);
        borderHolder = new GameObject("BorderHolder");
        borderHolder.transform.SetParent(this.transform);
        vertexHolder = new GameObject("vertexHolder");
        vertexHolder.transform.SetParent(this.transform);

    }

    // Update is called once per frame
    void Update() {

    }



    void OnVertexMouseDown(Vertex _vertex) {


    }

    //void RotateBorderAroundVertex(Border _border, bool clockwise) {
    //}

    public void CreateRectMap(int _width, int _height) {

        //Creates cells, borders, and vertexes for the wanted cells, and an 
        //additional layer outside in order to get the needed Vertices and Borders.
        //Items are stored as offset in an Array where indexes are coords - 1;
        cells = new Cell[_width + 2, _height + 2];
        borders = new Border[_width + 2, _height + 2][];
        vertices = new Vertex[_width + 2, _height + 2][];
        for (int x = 0; x < _width + 2; x++) {
            for (int y = 0; y < _height + 2; y++) {

                Vector2Int offset = new Vector2Int(x - 1, y - 1);
                Vector3Int cube = Hex.CellOffsetToCube(offset);

                //Instantiates a Cell
                if (isValidCoord(cube)) {
                    GameObject newCellObj = Instantiate(cellPrefab);
                    Cell newCell = newCellObj.GetComponent<Cell>();
                    newCell.transform.SetParent(cellHolder.transform);
                    newCell.Initialize(cube);
                    cells[x, y] = newCell;
                }

                //Instantiates a Border if it has a neighboring Cell 
                Border[] newBorderArray = new Border[3];
                for (int i = 0; i < 3; i++) {
                    if (hasValidCoord(Hex.BorderCellNeighbors(cube, i))) {
                        GameObject newBorderObj = Instantiate(borderPrefab);
                        Border newBorder = newBorderObj.GetComponent<Border>();
                        newBorder.transform.SetParent(borderHolder.transform);
                        newBorder.Initialize(cube, i);
                        newBorderArray[i] = newBorder;
                    }
                }
                borders[x, y] = newBorderArray;

                //Instantiates a Vertex if it has a neighboring Cell
                Vertex[] newVertexArray = new Vertex[2];
                for (int i = 0; i < 2; i++) {
                    if (hasValidCoord(Hex.VertexCellNeighbors(cube, i))) {

                        GameObject newVertexObj = Instantiate(vertexPrefab);
                        Vertex newVertex = newVertexObj.GetComponent<Vertex>();
                        newVertex.transform.SetParent(vertexHolder.transform);
                        newVertex.Initialize(cube, i);
                        newVertexArray[i] = newVertex;
                    }
                }
                vertices[x, y] = newVertexArray;
            }
        }

        CameraController.instance.UpdateCamera(_width, _height);


    }


    //Getting Cells from offsets or cubes, or a list of cubes.
    private Cell GetCell(Vector2Int _offset) {
        if (isValidCoord(_offset)) {
            return cells[_offset.x, _offset.y];
        }
        else {
            return null;
        }
    }
    public Cell GetCell(Vector3Int _cube) {
        return GetCell(Hex.CellCubeToOffset(_cube));
    }
    public List<Cell> GetCells(List<Vector3Int> list) {
        List<Cell> cellList = new List<Cell>();
        foreach (Vector3Int coord in list) {
            cellList.Add(GetCell(coord));
        }
        return cellList;
    }

    //Returns Border from BorderCoord
    public Border GetBorder(BorderCoord _borderCoord) {
        return borders[Hex.CellCubeToOffset(_borderCoord.Cube).x + 1, Hex.CellCubeToOffset(_borderCoord.Cube).y + 1][_borderCoord.Index];
    }

    //Returns Borders from BorderCoords
    public List<Border> GetBorders(List<BorderCoord> borderCoordList) {
        List<Border> borderList = new List<Border>();
        foreach (BorderCoord borderCoord in borderCoordList) {
            borderList.Add(GetBorder(borderCoord));
        }
        return borderList;
    }



    //Checks if a coord or a list of coords is inside the playarea
    public bool isValidCoord(Vector2Int _offset) {
        if (0 <= _offset.x && _offset.x < cells.GetLength(0) - 2 && 0 <= _offset.y && _offset.y < cells.GetLength(1) - 2) {
            return true;
        }
        else {
            return false;
        }
    }

    public bool isValidCoord(Vector3Int _cube) {
        return isValidCoord(Hex.CellCubeToOffset(_cube));
    }

    public bool isValidCoord(List<Vector3Int> _cubeList) {
        foreach (Vector3Int _cube in _cubeList) {
            if (!isValidCoord(_cube)) {
                return false;
            }
        }
        return true;
    }

    //Checks a list of coords to see if it has one or more coords inside the playarea.
    public bool hasValidCoord(List<Vector3Int> _cubeList) {
        foreach (Vector3Int _cube in _cubeList) {
            if (isValidCoord(_cube)) {
                return true;
            }
        }
        return false;
    }

    //Takes a border coordinate and returns its two neighboring Cells.
    public List<Cell> BorderCellNeighbors(Vector3Int _cube, int _dir) {
        List<Cell> neighborList = new List<Cell>();
        foreach (Vector3Int cube in Hex.BorderCellNeighbors(_cube, _dir)) {
            if (isValidCoord(cube))
                neighborList.Add(GetCell(cube));
        }
        return neighborList;
    }

    //Returns direction from one cell to another
    public int FindDir(Cell from, Cell to) {
        return Hex.findDir(from.CubeCoord, to.CubeCoord);
    }

    //Returns a list of Cells with a given radius from specified origin.
    public List<Cell> Ring(Vector3Int _origin, int radius) {
        List<Cell> cellList = new List<Cell>();
        foreach (Vector3Int cube in Hex.CellRing(_origin, radius)) {
            if (isValidCoord(cube)) {
                cellList.Add(GetCell(cube));
            }
        }
        return cellList;
    }

    // Returns a list of Cells within a given radius from specified
    public List<Cell> Spiral(Vector3Int _origin, int radius) {
        List<Cell> cellList = new List<Cell>();
        foreach (Vector3Int cube in Hex.CellSpiral(_origin, radius)) {
            if (isValidCoord(cube)) {
                cellList.Add(GetCell(cube));
            }
        }
        return cellList;
    }

}

