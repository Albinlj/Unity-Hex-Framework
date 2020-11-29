using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class CameraController : Singleton<CameraController>
    {
        public Camera myCamera;
        public float padding;

        // Use this for initialization

        private void Start()
        {
            padding = 1;
        }

        // Update is called once per frame
        private void Update()
        {
        }

        public void UpdateCamera(int width, int heigth)
        {
            //myCamera.transform.position = new Vector3((width) * Layout.RadiusInner, (heigth + 1.5f) * Layout.RadiusInner, -1);
            //myCamera.orthographicSize = (heigth + .5f) * Layout.RadiusInner + padding;
            myCamera.ResetAspect();
        }
    }
}