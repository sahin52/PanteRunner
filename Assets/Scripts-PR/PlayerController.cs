using UnityEngine;
using UnityEngine.EventSystems;
public class PlayerController : MonoBehaviour,IPointerClickHandler,IPointerDownHandler,IPointerUpHandler
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
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        xRef = Animator.StringToHash("X");
        yRef = Animator.StringToHash("Y");
        
    }

    void FixedUpdate()
    {
        Move();//TODO inputu update'te al, burada sadece fizik calistir
    }
    void Update()
    {
       //curve.Evaluate()
    }

    private void Move()
    {
        if (Input.touchCount > 0)
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
           // anim.SetFloat(yRef, 0);
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
}