using UnityEngine;

public class PlayerMover : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] Rigidbody rb;
    private float horizontal;
    [SerializeField] float jump = 200f;
    private Vector3 startState;
    //[SerializeField] LayerMask groundMask;
    [SerializeField] Animator playerAnimator;

    void Start()
    {
        startState = transform.position;
        //playerAnimator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {


        if (Input.GetKeyDown(KeyCode.R))
        {
            playerAnimator.SetBool("Run", true);
        }
        Vector3 movementVector = transform.forward * speed * Time.deltaTime;
        Vector3 movementHorizontal = horizontal * transform.right * speed * Time.deltaTime;
        rb.MovePosition(rb.position + movementVector + movementHorizontal * 2f);

    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void Jump()
    {
        //chack if grounded
        float higth1 = transform.position.y;
        float higth2 = startState.y;
        bool flag = (higth2 + 0.01f >= higth1 && higth2 - 0.01f <= higth1);
        if (flag)
        {
            rb.AddForce(Vector3.up * jump);
        }

    }
}
