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
