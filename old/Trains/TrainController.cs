using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class TrainController : MonoBehaviour {

    static public TrainController instance;
    public GameObject trainPrefab;
    public GameObject trainHolder;
    public List<Train> trains = new List<Train>();

    // Use this for initialization
    private void Awake() {

        if (instance == null) {
            instance = this;
        }
        else {
            Debug.LogError("TrainController singleton bug");
        }
        trainHolder = new GameObject("TrainHolder");
        trainHolder.transform.SetParent(this.transform);

    }
    void Start() {
        //SpawnTrain(Vector3Int.zero, new Path(4, 1));
    }

    // Update is called once per frame
    void Update() {



    }

    public void SpawnTrain(Vector3Int _cube, Path _path) {
        GameObject newTrainObj = Instantiate(trainPrefab);

        Train newTrain = newTrainObj.GetComponent<Train>();
        newTrain.path = _path;
        newTrain.transform.SetParent(trainHolder.transform);
        newTrain.Initialize(_cube, _path);
    }
    public void NewRound() {

    }
}
