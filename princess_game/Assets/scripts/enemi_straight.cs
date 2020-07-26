using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemi_straight : MonoBehaviour
{
    public GameObject positionA, positionB;
    bool positionAbool, positionBbool;
    // float start_pos;
    // float end_pos;
    // public float units_mov;
    Rigidbody2D rb;
    public bool direction;
    public float velocity, cornerwaittime;
    public bool movebool;
    private SpriteRenderer spriteren;
    bool corbool;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //  start_pos = transform.position.x;
        // end_pos = start_pos - units_mov;
        direction = true;
        movebool = true;
        spriteren = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        checkdirection();

        if (movebool)
        {
            move();
        }
    }
    void flipsprite()
    {
        spriteren.flipX = !spriteren.flipX;
    }
    void checkdirection()
    {
        float currentpos = transform.position.x;
        if (direction == false)
        {
            if (currentpos <= positionA.transform.position.x)
            {
                direction = true;
                movebool = false;
                corbool = true;
                StartCoroutine(waittime());
            }
        }

        if (direction == true)
        {
            if (currentpos >= positionB.transform.position.x)
            {

                movebool = false;
                direction = false;
                corbool = true;
                StartCoroutine(waittime());
            }
        }



    }
    void move()
    {
        if (direction)
        {
            rb.velocity = new Vector2(velocity, rb.velocity.y);
        }
        else
            rb.velocity = new Vector2(-velocity, rb.velocity.y);
    }

    IEnumerator waittime()
    {
        while (corbool)
        {
            yield return new WaitForSeconds(cornerwaittime);
            movebool = true;
            flipsprite();

            corbool = false;

        }
        StopCoroutine(waittime());
    }
    // called when the cube hits the floor

}