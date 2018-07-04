using UnityEngine;
using System.Collections;

public class MapController : MonoBehaviour {
    static MapController instance;
    static HexMap activeMap;
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


    //HexMap CreateEmptyMap(int width, int height) {
    //    HexMap newMap = new HexMap();
    //    newMap.cells = new Cell[width, height];
    //    newMap.midPoint = new Vector2Int((int)Mathf.Floor(width / 2), (int)Mathf.Floor(height / 2));
    //    activeMap = newMap;
    //    return newMap;
    //}


    void CreateRectMap(int width, int height) {
        cells = new Cell[width, height];
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                GameObject newCellObj = Instantiate(cellPrefab);
                Cell newCell = newCellObj.GetComponent<Cell>();
                newCell.transform.SetParent(mapHolder.transform);
                newCell.transform.name = "Cell [" + x + ", " + y + "]";
                newCell.OffsetCoord = new Vector2Int(x, y);
                newCell.CubeCoord = 
                newCell.transform.position = Layout.offsetToWorld(new Vector2Int(x, y));
                cells[x, y] = newCell;
                //CameraController.UpdateCamera(width, height);
            }
        }
    }

    public Cell GetCell(Vector3Int _cube) {
        Vector2Int offset;
        offset = Hex.CubeToOffset(_cube);

        return cells[offset.x, offset.y];
    }

    public Cell[] GetNeighbors(Cell cell) {
        //Cell[] cellNeighbors = Hex.getNeighbors(CubeCoord).Select(cubeNeighbor => )
        //return cellNeighbors;
        return new Cell[] { };
    }

    //    void spawnhex(cell hex) {
    //        //instantiate(hexprefab, mapholder.transform);
    //    }
}
