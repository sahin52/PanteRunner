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
        width = (int)GetComponent<SpriteRenderer>().sprite.texture.width; //Screen.width*2/5;
        height = (int)GetComponent<SpriteRenderer>().sprite.texture.height; //Screen.height*2/5;
        texture = GetComponent<SpriteRenderer>().sprite.texture;

        //CreateTexture();
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
        //print("slem");
       Paint();
    }
    
    void Paint()
    {
        if (Input.touchCount > 0)
        {
            //RaycastHit hit;
            //if (!Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            //{
            //    print("didn't touch anything!");
            //    return;
            //}
            //Renderer rend = hit.transform.GetComponent<Renderer>();
            //MeshCollider meshCollider = hit.collider as MeshCollider;

            //if (rend == null || rend.sharedMaterial == null || rend.sharedMaterial.mainTexture == null || meshCollider == null)
            //{
            //    print("bisiler null");

            //    return;
            //}

            //Texture2D tex = rend.material.mainTexture as Texture2D;
            //Vector2 pixelUV = hit.textureCoord;
            //pixelUV.x *= tex.width;
            //pixelUV.y *= tex.height;
            //tex.SetPixel((int)pixelUV.x, (int)pixelUV.y, Color.black);
            //tex.Apply();


            //touched
            var touch = Input.GetTouch(0);
            int a = 128;
            var pixels = texture.GetPixels();
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < a; j++)
                {
                    texture.SetPixel(i, j, Color.black);
                }
            }
            texture.Apply();
            GetComponent<SpriteRenderer>().sprite = Sprite.Create(texture, new Rect(0, 0, width, height), new Vector2(0.5f, 0.5f));

            print("en sondayim");
        }
    }
    void OnMouseUp()
    {
        print("mouse up");
    }
}
