using UnityEngine;

public class PerlinNoise : MonoBehaviour {
    public int width = 256;     
    public int height = 256;   

    public float Scale = 20;    //The higher it is, the more it zooms out

    public float offsetX = 100;
    public float offsetY = 100;

    Renderer renderer;

    public void Start()
    {
        renderer = GetComponent<Renderer>();   //get the compononent "Renderer" and set it to a var named renderer
    }

    void Update()
    {
        renderer.material.mainTexture = GenerateTexture();      //set the main texture to whatever the function "GenerateTexture" returns
    }

    Texture2D GenerateTexture()
    {
        Texture2D texture = new Texture2D(width, height);

        for (int x = 0; x < 256; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Color color = CalculateColor(x, y);
                texture.SetPixel(x, y, color);
            }
        }

        texture.Apply();
        return texture;
    }

    Color CalculateColor(int x, int y)
    {
        float xCord = (float)x / width * Scale * offsetX;
        float yCord = (float)y / height * Scale * offsetY;

        //"Perlin Noise does not deal with whole numbers when it comes to generating. it's either between 0 and 1.

        float sample = Mathf.PerlinNoise(xCord, yCord);
        return new Color(sample, sample, sample);

    }

}
