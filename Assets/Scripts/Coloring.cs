using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coloring {

    public static void RandomizeColor(GameObject _gameObject) {
        SpriteRenderer renderer = _gameObject.GetComponentInChildren<SpriteRenderer>();
        if (renderer != null) {
            RandomizeColor(renderer);
        }


    }

    public static void RandomizeColor(SpriteRenderer _renderer) {
        Color newColor;
        newColor = Random.ColorHSV(0f, 1f, 0.5f, 0.5f, 0.8f, 1f);

        switch (Random.Range(0, 3)) {
            case 0:
                newColor = Color.HSVToRGB(0 / 3f, 0.5f, 1);
                break;
            case 1:
                newColor = Color.HSVToRGB(1 / 6f, 0.5f, 1);
                break;
            case 2:
                newColor = Color.HSVToRGB(2 / 3f, 0.5f, 1);
                break;

            default:
                newColor = Color.grey;
                break;
        }
        newColor.a = Random.Range(0, 5) > 2 ? 0 : 1;
        _renderer.color = newColor;
    }


}


