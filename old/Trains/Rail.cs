using UnityEngine;
using System.Collections;

public class Rail : MonoBehaviour {

    private Vector3Int cubeCoord;
    public Vector3Int CubeCoord {
        get { return cubeCoord; }
        private set { }
    }

    public Sprite[] sprites = new Sprite[2];
    public Path path;
    public SpriteRenderer myRenderer;
    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {

    }

    void Delete() {
        Destroy(this);
    }

    public void Initialize(Vector3Int _cube, Path _path) {
        myRenderer = transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        transform.position = Layout.CubeToWorld(_cube);
        transform.name = "Rail [" + _cube.x + ", " + _cube.y + ", " + _cube.z + "]";
        path = _path;
        cubeCoord = _cube;

        float rotation = -240 + path[0] * 60;
        transform.Rotate(0, 0, rotation);
        //Determine which sprite to be used
        switch (path.Difference) {
            case 1:
            case -5:
                myRenderer.sprite = sprites[2];
                break;
            case -1:
            case 5:
                myRenderer.sprite = sprites[2];
                myRenderer.flipX = true;
                break;

            case -4:
            case 2:
                myRenderer.sprite = sprites[1];
                break;
            case -3:
            case 3:
                myRenderer.sprite = sprites[0];
                break;
            case -2:
            case 4:
                myRenderer.sprite = sprites[1];
                myRenderer.flipX = true;
                break;
            default:
                Debug.LogError("This is not a valid path! Something went wrong.");
                break;
        }


    }



}
