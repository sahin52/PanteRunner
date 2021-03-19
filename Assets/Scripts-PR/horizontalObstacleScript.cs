using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class horizontalObstacleScript : MonoBehaviour
{
    [SerializeField] private bool isToLeft = false;
    private float direction;
    private Vector3 startingPos;
    private Rigidbody rb;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float time;
    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
        rb = GetComponent<Rigidbody>();
        time = 1f;
        direction = isToLeft ? 1 : -1;
    }
    
    void FixedUpdate()
    {
        rb.position = (Vector3.left * direction * speed)+transform.position;
    }
    void Update()
    {
        int timeAsSecond = (int)Time.time;
        if (timeAsSecond % 2 == 1)
        {
            direction = 1f;
        }
        else
        {
            direction = -1f;
        }
    }
}
