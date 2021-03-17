using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintScript : MonoBehaviour
{
    // Start is called before the first frame update
    int width = 384, height = 512;
    Texture2D texture;
    SpriteRenderer spriteRenderer;
    void Start()
    {
        CreateTexture();
    }

    private void CreateTexture()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        texture = new Texture2D(width, height);
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                texture.SetPixel(i, j, Color.red);
            }
        }
        texture.Apply();
        GetComponent<SpriteRenderer>().sprite = Sprite.Create(texture, new Rect(0, 0, width, height), new Vector2(0.5f, 0.5f));
    }

    // Update is called once per frame
    void Update()
    {
        print("slem");
       Paint();
    }
    
    void Paint()
    {
        if (Input.touchCount > 0)
        {
            //touched
            var touch = Input.GetTouch(0);
            int a = 128;
            var pixels = texture.GetPixels();
            for(int i = 0; i < a; i++)
            {
                for(int j = 0; j < a; j++)
                {
                    texture.SetPixel(i, j, Color.black);
                }
            }
            texture.Apply();
            GetComponent<SpriteRenderer>().sprite = Sprite.Create(texture, new Rect(0, 0, width, height), new Vector2(0.5f, 0.5f));


        }
    }
    void OnMouseUp()
    {
        print("mouse up");
    }
}
