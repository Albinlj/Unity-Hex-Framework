using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

public class MapController : MonoBehaviour {
    public static MapController instance;
    public static int radius;
    public GameObject cellPrefab;
    private GameObject mapHolder;
    public Cell[,] cells;
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
        mapHolder = new GameObject("MapHolder");
        mapHolder.transform.SetParent(this.transform);

        CreateRectMap(16, 9);

        //CameraController.UpdateCamera();

    }

    // Update is called once per frame
    void Update() {

    }



    void CreateRectMap(int _width, int _height) {
        cells = new Cell[_width, _height];
        for (int x = 0; x < _width; x++) {
            for (int y = 0; y < _height; y++) {
                GameObject newCellObj = Instantiate(cellPrefab);
                Cell newCell = newCellObj.GetComponent<Cell>();
                newCell.transform.SetParent(mapHolder.transform);
                newCell.Initialize(new Vector2Int(x, y));
                cells[x, y] = newCell;
            }
            //CameraController.UpdateCamera(width, height);
        }


    }


    //Getting Cells
    public Cell GetCell(Vector3Int _cube) {
        return GetCell(Hex.CubeToOffset(_cube));
    }

    private Cell GetCell(Vector2Int _offset) {
        if (isValidCoord(_offset)) {
            return cells[_offset.x, _offset.y];
        }
        else {
            Debug.LogError("Can't get Cell, it is out of bounds! Coords was " + _offset.x + ", " + _offset.y);
            return null;
        }
    }

    public bool isValidCoord(Vector3Int _cube) {
        return isValidCoord(Hex.CubeToOffset(_cube));

    }

    public bool isValidCoord(Vector2Int _offset) {
        if (0 <= _offset.x && _offset.x < cells.GetLength(0) && 0 <= _offset.y && _offset.y < cells.GetLength(1)) {
            return true;
        }
        else {
            return false;
        }
    }


    //Getting neighboring Cells


    public List<Cell> Ring(Vector3Int _origin, int radius) {
        List<Cell> cellList = new List<Cell>();
        foreach (Vector3Int cube in Hex.Ring(_origin, radius)) {
            if (isValidCoord(cube)) {
                cellList.Add(GetCell(cube));
            }
        }
        return cellList;
    }

    public List<Cell> Spiral(Vector3Int _origin, int radius) {
        List<Cell> cellList = new List<Cell>();
        foreach (Vector3Int cube in Hex.Spiral(_origin, radius)) {
            if (isValidCoord(cube)) {
                cellList.Add(GetCell(cube));
            }
        }
        return cellList;
    }


}

