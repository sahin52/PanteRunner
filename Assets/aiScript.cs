using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class aiScript : MonoBehaviour
{
    public NavMeshAgent agent;
    Rigidbody rb;
    Animator anim;
    Vector3 prevPos;
    [SerializeField]float animThreshold=2f;
    [SerializeField] bool isStopped;
    Vector3 startingPos;


    [SerializeField]
    BotSceneGameManager gameManager;

    int yRef = Animator.StringToHash("Y"); // 1 ise kosar, 0 ise durur
    int xRef = Animator.StringToHash("X"); //-1 ise left, 1 ise right
    int jumpRef = Animator.StringToHash("Jump");
    int leanRef = Animator.StringToHash("Lean");

    private bool finished = false;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        gameManager = FindObjectOfType<BotSceneGameManager>();
    }
    void Start()
    {
        var finishLine = GameObject.FindGameObjectWithTag(Constants.Tags.Finish);
        agent.SetDestination(finishLine.transform.position);
        prevPos = transform.position;
        startingPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameManager.isGamePlaying && !finished)
            Move();
        else
        {
            Stop();
        }
       // rb.AddForce(Vector3.up*500);
        //rb.MovePosition(Vector3.up * 1000000);
        
        //if (agent.isOnOffMeshLink && isGrounded())
        //{
        //    rb.AddForce(Vector3.up * 4500);
        //}
    //    print(prevPos + "  " + transform.position);
  //      prevPos = transform.position;
//        print(agent.isOnOffMeshLink);
    }
    void Move()
    {
        agent.isStopped = false;
        if (prevPos.z - transform.position.z > Vector3.one.z / 10f / animThreshold || prevPos.z - transform.position.z < -1 * Vector3.one.z / 10f / animThreshold)
        {
            anim.SetFloat("Y", 1);
        }
        else
        {
            anim.SetFloat("Y", 0);

        }

    }
    void Stop()
    {
        agent.isStopped = true;
        StopAnimations();
    }
    void StopAnimations()
    {
        anim.SetFloat(xRef, 0);
        anim.SetFloat(yRef, 0);
        anim.SetFloat(jumpRef, -1);
        anim.SetFloat(leanRef, -1);
    }
    bool isGrounded()
    {
        if (transform.position.y < 1 && rb.velocity.y < 0.001f)
        {
            Debug.LogWarning("grounded");
            return true;
        }
        Debug.LogWarning("not grounded");
        return false;
    }
    void OnTriggerEnter(Collider col)
    {
        if (finished)
            return;
        //print("triggered with "+ col.gameObject.tag);
        if (col.gameObject.tag == Constants.Tags.Finish)
        {
            finished = true;
            print("triggered with finishline");
            Stop();
            transform.position = transform.position + Vector3.forward * 10;
        }
        if(col.gameObject.tag == Constants.Tags.Obstacle)
        {
            Restart();
            Strengthen();
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if (finished)
            return;
        print("collided"+col.gameObject.tag);
        if(col.gameObject.tag == Constants.Tags.Obstacle)
        {
            Restart();
            Strengthen();
        }
        if(col.gameObject.tag == Constants.Tags.Finish)
        {
            finished = true;
            print("collided with finishline");
            Stop();
        }
        
    }
    void Restart()
    {
        transform.position = startingPos;
    }
    void Strengthen()
    {
        agent.angularSpeed += 10;
        agent.acceleration += 1;
    }
}
