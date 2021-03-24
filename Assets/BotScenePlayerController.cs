using System;
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
    [SerializeField] float speedForTap = 1f;

    Animator anim;
    int yRef = Animator.StringToHash("Y"); // 1 ise kosar, 0 ise durur
    int xRef = Animator.StringToHash("X"); //-1 ise left, 1 ise right
    int jumpRef = Animator.StringToHash("Jump");
    int leanRef = Animator.StringToHash("Lean");

    Vector3 startingPos;

    bool finishLinePassed = false;
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

    void FixedUpdate()
    {
        if (gameManager.isGamePlaying || forcePlay)
        {
            Move();
        }
        else if (finishLinePassed)
        {
            Stop();
            PlayWinningAnimation();
        }
        else
        {
            StopAnimations();
        }
    }
    void Stop()
    {
        rb.velocity = Vector3.zero;
    }
    void PlayWinningAnimation()
    {
        StopAnimations();
        //    anim.SetFloat(xRef, -1);
        //    anim.SetFloat(yRef, -1);
        //    anim.SetFloat(jumpRef, -1);
        //    anim.SetFloat(leanRef, -1);
        //anim.SetFloat("Victory", 1);
    }
    void Move()
    {
        Vector3 nextDestination = Vector3.forward * forwardSpeed;

        nextDestination += Vector3.right * inputs.leftRight();

        anim.SetFloat(xRef, inputs.leftRight());
        anim.SetFloat(yRef, 1);

        try
        {

            if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
            {
                nextDestination += Vector3.forward * speedForTap;
            }
        }
        catch (Exception e)
        {
            Debug.LogWarning("There is error!" + e);
        }
        rb.MovePosition(transform.position + nextDestination);
    }
    void StopAnimations()
    {
        anim.SetFloat(xRef, 0);
        anim.SetFloat(yRef, 0);
        anim.SetFloat(jumpRef, -1);
        anim.SetFloat(leanRef, -1);
        anim.SetFloat("Victory", 0);
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == Constants.Tags.Obstacle)
        {
            Restart();
        }
        if (col.gameObject.tag == Constants.Tags.Finish)
        {
            print("finish line collision");
            gameManager.isGamePlaying = false;
            finishLinePassed = true;
            gameManager.EndGame();
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == Constants.Tags.Finish)
        {
            print("finish line trigger");
            gameManager.isGamePlaying = false;
            finishLinePassed = true;
            gameManager.EndGame();
        }
    }
    void Restart()
    {
        rb.velocity = Vector3.zero;
        transform.position = startingPos;
        StopAnimations();
    }
}
