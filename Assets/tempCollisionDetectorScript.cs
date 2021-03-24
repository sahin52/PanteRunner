using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempCollisionDetectorScript : MonoBehaviour
{
    public BoxCollider forward;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        rb.MovePosition(transform.position + Vector3.forward * 1);
    }
    void OnTriggerEnter(Collider col)
    {
        print("triggered " + col.gameObject.tag);
        rb.AddForce(Vector3.up*250);
    }
    void OnCollisionEnter(Collision col)
    {
        print("collided " + col.gameObject.tag);
    }
}
