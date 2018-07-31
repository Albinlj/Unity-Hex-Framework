using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public static CameraController instance;
    public Camera myCamera;
    public float padding;


    // Use this for initialization
    private void Awake() {

        if (instance != this) {
            instance = this;
        }
        else {
            Debug.LogError("CameraController tried to start another instance");
        }
    }
    void Start() {
    }

    // Update is called once per frame
    void Update() {

    }


    public void UpdateCamera(int width, int heigth) {
        myCamera.transform.position = new Vector3((width - 1) * Layout.RadiusInner, (heigth - 0.5f) * Layout.RadiusInner, -1);
        myCamera.orthographicSize = (heigth - 1.5f) * Layout.RadiusInner + padding;
        myCamera.ResetAspect();
    }
}
