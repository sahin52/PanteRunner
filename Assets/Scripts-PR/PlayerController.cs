using UnityEngine;
using UnityEngine.EventSystems;
public class PlayerController : MonoBehaviour,IPointerClickHandler,IPointerDownHandler,IPointerUpHandler,IGameManagement
{
    
    [SerializeField]
    float speed = 1f;
    [SerializeField]
    float forwardSpeed = 1f;

    Animator anim;
    Rigidbody rb;

    [SerializeField]
    AnimationCurve curve;
    bool isPlaying = true;
    int xRef = 0;
    int yRef = 0;
    Vector3 startingPos;



    [SerializeField]
    PR_GameManager gameManager;
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
        anim.SetFloat(yRef, 1);
    }

    void FixedUpdate()
    {
        
        if (gameManager.gameStarted)
            Move();                 //TODO inputu update'te al, burada sadece fizik calistir
    }
    void Update()
    {
       //curve.Evaluate()
    }

    private void Move()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            //touched
            var touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Moved)
            {
                var deltaPos = touch.deltaPosition;

                if (deltaPos.x < 0)
                {   
                    rb.MovePosition(Vector3.left * speed + transform.position + Vector3.forward * forwardSpeed);
                    anim.SetFloat(xRef, -1);
                    print("sol");
                }
                else
                {
                    rb.MovePosition(Vector3.right * speed + transform.position + Vector3.forward * forwardSpeed);
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
            transform.position = startingPos;
            gameManager.onLose();
        }

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        
        //throw new System.NotImplementedException();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
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
        print("Player Controller On Start");
        //throw new System.NotImplementedException();
    }

    public void OnPlay()
    {
        print("Player Controller On Play");
        //throw new System.NotImplementedException();
    }

    public void OnPause()
    {
        print("Player Controller On Pause");
        //throw new System.NotImplementedException();
    }

    public void OnLose()
    {
        print("Player Controller On Lose");
        //throw new System.NotImplementedException();
    }

    public void OnFinish()
    {
        print("Player Controller On Finish");
        //throw new System.NotImplementedException();
    }
}