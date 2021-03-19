using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempPlayerControlScript : MonoBehaviour
{
    Animator anim;
    Rigidbody rb;
    float lastTimeJumped;
    [SerializeField]
    float leftRightSpeed = 1f,forwardSpeed = 10000f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        anim.SetFloat("Y" ,1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            var touch = Input.GetTouch(0);
            anim.SetFloat("X",Mathf.Clamp(touch.deltaPosition.x, -1, 1));
            rb.MovePosition(transform.position + new Vector3(touch.deltaPosition.x, 0, 0)*leftRightSpeed + Vector3.forward * forwardSpeed);
        }
        else
        {
            anim.SetFloat("X",0);
            rb.MovePosition(transform.position + Vector3.forward * forwardSpeed);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            rb.AddForce(Vector3.up*350);
            anim.SetFloat("Jump", 1);
            return;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetFloat("Jump", -1);
            return;
        }
    }
}
