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
    void Start() {
        if (instance != this) {
            instance = this;
        }
        else {
            Debug.LogError("MapController singleton bug");
            Destroy(this);
        }

        new GameObject();
        cellHolder = new GameObject("CellHolder");
        cellHolder.transform.SetParent(this.transform);
        borderHolder = new GameObject("BorderHolder");
        borderHolder.transform.SetParent(this.transform);
        vertexHolder = new GameObject("vertexHolder");
        vertexHolder.transform.SetParent(this.transform);

        CreateRectMap(6, 5);

        //CameraController.UpdateCamera();

    }

    // Update is called once per frame
    void Update() {

    }



    void CreateRectMap(int _width, int _height) {

        cells = new Cell[_width + 2, _height + 2];
        borders = new Border[_width + 2, _height + 2][];
        vertices = new Vertex[_width + 2, _height + 2][];
        for (int x = 0; x < _width + 2; x++) {
            for (int y = 0; y < _height + 2; y++) {

                Vector2Int offset = new Vector2Int(x - 1, y - 1);
                Vector3Int cube = Hex.CellOffsetToCube(offset);

                if (isValidCoord(cube)) {
                    GameObject newCellObj = Instantiate(cellPrefab);
                    Cell newCell = newCellObj.GetComponent<Cell>();
                    newCell.transform.SetParent(cellHolder.transform);
                    newCell.Initialize(cube);
                    cells[x, y] = newCell;
                }

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


    //Getting Cells from offset or cube coordinates, or a list of cubes.
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

    public List<Cell> GetCell(List<Vector3Int> list) {
        List<Cell> cellList = new List<Cell>();
        foreach (Vector3Int coord in list) {
            cellList.Add(GetCell(coord));
        }
        return cellList;
    }

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

    public bool hasValidCoord(List<Vector3Int> _cubeList) {
        foreach (Vector3Int _cube in _cubeList) {
            if (isValidCoord(_cube)) {
                return true;
            }
        }
        return false;
    }

    public List<Cell> BorderCellNeighbors(Vector3Int _cube, int _dir) {
        List<Cell> neighborList = new List<Cell>();
        foreach (Vector3Int cube in Hex.BorderCellNeighbors(_cube, _dir)) {
            if (isValidCoord(cube))
                neighborList.Add(GetCell(cube));
        }
        return neighborList;
    }




    public List<Cell> Ring(Vector3Int _origin, int radius) {
        List<Cell> cellList = new List<Cell>();
        foreach (Vector3Int cube in Hex.CellRing(_origin, radius)) {
            if (isValidCoord(cube)) {
                cellList.Add(GetCell(cube));
            }
        }
        return cellList;
    }

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

