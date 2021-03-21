using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerControlScript : MonoBehaviour,IGameManagement
{
    Animator anim;
    Rigidbody rb;
    BoxCollider boxCollider;

    private float horizontalSpeed = 3f;
    private readonly float forwardSpeed = 0.5f;
    public float upwardsSpeed = 300f;
    int yRef = Animator.StringToHash("Y"); // 1 ise kosar, 0 ise durur
    int xRef = Animator.StringToHash("X"); //-1 ise left, 1 ise right
    int jumpRef = Animator.StringToHash("Jump");
    int leanRef = Animator.StringToHash("Lean");

    List<GameObject> currentCollisions = new List<GameObject>();

    Vector3 startingPos;
    Vector3 initialBoxColliderSize;
    Vector3 slidingBoxColliderSize;

    PR_GameManager gameManager;
    private IInputManager playerInputs;
    void Awake()
    {
        playerInputs = GetComponent<IInputManager>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        gameManager = FindObjectOfType<PR_GameManager>();
        boxCollider = GetComponent<BoxCollider>();
        initialBoxColliderSize = boxCollider.size;
        slidingBoxColliderSize = new Vector3(initialBoxColliderSize.x, initialBoxColliderSize.y / 2f, initialBoxColliderSize.z);
    }
    void Start()
    {
        startingPos = transform.position;
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
        transform.position = startingPos;
        StopAnimations();
    }

    // Start is called before the first frame update

    void FixedUpdate()
    {
        if (gameManager.gameStarted)
        {
            Move();
        }
        else
        {
            StopAnimations();
        }
    }
    private void Move()
    {
        if (playerInputs.jumpInput() && isGrounded()) // TODO check if is grounded
        {
            print("entered jump");
            rb.AddForce(Vector3.up * upwardsSpeed);
            anim.SetFloat(jumpRef, 1);
            var stopJump = StopAnimAfterJump(1f);
            StartCoroutine(stopJump);
        }
        if (playerInputs.slideInput() && isGrounded())
        {
            anim.SetFloat(leanRef, 1);
            boxCollider.size = slidingBoxColliderSize;
            var stopLean = StopAnimAfterLean(0.8f);
            StartCoroutine(stopLean);
        }
        rb.MovePosition(Vector3.forward*forwardSpeed + transform.position + playerInputs.leftRight()*Vector3.right);
        //        rb.MovePosition(new Vector3(touch.deltaPosition.x, 0, 0) * horizontalSpeed / Screen.width + transform.position + Vector3.forward * forwardSpeed);
        //        anim.SetFloat(xRef, -1);
        //        rb.MovePosition(new Vector3(touch.deltaPosition.x, 0, 0) * horizontalSpeed / Screen.width + transform.position + Vector3.forward * forwardSpeed);
        //print("not touched");
        //rb.MovePosition(Vector3.forward * forwardSpeed + transform.position);
        anim.SetFloat(xRef, playerInputs.leftRight());
        anim.SetFloat(yRef, 1);

    }

    private IEnumerator StopAnimAfterJump(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        anim.SetFloat(jumpRef, -1);
    }
    private IEnumerator StopAnimAfterLean(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        anim.SetFloat(leanRef, -1);
        boxCollider.size = initialBoxColliderSize;
    }
    private bool isGrounded()//TODO find a better approach
    {
        if(transform.position.y < 0.52)
        {
            return true;
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
