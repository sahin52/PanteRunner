using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class horizontalObstacleScript : MonoBehaviour,IGameManagement
{
    private bool isToLeft = false;
    [SerializeField] private float speed = 1f;

    bool mustMove = false;


    private float direction;
    private Vector3 startingPos;
    private Rigidbody rb;
    

    //time to return back
    [SerializeField] private float time = 1f;
    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
        rb = GetComponent<Rigidbody>();
        direction = isToLeft ? 1 : -1;
    }
    
    void FixedUpdate()
    {
        if(mustMove)
            rb.MovePosition((Vector3.left * direction * speed) + transform.position);
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

    public void OnStart()
    {
        mustMove = false;
        //throw new System.NotImplementedException();
    }

    public void OnPlay()
    {
        mustMove = true;
        //   throw new System.NotImplementedException();
    }

    public void OnPause()
    {
        mustMove = false;
        //throw new System.NotImplementedException();
    }

    public void OnLose()
    {
        mustMove = false;
        //throw new System.NotImplementedException();
    }

    public void OnFinish()
    {
        mustMove = false;
        //throw new System.NotImplementedException();
    }

    public void OnFinishLinePassed()
    {
        //mustMove = false;
        //throw new System.NotImplementedException();
    }
}
