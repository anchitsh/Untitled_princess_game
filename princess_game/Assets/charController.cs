using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charController : MonoBehaviour
{
    private Rigidbody2D rb;

    [Header("Movement Settings")]
    public float Speed = 0;
    public float MaxSpeed = 10;
    public float Acceleration = 10;
    public float Deceleration = 10;
    float position;
    float speed;

    [Header("Grounded checker")]

    public Transform isGroundedChecker;
    public float checkGroundRadius;
    public LayerMask groundLayer;
    public float rememberGroundedFor;
    float lastTimeGrounded;
    bool isGrounded = false;

    [Header("Jump Settings")]
    public float jumpForce;
    public int defaultJumps = 1;
    int morejumps;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;



    [Header("Misc")]
    public int buffermax = 10, coymax =10;
    int buffercounter = 0, coybuffer = 0;
    bool bufferbool;
    




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        morejumps = defaultJumps;

        
    }
    private void FixedUpdate()
    {
        Move();
    }
    // Update is called once per frame
    void Update()
    {


        
        Jump();
        CheckIfGrounded();
        //  BetterJump();
        //  bufferjump();
        // coyetetime();



        Debug.Log("is it grounded" + isGrounded);


    }


    void Move()
    {

        if ((Input.GetKey("left")) && (Speed > -MaxSpeed))
        {
            Speed = Speed - Acceleration * Time.deltaTime;
            if (Speed > 0)
            {
                Speed = Speed - Deceleration * Time.deltaTime;
            }
        }
        else if ((Input.GetKey("right")) && (Speed < MaxSpeed))
        {
            Speed = Speed + Acceleration * Time.deltaTime;
            if (Speed < 0)
            {
                Speed = Speed + Deceleration * Time.deltaTime;
            }
        }
            
        else
        {
            if (Speed > Deceleration * Time.deltaTime) Speed = Speed - Deceleration * Time.deltaTime;
            else if (Speed < -Deceleration * Time.deltaTime) Speed = Speed + Deceleration * Time.deltaTime;
            else
                Speed = 0;
        }
        position = transform.position.x + Speed * Time.deltaTime;
        transform.position = new Vector2(position, transform.position.y);
        /*
        float x = Input.GetAxisRaw("Horizontal");

        float moveBy = x * speed;

        rb.velocity = new Vector2(moveBy, rb.velocity.y);*/
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded) )
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            morejumps--;
            transform.parent = null;
        }


    }

    void BetterJump()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
    void bufferjump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == false)
        {
            bufferbool = true;
        }
        if (bufferbool == true)
        {
            buffercounter++;
            if (isGrounded)
            {

                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                midjump = true;
                jump = true;
            }
            if (buffercounter > buffermax)
            {
                bufferbool = false;
                buffercounter = 0;
            }

        }

    }
    void coyetetime()
    {
        if (isGrounded == false)
        {
            if (Input.GetKeyDown(KeyCode.Space) && coybuffer < coymax && midjump==false)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
            coybuffer++;
           
        }
        else
        {
            coybuffer = 0;
        }
    }
    void CheckIfGrounded()
    {
        Collider2D colliders = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer);

        if (colliders != null)
        {
            isGrounded = true;

            morejumps = defaultJumps;
            
        }
        else
        {
            if (isGrounded)
            {
                lastTimeGrounded = Time.time;
            }
            isGrounded = false;
        }
    }
}
