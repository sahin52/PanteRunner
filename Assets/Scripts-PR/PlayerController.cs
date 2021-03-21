using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
public class PlayerController : MonoBehaviour,IGameManagement
{
    
    [SerializeField]
    float horizontalSpeed = 10f;
    [SerializeField]
    float forwardSpeed = 1f;

    Animator anim;
    Rigidbody rb;

    [SerializeField]
    AnimationCurve curve;
    bool isPlaying = true;
    int xRef = 0;
    int yRef = 0;
    int zRef = 0;
    int jumpRef;
    Vector3 startingPos;



    [SerializeField]
    PR_GameManager gameManager;
    [SerializeField]
    private float upwardsSpeed = 350f;

    // Start is called before the first frame update
    void Start()
    {
        if (gameManager == null)
        {
            gameManager = FindObjectOfType<PR_GameManager>();
        }
        startingPos = transform.position;
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        xRef = Animator.StringToHash("X");
        yRef = Animator.StringToHash("Y");
        zRef = Animator.StringToHash("Z");
        jumpRef = Animator.StringToHash("Jump");
        anim.SetFloat(yRef, 1);
    }

    void FixedUpdate()
    {
        
        if (gameManager.gameStarted)
            Move();                 //TODO inputu update'te al, burada sadece fizik calistir
    }
    void Update()
    {
        anim.SetFloat(zRef, rb.velocity.y);
       //curve.Evaluate()
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.Space)&& rb.velocity.y<0.01f && rb.velocity.y > -0.1f)
        {
            print("entered space");
            rb.AddForce(Vector3.up*upwardsSpeed);
            anim.SetFloat(jumpRef, 1);
            var stopJump = StopAnimAfterJump(0.5f);
            StartCoroutine(stopJump);
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
         
            //touched
            var touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Moved)
            {
                var deltaPos = touch.deltaPosition;

                if (deltaPos.x < 0)
                {   
                    rb.MovePosition(new Vector3(touch.deltaPosition.x,0,0) * horizontalSpeed / Screen.width + transform.position + Vector3.forward * forwardSpeed);
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
            
            rb.MovePosition(Vector3.forward * forwardSpeed + transform.position);
            anim.SetFloat(xRef, 0);
            
        }

    }

    void OnCollisionEnter(Collision col)
    {
        print("collided with "+col.collider.tag);
        if(col.collider.tag == Constants.Tags.Obstacle)
        {
            print("collided");
            gameManager.onLose();
        }
    }

    private IEnumerator StopAnimAfterJump(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        anim.SetFloat(jumpRef,-1);
    }

    void OnTriggerEnter(Collider triggeringCollider)
    {
        if(triggeringCollider.tag == Constants.Tags.Finish)
        {
            gameManager.onFinish();
            print("finished");
        }
    }
    public void Restart()
    {
        transform.position = startingPos;
    }

    public void OnStart()
    {
        gameObject.GetComponent<Animator>().enabled = false;
        transform.position = startingPos;
        print("Player Controller On Start");
        //throw new System.NotImplementedException();
    }

    public void OnPlay()
    {
        gameObject.GetComponent<Animator>().enabled = true;
        print("Player Controller On Play");
        //throw new System.NotImplementedException();
    }

    public void OnPause()
    {
        gameObject.GetComponent<Animator>().enabled = false;
        print("Player Controller On Pause");
        //throw new System.NotImplementedException();
    }

    public void OnLose()
    {
        gameObject.GetComponent<Animator>().enabled = false;
        transform.position = startingPos;
        print("Player Controller On Lose");
        //throw new System.NotImplementedException();
    }

    public void OnFinish()
    {
        //gameObject.GetComponent<Animator>().enabled = false;
        anim.SetFloat(yRef, 0);
        print("Player Controller On Finish");
        //throw new System.NotImplementedException();
    }

    public void OnFinishLinePassed()
    {
       // throw new System.NotImplementedException();
    }
}