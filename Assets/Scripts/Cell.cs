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
        //InitializeUI();
        polyCollider = gameObject.GetComponent<PolygonCollider2D>();
        //neighbors = MapController.instance.GetNeighborCells(CubeCoord);
    }

    private void OnMouseDown() {
        Debug.Log(CubeCoord);
    }

    public void Initialize(Vector3Int _cube) {
        transform.name = "Cell [" + _cube.x + ", " + _cube.y + ", " + _cube.z + "]";
        cubeCoord = _cube;
        transform.position = Layout.CubeToWorld(_cube);
    }

    private void InitializeUI() {
        GameObject coordUI = Instantiate(coordUIPrefab, transform);

        for (int i = 0; i < 3; i++) {
            coordUI.transform.GetChild(i).gameObject.GetComponent<UnityEngine.UI.Text>().text = cubeCoord[i].ToString();
        }
    }

    public Cell Neighbor(int _dir) {
        return MapController.instance.GetCell(Hex.Neighbor(cubeCoord, _dir));
    }


}