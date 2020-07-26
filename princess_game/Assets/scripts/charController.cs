using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charController : MonoBehaviour
{
    private Rigidbody2D rb;

    [Header("Movement Settings")]
    public float walk_speed;
    public float run_speed;

    /*
    
    public float Speed = 0;
    public float MaxSpeed = 10;
    public float Acceleration = 10;
    public float Deceleration = 10;
    float position;
    float speed;
    */
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
    bool jump;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;



    [Header("Misc")]
    public int buffermax = 10, coymax = 10;
    int buffercounter = 0, coybuffer = 0;
    bool bufferbool;
    bool midjump;
    Collider2D body;

    public float climbSpeed;
    bool isclimbing = false;
    float gravityScaleAtStart;

    float midair;
    bool walltouch;

    public static bool move;
    private Transform m_currMovingPlatform; 

    bool jmp;
    public static bool goinup, comingdown, landed, groundpound, block, attack, run, walk, runattack, idleattack, takedamage, damagedirection, walkattack, invincibility, dead;
    public float GroundpoundForce;
    bool jumpswitch, jumpswitchani, runswitch, runswitchani;
    public GameObject swordcol, blockcol, poundcol;

    [Header("Blink")]
    public float spriteBlinkingTimer = 0.0f;
    public float spriteBlinkingMiniDuration ;

    public float invincibility_timer;
    bool invinbool, pushbool, pushcall, deadcall;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        morejumps = defaultJumps;
        body = rb.GetComponent<Collider2D>();
        gravityScaleAtStart = rb.gravityScale;
        jump = false;
        midair = 0;
        goinup = false;
        comingdown = false;
        groundpound = false;
        block = false;
        attack = false;
        jumpswitch = true;
        runswitch = true;
        walk = false;
        run = false;
        runswitchani= true;
        jumpswitchani = true;
        idleattack = false;
        walkattack = false;
        swordcol.SetActive(false);
        takedamage = false;
        poundcol.SetActive(false);
        blockcol.SetActive(false);
        invincibility = false;
        damagedirection = false;
        invinbool = false;
        pushbool = false;
        pushcall = true;
        dead = false;
        deadcall = true;
    }
    private void FixedUpdate()
    {
        
            Move();
                
    }
    // Update is called once per frame
    void Update()
    {
        death();
        if (dead == false)
        {
            Jump();
            BetterJump();
            CheckIfGrounded();
            findjumppos();
            combat();
            swordattack();
            damage();
        }
        
    }

    void death()
    {
        int health = healthsystem.health;
        if (health == -1)
        {
            dead = true;
            if (deadcall == true)
            {
                StartCoroutine(deadpush());
                deadcall = false;
            }
            
        }
    }
    void Move()
    {
        /*
        if (runswitch == true)
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
        }*/
        if (runswitch == true && runswitchani == true && takedamage == false && dead ==false)
        {
            float x = Input.GetAxisRaw("Horizontal");
            if (x == 0)
            {
                run = false;
                walk = false;
               rb.velocity = new Vector2(0, rb.velocity.y);
                runattack = false;
                if (Input.GetKey(KeyCode.X))
                {
                    idleattack = true;
                }
                else
                {
                    idleattack = false;
                }
                return;
            }

            if (Input.GetKey(KeyCode.LeftShift)&& Input.GetKey(KeyCode.X))
            {
                float moveBy = x * run_speed;
                rb.velocity = new Vector2(moveBy, rb.velocity.y);
                run = true;
                walk = false;
                
                
                    if (Input.GetKey(KeyCode.X))
                    {
                        runattack = true;
                    }
                    else
                    {
                        runattack = false;
                    } 
            }
            else if (Input.GetKey(KeyCode.LeftShift))
            {
                float moveBy = x * run_speed;
                rb.velocity = new Vector2(moveBy, rb.velocity.y);
                run = true;
                walk = false;
                runattack = false;
            }
            else
            {
                float moveBy = x * walk_speed;
                rb.velocity = new Vector2(moveBy, rb.velocity.y);
                run = false;
                walk = true;
                runattack = false;
                if (Input.GetKey(KeyCode.X))
                {
                    walkattack = true;
                }
                else
                {
                    walkattack = false;
                }
            }
        }
        else if(runswitch == false || runswitchani == false)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            run = false;
            walk = false;
            runattack = false;
        }


    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Z) && (isGrounded) && (jumpswitch) && (jumpswitchani))
        {
            jmp = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            
            goinup = true;
        }

    }


    

    void BetterJump()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Z))
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
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



    void findjumppos()
    {
        if(goinup == true)
        {
            if (rb.velocity.y < 0)
            {
                
                comingdown = true;
                goinup = false;
            }

            landed = false;
            gd();
        }
        
        if(comingdown == true)
        {
            landed = false;
            gd();
            if (isGrounded == true)
            {
                goinup = false;
                comingdown = false;
                landed = true;
                groundpound = false;
                poundcol.SetActive(false);
            }
        }
    }

    void gd()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            groundpound = true;
            rb.velocity = new Vector2(rb.velocity.x, -GroundpoundForce);
            poundcol.SetActive(true);
        }
    }

    void combat()
    {
        if (goinup == false && comingdown == false)
        {
            if (Input.GetKey(KeyCode.C))
            {
                
                block = true;
            }
            else
            {
                
                block = false;
            }



            
            
            if ( block == true)
            {
                jumpswitch = false;
                runswitch = false;
                blockcol.SetActive(true);
            }
            else if (block == false)
            {
                jumpswitch = true;
                runswitch = true;
                blockcol.SetActive(false);
            }
        }
    }

    void attackoff()
    {
        attack = false;
    }

    void runoff()
    {
        
        runswitchani = false;
    }

    void runon()
    {
        runswitchani = true;
    }

    void jumpoff()
    {
        jumpswitchani = false;
    }

    void jumpon()
    {
        jumpswitchani = true;
    }


    void shake()
    {
        shakecine.flip = true;
    }
    void swordattack()
    {
        if (idleattack || runattack || walkattack)
        {
            swordcol.SetActive(true);
        }
        else
        {
            swordcol.SetActive(false);
        }
        
    }
    void damage()
    {
        if(takedamage == true )
        {
            
            invinbool = true;
            pushbool = true;
            if (pushcall)
            {
                pushback();
                pushcall = false;
            }

        }
    }

    void pushback()
    {
        StartCoroutine(push());
    }


    private IEnumerator deadpush()
    {
        float duration = Time.time + 1f;
        while (Time.time < duration)
        {
            if (damagedirection)
            {
                rb.velocity = new Vector2(3, 0);

            }
            else
            {
                rb.velocity = new Vector2(3, 0);
            }
            yield return null;

        }
        if (Time.time > duration)
        {
            rb.velocity = new Vector2(0, 0);
            StopCoroutine(deadpush());
        }

    }
    private IEnumerator push()
    {

        while (pushbool)
        {

            if (damagedirection)
            {
                rb.velocity = new Vector2(6, 0);

            }
            else
            {
                rb.velocity = new Vector2(-6, 0);
            }
            yield return new WaitForSeconds(0.5f);
            takedamage = false;
            pushcall = true;
            StartCoroutine(invincible());
            StopCoroutine(push());
            pushbool = false;

        }
       
    }
    private IEnumerator invincible()
    {
        
        float duration = Time.time + invincibility_timer;
        while (Time.time < duration)
        {
            invincibility = true;
            SpriteBlinkingEffect();
            yield return null;
 
        }
        if(Time.time > duration)
        {
            this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            invincibility = false;
            StopCoroutine(invincible());
        }

    }
    private void SpriteBlinkingEffect()
    {
        spriteBlinkingTimer += Time.deltaTime;
        if (spriteBlinkingTimer >= spriteBlinkingMiniDuration)
        {
            spriteBlinkingTimer = 0.0f;
            if (this.gameObject.GetComponent<SpriteRenderer>().enabled == true)
            {
                this.gameObject.GetComponent<SpriteRenderer>().enabled = false;  //make changes
            }
            else
            {
                this.gameObject.GetComponent<SpriteRenderer>().enabled = true;   //make changes
            }
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "enemy")
        {

            Vector2 dir = col.gameObject.transform.position - transform.position;
            // We then get the opposite (-Vector3) and normalize it
            dir = -dir.normalized;
            // And finally we add force in the direction of dir and multiply it by force. 
            // This will push back the player
           // rb.velocity = new Vector2(6, 6);
            takedamage = true;
            
        }

    }


    void bufferjump()
    {
        if (Input.GetKeyDown(KeyCode.Z) && isGrounded == false)
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
            if (Input.GetKeyDown(KeyCode.Z) && coybuffer < coymax && midjump == false)
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
}
