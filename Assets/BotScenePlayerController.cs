using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class BotScenePlayerController : MonoBehaviour
{
    PlayerInputManager inputs;
    [SerializeField]
    BotSceneGameManager gameManager;
    Rigidbody rb;
    [SerializeField] bool forcePlay = true;
    [SerializeField] float forwardSpeed = 1f;

    Animator anim;
    int yRef = Animator.StringToHash("Y"); // 1 ise kosar, 0 ise durur
    int xRef = Animator.StringToHash("X"); //-1 ise left, 1 ise right
    int jumpRef = Animator.StringToHash("Jump");
    int leanRef = Animator.StringToHash("Lean");

    Vector3 startingPos;

    // Start is called before the first frame update
    void Start()
    {
        inputs = GetComponent<PlayerInputManager>();
        if (gameManager == null)
            gameManager = FindObjectOfType<BotSceneGameManager>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        startingPos = transform.position;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameManager.isGamePlaying || forcePlay)
        {
            Move();
        }
        else
        {
            StopAnimations();
        }
    }
    void Move()
    {
        Vector3 nextDestination = Vector3.forward*forwardSpeed;

        nextDestination += new Vector3(inputs.leftRight(),0,0);
        rb.MovePosition(transform.position + nextDestination);
        anim.SetFloat(xRef, inputs.leftRight());
        anim.SetFloat(yRef, 1);
    }
    void StopAnimations()
    {
        anim.SetFloat(xRef, 0);
        anim.SetFloat(yRef, 0);
        anim.SetFloat(jumpRef, -1);
        anim.SetFloat(leanRef, -1);
    }
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == Constants.Tags.Obstacle)
        {
            Restart();
        }
    }
    void Restart()
    {
        rb.velocity = Vector3.zero;
        transform.position = startingPos;
        StopAnimations();
    }
}
