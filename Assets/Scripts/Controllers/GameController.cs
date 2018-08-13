﻿using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
    public static GameController instance;

    public int roundNumber;
    public float roundTime;
    public float timeFactor = 1;
    public float timeSpeed = 1;


    private void Awake() {

        if (instance != this) {
            instance = this;
        }
        else {
            Debug.LogError("GameController singleton bug");
            Destroy(this);
        }
    }
    void Start() {


        MapController.instance.CreateRectMap(4, 3);
        Vertex.ClickedEvent += Moves.RotateVertexBorders;
        Cell.ClickedEvent += Moves.RotateCellBorders;

    }

    void Update() {
        roundTime += Time.deltaTime;
        if (roundTime > 1) {
            roundTime--;
            roundNumber++;
            NewRound();

        }
    }

    void NewRound() {
        //TrainController.instance.NewRound();
    }
}