using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Cell : MonoBehaviour {
    //private
    [SerializeField]
    private Vector2Int offsetCoord;
    [SerializeField]
    private Vector2Int axialCoord;
    [SerializeField]
    private Vector3Int cubeCoord;
    public GameObject coordUIPrefab;
    private GameObject myCoordUI;


    public Vector2Int OffsetCoord {
        get { return offsetCoord; }
        set { offsetCoord = value; }
    }
    public Vector2Int AxialCoord {
        get { return Hex.OffsetToAxial(offsetCoord); }
        private set { }
    }
    public Vector3Int CubeCoord {
        get { return Hex.OffsetToCube(offsetCoord); }
        private set { }
    }

    void UpdateCoords() {
        axialCoord = AxialCoord;
        cubeCoord = CubeCoord;
    }

    private void Start() {
        InitializeUI();

        neighbors = GetNeighbors();
    }

    private void InitializeUI() {
        GameObject coordUI = Instantiate(coordUIPrefab, transform);
        string[] letters = new string[] { "x", "y", "z" };
        for (int i = 0; i < 3; i++) {
            coordUI.transform.GetChild(i).gameObject.GetComponent<UnityEngine.UI.Text>().text = cubeCoord[i].ToString();
        }
    }

    private Cell[] neighbors;

    public Cell[] Neighbors {
        get { return neighbors; }
        private set { }
    }

    private Cell[] GetNeighbors() {
        //Cell[] cellNeighbors = Hex.getNeighbors(CubeCoord).Select(cubeNeighbor => )
        //return cellNeighbors;
        return new Cell[] { };
    }

}




