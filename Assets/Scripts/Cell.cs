using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Cell : MonoBehaviour {

    [SerializeField]
    private Vector3Int cubeCoord;

    public GameObject coordUIPrefab;
    private PolygonCollider2D polyCollider;
    private MapController mapController = MapController.instance;
    public Vector2Int OffsetCoord {
        get { return Hex.CellCubeToOffset(cubeCoord); }
        private set { }
    }
    public Vector2Int AxialCoord {
        get { return Hex.CellCubeToAxial(cubeCoord); }
        private set { }
    }
    public Vector3Int CubeCoord {
        get { return cubeCoord; }
        private set { }
    }


    private void Start() {
        InitializeUI();
        polyCollider = gameObject.GetComponent<PolygonCollider2D>();
        //neighbors = MapController.instance.GetNeighborCells(CubeCoord);
    }

    private void OnMouseDown() {
        Debug.Log(CubeCoord);
    }

    public void Initialize(Vector2Int _offset) {
        transform.name = "Cell [" + _offset.x + ", " + _offset.y + "]";
        cubeCoord = Hex.CellOffsetToCube(_offset);
        transform.position = Layout.CellOffsetToWorld(_offset);
    }

    private void InitializeUI() {
        GameObject coordUI = Instantiate(coordUIPrefab, transform);

        for (int i = 0; i < 3; i++) {
            coordUI.transform.GetChild(i).gameObject.GetComponent<UnityEngine.UI.Text>().text = cubeCoord[i].ToString();
        }
    }

    public Cell GetNeighbor(int _dir) {
        return MapController.instance.GetCell(cubeCoord + Hex.cellDirections[_dir]);
    }


}