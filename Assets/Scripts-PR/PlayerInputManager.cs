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

    private bool isThereTouchOnScreen = false;
    Touch touch;
    float touchStart;


    bool isMouseDown=false;

    float mouseStart;

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
        HandleLeftRight();//DONE
        SetJumpAndSlide();
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
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            left_right = -1f;
            return;
        }
        else if (Input.GetKey(KeyCode.RightArrow)){
            left_right = 1f;
            return;
        }
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Moved)
            {
                left_right = touch.deltaPosition.x / Screen.width * 5;
            }
            return;
        }
        if (Input.GetMouseButton(0))
        {
            left_right = mouseDeltaPosition.x / Screen.width * 5;
            return;
        }
        left_right = 0f;
        return;
    }

    private void SetJumpAndSlide()
    {
        //Getting from keyboard
        if (Input.GetKey(KeyCode.UpArrow))
        {
            jump = true;
            return;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            slide = true;
            return;
        }

        //Getting from screen touch
        if (!isThereTouchOnScreen && Input.touchCount > 0)
        {
            isThereTouchOnScreen = true;
            this.touch = Input.GetTouch(0);
            touchStart = this.touch.position.y;
            return;
        }
        if (isThereTouchOnScreen && (Input.touchCount == 0))
        {
            isThereTouchOnScreen = false;
            if (this.touch.position.y - touchStart > 100f)
            {
                jump = true;
            }
            if (this.touch.position.y - touchStart < -100f)
            {
                slide = true;
            }
            return;
        }


        //Getting from mouse input

        if (!isMouseDown && Input.GetMouseButton(0))
        {
            mouseStart = Input.mousePosition.y;
            isMouseDown = true;
            return;
        }

        if (isMouseDown && !Input.GetMouseButton(0))
        {
            isMouseDown = false;
            if (Input.mousePosition.y - mouseStart > 100f)
            {
                jump = true;
            }
            if (Input.mousePosition.y - mouseStart < -100f)
            {
                slide = true;
            }
            return;
        }
    }
    








}
