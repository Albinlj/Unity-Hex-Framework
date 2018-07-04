using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    static CameraController instance;
    static public Camera myCamera;



    // Use this for initialization
    void Start() {
        if (instance != this) {
            instance = this;
        }
        else {
            Debug.LogError("CameraController tried to start another instance");
        }
    }

    // Update is called once per frame
    void Update() {

    }

    public static void UpdateCamera(int width, int heigth) {
        myCamera.orthographicSize = 1;

    }
}
