using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour,IInputManager
{
    bool jump=false;
    bool slide = false;
    float left_right = 0f;

    Vector2 mouseDeltaPosition = Vector2.zero;
    private Vector3 lastPos = Vector3.zero;

    Touch touch;

    public bool jumpInput()
    {
        if(jump == true)
        {
            jump = false;
            return true;
        }
        return jump;
    }

    public float leftRight()
    {
        return left_right;
    }

    public bool slideInput()
    {
        if(slide == true)
        {
            slide = false;
            return true;
        }
        return slide;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetMouseDeltaPos();
        HandleLeftRight();
        SetJump();
    }
    private void SetJump()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            jump = true;
            return;
        }
        //if()TODO




    }
    private void SetMouseDeltaPos()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastPos = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            mouseDeltaPosition = Input.mousePosition - lastPos;

            lastPos = Input.mousePosition;
        }
    }

    private void HandleLeftRight()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            left_right = -1f;
            return;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow)){
            left_right = 1f;
            return;
        }
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Moved)
            {
                left_right = touch.deltaPosition.x;
            }
            return;
        }
        if (Input.GetMouseButton(0))
        {
            left_right = mouseDeltaPosition.x;
            return;
        }
        left_right = 0f;
        return;
    }











}
