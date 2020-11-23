using UnityEngine;

namespace Assets.Scripts
{
    public class Coloring
    {
        public static Color RandomizeColor(GameObject gameObject)
        {
            Color newColor;
            //newColor = Random.ColorHSV(0f, 1f, 0.5f, 0.5f, 0.8f, 1f);

            switch (Random.Range(0, 3))
            {
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
            ChangeColor(gameObject, newColor);
            return newColor;
        }

        public static void ChangeColor(GameObject gameObject, Color color)
        {
            var renderer = gameObject.GetComponentInChildren<SpriteRenderer>();
            if (renderer == null) return;
            renderer.color = color;
        }

        public static Color GetColor(GameObject gameObject)
        {
            var renderer = gameObject.GetComponentInChildren<SpriteRenderer>();
            if (renderer != null) return renderer.color;

            Debug.Log("Trying to GetColor from GO without renderer");
            return Color.grey;
        }
    }
}