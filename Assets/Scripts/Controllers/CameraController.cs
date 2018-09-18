using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : Singleton<CameraController> {
    public Camera myCamera;
    public float padding;


    // Use this for initialization

    void Start() {
        padding = Layout.RadiusInner;
    }

    // Update is called once per frame
    void Update() {

    }

    public void UpdateCamera(int width, int heigth) {
        myCamera.transform.position = new Vector3((width) * Layout.RadiusInner, (heigth + 1.5f) * Layout.RadiusInner, -1);
        myCamera.orthographicSize = (heigth + .5f) * Layout.RadiusInner + padding;
        myCamera.ResetAspect();
    }
}
