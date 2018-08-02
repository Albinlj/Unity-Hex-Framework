using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
public class RailController : MonoBehaviour {

    static public RailController instance;
    private GameObject railHolder;
    public GameObject railPrefab;
    public bool isBuilding;
    public List<Cell> buildingCells = new List<Cell>();
    public List<Rail> rails = new List<Rail>();
    // Use this for initialization

    private void Awake() {
        if (instance != this) { instance = this; }
        else { Debug.LogError("RailController singleton bug"); }

    }

    void Start() {

        railHolder = new GameObject("RailHolder");
        railHolder.transform.SetParent(this.transform);
        Cell.ClickedEvent += OnMouseDown;
        Cell.EnterEvent += OnMouseEnter;
        Cell.ExitEvent += OnMouseExit;
        Cell.UpEvent += OnMouseUp;


    }


    private void OnMouseDown(Cell cell) {
        StartBuilding(cell);
    }

    private void OnMouseEnter(Cell cell) {
        if (isBuilding) {
            buildingCells.Add(cell);
            int count = buildingCells.Count;
            if (count > 2) {
                Debug.Log("Time to build!");
                Cell fromCell = buildingCells[count - 3];
                Cell buildCell = buildingCells[count - 2];
                Cell toCell = buildingCells[count - 1];
                int dir1 = MapController.instance.FindDir(buildCell, fromCell);
                int dir2 = MapController.instance.FindDir(buildCell, toCell);
                Path path = new Path(dir1, dir2);

                if (path.IsValid || true) {
                    Debug.Log("Building with path " + path[0] + ", " + path[1]);
                    SpawnRail(buildCell.Coord, path);
                }
                else {
                    buildingCells = buildingCells.GetRange(count - 2, 2);
                }
            }
        }
    }

    private void OnMouseExit(Cell cell) {

    }

    public void DeleteAllRails() {
        foreach (Rail rail in rails) {
            Destroy(rail.gameObject);

        }
        rails.Clear();
    }

    private void OnMouseUp(Cell cell) {
        StopBuilding();
    }
    // Update is called once per frame
    void Update() {

    }

    private void StartBuilding(Cell cell) {
        isBuilding = true;
        buildingCells.Add(cell);

    }
    private void StopBuilding() {
        isBuilding = false;
        buildingCells.Clear();
    }


    void SpawnRail(Vector3Int cube, Path path) {
        GameObject newRailObj = Instantiate(railPrefab);
        Rail newRail = newRailObj.GetComponent<Rail>();
        newRail.transform.SetParent(railHolder.transform);
        newRail.Initialize(cube, path);
        rails.Add(newRail);
    }
}
