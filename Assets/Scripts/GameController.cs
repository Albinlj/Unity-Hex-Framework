using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
    static GameController instance;

    void Start() {
        if (instance != this) {
            instance = this;
        }
        else {
            Debug.LogError("GameController singleton bug");
            Destroy(this);
        }
    }

    void Update() {

    }
}
