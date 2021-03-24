using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class tempControl : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 20f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = Vector3.zero;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            newPos += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            newPos += Vector3.back;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            newPos += Vector3.left;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            newPos += Vector3.right;
        }
        newPos *= Time.deltaTime;
        newPos *= speed;
        rb.MovePosition(transform.position + newPos);
    }

    void OnTriggerEnter(Collider other)
    {
        print("triggered "+other.gameObject.tag);
    }
}
