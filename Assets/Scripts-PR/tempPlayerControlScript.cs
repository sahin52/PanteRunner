using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempPlayerControlScript : MonoBehaviour,IGameManagement
{
    Animator anim;
    Rigidbody rb;
    private float horizontalSpeed = 1f;
    private readonly float forwardSpeed = 1f;
    private float upwardsSpeed = 500f;
    int yRef = Animator.StringToHash("Y"); // 1 ise kosar, 0 ise durur
    int xRef = Animator.StringToHash("X"); //-1 ise left, 1 ise right
    int jumpRef = Animator.StringToHash("Jump");
    int leanRef = Animator.StringToHash("Lean");

    List<GameObject> currentCollisions = new List<GameObject>();


    PR_GameManager gameManager;
    private IInputManager playerInputs;
    void Awake()
    {
        playerInputs = GetComponent<IInputManager>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        gameManager = FindObjectOfType<PR_GameManager>();
    }
    void Start()
    {
        
        //anim.SetFloat("Y" ,1);
    }
    void OnTriggerEnter(Collider triggeringCollider)
    {
        if (triggeringCollider.tag == Constants.Tags.Finish)
        {
            gameManager.onFinish();
            print("finished");
        }
    }
    void OnCollisionEnter(Collision col)
    {
        print("collided with " + col.collider.tag);
        if (col.collider.tag == Constants.Tags.Obstacle)
        {
            print("collided");
            gameManager.onLose();
        }
        else
        {
            if(!currentCollisions.Contains(col.gameObject))
                currentCollisions.Add(col.gameObject);
        }
    }
    void OnCollisionExit(Collision col)
    {
        if(currentCollisions.Contains(col.gameObject))
            currentCollisions.Remove(col.gameObject);
    }

    public void OnFinish()
    {
        anim.enabled = true;
        StopAnimations();
        print("Player Controller On Finish");

    }

    public void OnLose()
    {
        anim.enabled = true;
        StopAnimations();
    }

    private void StopAnimations()
    {
        anim.SetFloat(xRef, 0);
        anim.SetFloat(yRef, 0);
        anim.SetFloat(jumpRef, -1);
        anim.SetFloat(leanRef, -1);
    }

    public void OnPause()
    {
        anim.enabled = false;
    }

    public void OnPlay()
    {
        anim.enabled = true;
        anim.SetFloat(yRef,0);
    }

    public void OnStart()
    {
        anim.enabled = true;
        StopAnimations();
    }

    // Start is called before the first frame update

    void FixedUpdate()
    {
        if (gameManager.gameStarted)
        {
            Move();
        }
    }
    private void Move()
    {
        if (playerInputs.jumpInput() && currentCollisions.Count > 0) // TODO check if is grounded
        {
            print("entered jump");
            rb.AddForce(Vector3.up * upwardsSpeed);
            anim.SetFloat(jumpRef, 1);
            var stopJump = StopAnimAfterJump(0.5f);
            StartCoroutine(stopJump);
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            //touched
            print("touched");
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                var deltaPos = touch.deltaPosition;

                if (deltaPos.x < 0)
                {
                    rb.MovePosition(new Vector3(touch.deltaPosition.x, 0, 0) * horizontalSpeed / Screen.width + transform.position + Vector3.forward * forwardSpeed);
                    anim.SetFloat(xRef, -1);
                    print("sol");
                }
                else
                {
                    rb.MovePosition(new Vector3(touch.deltaPosition.x, 0, 0) * horizontalSpeed / Screen.width + transform.position + Vector3.forward * forwardSpeed);
                    anim.SetFloat(xRef, 1);
                    print("sag");
                }
            }
        }
        else
        {
            print("not touched");
            rb.MovePosition(Vector3.forward * forwardSpeed + transform.position);
            anim.SetFloat(xRef, 0);
        }

    }

    private IEnumerator StopAnimAfterJump(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        anim.SetFloat(jumpRef, -1);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
