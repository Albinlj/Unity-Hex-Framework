using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public abstract class Piece : MonoBehaviour {

    //static public event Action<Piece> PieceClickedEvent;
    //static public event Action<Piece> PieceMovedEvent;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }


    public Color Color {
        get { return Coloring.GetColor(gameObject); }
        set { Coloring.ChangeColor(this.gameObject, value); }
    }




}
