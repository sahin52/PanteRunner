using UnityEngine;

public class tempPaintScript : MonoBehaviour
{
    private Camera cam;
    public Texture2D filterTexture;
    void Start()
    {
        cam = Camera.main;
        Clear();
    }

    void Update()
    {
        Paint();
    }



    void Clear()
    {
        Renderer rend = GetComponent<Renderer>();
        Texture2D tex = rend.material.mainTexture as Texture2D;
        var pixels = tex.GetPixels();
        var len = pixels.Length;
        for(int i = 0; i < len; i++)
        {
            pixels[i] = Color.white;
        }
        tex.SetPixels(pixels);
        tex.Apply();
    }


    void Paint()
    {
        if (Input.touchCount == 0)
            return;

        RaycastHit hit;
        var touch = Input.GetTouch(0);

        if (!Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit))
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
        paintAroundPixel(ref tex, ref pixelUV);
    }

    private void paintAroundPixel(ref Texture2D tex,ref  Vector2 pixelUV)
    {
        var pixels = tex.GetPixels();
        var width = tex.width;
        var height = tex.height;

        for(int i = 0; i < filterTexture.width; i++)
        {
            for(int j = 0; j < filterTexture.height; j++)
            {
                pixels[width * i + height] = Color.red;
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
