using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

[Serializable]
public class MapController : MonoBehaviour {
    public static MapController instance;
    public GameObject cellPrefab;
    public GameObject borderPrefab;
    public GameObject vertexPrefab;
    private GameObject cellHolder;
    private GameObject borderHolder;
    private GameObject vertexHolder;
    private Validator validator;

    private Map map = new Map();


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


    public void CreateRectMap(int _width, int _height) {
        validator = new Validator(_width + 2, _height + 2);
        //Creates cells, borders, and vertexes for the wanted cells, and an 
        //additional layer outside in order to get the needed Vertices and Borders.
        //Items are stored as offset in an Array where 
        map.cells = new Cell[_width + 2, _height + 2];
        map.borders = new Border[_width + 2, _height + 2][];
        map.vertices = new Vertex[_width + 2, _height + 2][];
        for (int x = 0; x < _width + 2; x++) {
            for (int y = 0; y < _height + 2; y++) {

                Vector2Int offset = new Vector2Int(x, y);
                Vector3Int cube = Hex.CellOffsetToCube(offset);

                //Instantiates a Cell
                if (validator.isValidCoord(cube)) {
                    GameObject newCellObj = Instantiate(cellPrefab);
                    Cell newCell = newCellObj.GetComponent<Cell>();
                    newCell.transform.SetParent(cellHolder.transform);
                    newCell.Initialize(new CellInfo(cube));
                }

                //Instantiates a Border if it has a neighboring Cell 
                Border[] newBorderArray = new Border[3];
                map.borders[x, y] = newBorderArray;
                for (int i = 0; i < 3; i++) {
                    if (validator.hasValidCoord(Hex.GetBorderCellNeighbors(cube, i))) {
                        GameObject newBorderObj = Instantiate(borderPrefab);
                        Border newBorder = newBorderObj.GetComponent<Border>();
                        newBorder.transform.SetParent(borderHolder.transform);
                        newBorder.Initialize(new BorderInfo(cube, i));
                    }
                }

                //Instantiates a Vertex if it has a neighboring Cell
                Vertex[] newVertexArray = new Vertex[2];
                map.vertices[x, y] = newVertexArray;
                for (int i = 0; i < 2; i++) {
                    if (validator.hasValidCoord(Hex.GetVertexCellNeighbors(cube, i))) {

                        GameObject newVertexObj = Instantiate(vertexPrefab);
                        Vertex newVertex = newVertexObj.GetComponent<Vertex>();
                        newVertex.transform.SetParent(vertexHolder.transform);
                        newVertex.Initialize(new VertexInfo(cube, i));
                    }
                }
            }
        }

        CameraController.instance.UpdateCamera(_width, _height);
        BlueprintHandler.MakeBluePrintFromMap(map);
        Serializer.SerializeBlueprint(BlueprintHandler.MakeBluePrintFromMap(map), "Test");
    }

    public void LoadBlueprint(Blueprint _blueprint) {
        foreach (CellInfo cellInfo in _blueprint.cellInfoList) {
            GameObject newCellObj = Instantiate(cellPrefab);
            Cell newCell = newCellObj.GetComponent<Cell>();
            newCell.Initialize(cellInfo);
        }
        foreach (BorderInfo borderInfo in _blueprint.borderInfoList) {
            GameObject newBorderObj = Instantiate(borderPrefab);
            Border newBorder = newBorderObj.GetComponent<Border>();
            newBorder.Initialize(borderInfo);
        }
        foreach (VertexInfo vertexInfo in _blueprint.vertexInfoList) {
            GameObject newVertexObj = Instantiate(vertexPrefab);
            Vertex newVertex = newVertexObj.GetComponent<Vertex>();
            newVertex.Initialize(vertexInfo);
        }
    }

    //Getting Cells from offsets or cubes, or a list of cubes.
    private Cell GetCell(Vector2Int _offset) {
        if (validator.isValidCoord(_offset)) {
            return map.cells[_offset.x, _offset.y];
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
        return map.borders[
                Hex.CellCubeToOffset(_borderCoord.Cube).x,
                Hex.CellCubeToOffset(_borderCoord.Cube).y
                ][
                _borderCoord.Index
                ];
    }

    //Returns Borders from BorderCoords
    public List<Border> GetBorders(List<BorderCoord> borderCoordList) {
        List<Border> borderList = new List<Border>();
        foreach (BorderCoord borderCoord in borderCoordList) {
            borderList.Add(GetBorder(borderCoord));
        }
        return borderList;
    }






    public void UpdateCoordInMap(Cell _cell) {
        Vector2Int offsetCoord = Hex.CellCubeToOffset(_cell.Coord);
        map.cells[offsetCoord.x, offsetCoord.y] = _cell;
    }

    public void UpdateCoordInMap(Border _border) {
        Vector2Int offsetCoord = Hex.CellCubeToOffset(_border.Info.Coord.Cube);
        map.borders[offsetCoord.x, offsetCoord.y][_border.Info.Coord.Index] = _border;
    }

    public void UpdateCoordInMap(Vertex _vertex) {
        Vector2Int offsetCoord = Hex.CellCubeToOffset(_vertex.Info.Coord.Cube);
        map.vertices[offsetCoord.x, offsetCoord.y][_vertex.Info.Coord.Index] = _vertex;
    }



}