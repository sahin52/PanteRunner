using System;
using UnityEngine;

public class PaintableCubeScript : MonoBehaviour
{
    private Camera cam;
    public Texture2D filterTexture;
    Color[] pixels;
    void Start()
    {
        cam = Camera.main;
        Clear();

    }
    //void FixedUpdate() 
    //{
    //    //Paint();
    //    //print(CalculatePercentage());
    //}
    void Update()
    {
        Paint();
        print(CalculatePercentage());
    }

    public float CalculatePercentage()
    {
        var len = pixels.Length;
        int reds = 0;
        for(int i = 0; i < len; i++)
        {
            if (pixels[i] == Color.red)
            {
                reds++;
            }
        }
        return (float)reds / (float)len;
        //throw new NotImplementedException();
    }

    public void Clear()
    {
        Renderer rend = GetComponent<Renderer>();
        Texture2D tex = rend.material.mainTexture as Texture2D;
        pixels = tex.GetPixels();
        var len = pixels.Length;
        for(int i = 0; i < len; i++)
        {
            pixels[i] = Color.white;
        }
        tex.SetPixels(pixels);
        tex.Apply();
    }

    Vector2 getInputPoint()
    {
        if (Input.touchCount > 0)
        {
            print("there is touch");
            return Input.GetTouch(0).position;
        }
        if (Input.GetMouseButton(0))
        {
            print("there is mouse button down");
            return Input.mousePosition;
        }
        print("no input");
        return Vector2.zero;
    }
    void Paint()
    {
        print("painting");
        var inputPoint = getInputPoint();
        if(inputPoint.x == Vector2.zero.x && inputPoint.y == Vector2.zero.y)
        {
            print("no input");
            return;
        }
        RaycastHit hit;

        if (!Physics.Raycast(cam.ScreenPointToRay(inputPoint), out hit))
        {
            print("didnt hit");
            return;
        }


        Renderer rend = hit.transform.GetComponent<Renderer>();
        MeshCollider meshCollider = hit.collider as MeshCollider;

        if (rend == null || rend.sharedMaterial == null || rend.sharedMaterial.mainTexture == null || meshCollider == null)
        {
            print("bisi nulldidnt hit");
            print(rend);
            print(rend.sharedMaterial);
            print(rend.sharedMaterial.mainTexture);
            print(meshCollider);

            return;
        }


        Texture2D tex = rend.material.mainTexture as Texture2D;
        Vector2 pixelUV = hit.textureCoord;
        pixelUV.x *= tex.width;
        pixelUV.y *= tex.height;
        //paintPixel(tex, pixelUV);
        PaintAroundPixel(ref tex, ref pixelUV);
        //PaintWithFilter(tex,pixelUV);
    }

    private void PaintWithFilter(Texture2D tex, Vector2 pixelUV)
    {

        //var biint = pixelX - filterWidth / 2;
        //throw new NotImplementedException();
    }

    private void PaintAroundPixel(ref Texture2D tex,ref  Vector2 pixelUV)
    {
        print("Paint Arund Pixel");
        pixels = tex.GetPixels();
        
        
        var texWidth = tex.width;
        var texHeight = tex.height;
        var filterWidth = filterTexture.width;
        var filterHeight = filterTexture.height;

        var pixelX = (int)pixelUV.x;
        var pixelY = (int)pixelUV.y;

        var startingPos = pixelX-filterWidth;

        for (int i = Mathf.Max(pixelX-filterWidth/2,0); i < Mathf.Min(pixelX -filterWidth/2+filterWidth,texWidth); i++)
        {
            for(int j = Mathf.Max(pixelY - filterHeight/2,0); j < filterHeight + pixelY -filterHeight/2 && j<texHeight; j++)
            {
                //try
                //{
                pixels[texWidth * j + i] = Color.red;
                //}
                //catch (Exception)
                //{

                //}
            }
        }
        //for(int i =(int) Mathf.Clamp((int)pixelUV.x- filterTexture.width, 0, tex.width); i < Mathf.Clamp((int)pixelUV.x + filterTexture.width, 0, tex.width); i++)
        //{

        //}
        tex.SetPixels(pixels);
        //tex.SetPixel((int)pixelUV.x, (int)pixelUV.y, Color.red);
        tex.Apply();
        print("applied");
    }
    private void paintPixel(Texture2D tex, Vector2 pixelUV)
    {
        tex.SetPixel((int)pixelUV.x, (int)pixelUV.y, Color.red);
        tex.Apply();
    }
}
