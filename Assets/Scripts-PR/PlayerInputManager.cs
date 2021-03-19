using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour,IInputManager
{
    bool jump=false;
    bool slide = false;
    float left_right = 0f;

    public bool jumpInput()
    {
        return jump;
    }

    public float leftRight()
    {
        return left_right;
    }

    public bool slideInput()
    {
        return slide;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
