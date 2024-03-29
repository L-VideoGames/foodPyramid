using System.Collections;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] float horizonSpeed;
    [SerializeField] Rigidbody rb;
    private float horizontal;
    [SerializeField] float jump = 200f;
    private Vector3 startState;
    //[SerializeField] LayerMask groundMask;
    [SerializeField] Animator playerAnimator;
    
    private float tempSpeed;
    private float tempHorizonSpeed;
    private float posX;
    private float leftX;
    private float rigthX;
    private bool fixMove;
    private bool fixRun;

    private Vector2 startTouchPos;
    private Vector2 endTouchPos;
    private int touchVal = 0;

    void Start()
    {
        startState = transform.position;
        tempSpeed = speed;
        tempHorizonSpeed = horizonSpeed+2f;
        posX = transform.position.x;
        leftX = posX - 3f;
        rigthX = posX + 3f;
        fixMove = true;
        fixRun = true;
        //playerAnimator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        //horizontal = Input.GetAxis("Horizontal");
        if (fixMove)
        {
            //int touchVal = 0;
            if(Input.touchCount>0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                startTouchPos = Input.GetTouch(0).position;
                print(111);
            }
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                endTouchPos = Input.GetTouch(0).position;
                if (endTouchPos.x < startTouchPos.x){ touchVal = 1;}
                else if(endTouchPos.x > startTouchPos.x) { touchVal = 2; }
                print(222);
            }
            
            if (Input.GetKeyUp(KeyCode.RightArrow)|| touchVal == 2)
            {
                StartCoroutine(fixedMover());
                if (posX < rigthX)
                {
                    posX += 1f;
                }
                else
                {
                    posX = rigthX;
                }
                touchVal = 0;
                //rb.MovePosition(rb.position + movementHorizontal); transform.right;
            }
            else if (Input.GetKeyUp(KeyCode.LeftArrow) || touchVal == 1)
            {
                StartCoroutine(fixedMover());
                if (posX > leftX)
                {
                    posX -= 1f;
                }
                else
                {
                    posX = leftX;
                }
                touchVal = 0;
                
            }
        }


        /*        if (Input.GetKeyDown(KeyCode.R))
                {
                    playerAnimator.SetBool("Run", true);
                }*/
        if (GameManager.inst.getInjured())
        {
            tempSpeed = speed-1f;
            if (fixRun)
            {
                StartCoroutine(fixSpeedAfterInj());
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            tempSpeed = speed + 2f;
            tempHorizonSpeed = horizonSpeed;
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            tempSpeed = speed;
            tempHorizonSpeed = horizonSpeed + 2f;
        }



        Vector3 movementVector = transform.forward * tempSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + movementVector  * 2f);


            rb.transform.position = (new Vector3(posX, rb.position.y, rb.position.z));
     
        

    }

    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private IEnumerator fixedMover()
    {
        fixMove = false;
        yield return new WaitForSeconds(0.001f);
        fixMove = true;

    }
    IEnumerator fixSpeedAfterInj()
    {

        fixRun = false;
        yield return new WaitForSeconds(3.0f);
        tempSpeed = speed;
        fixRun = true;
    }

    void Jump()
    {
        //chack if grounded
        float higth1 = transform.position.y;
        float higth2 = startState.y;
        bool flag = (higth2 + 0.02f >= higth1 && higth2 - 0.02f <= higth1);
        if (flag)
        {
            rb.AddForce(Vector3.up * jump);
        }

    }
}
