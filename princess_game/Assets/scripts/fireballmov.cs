using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireballmov : MonoBehaviour
{
    Rigidbody2D rb, player;
    GameObject pl;
    public float velocity;
    bool dir;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void move()
    {
        pl = GameObject.FindWithTag("Player");
        player = pl.GetComponent<Rigidbody2D>();
        Vector2 p = pl.transform.position;
        Vector2 fireballpos = transform.position;
        Vector2 togo = (p - fireballpos).normalized;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(togo.x, togo.y) * velocity;
        if (rb.velocity.x > 0)
        {
            dir = true;
        }
        else
        {
            dir = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Player" && charController.invincibility == false)
        {
            Debug.Log("in");
            healthsystem.health--;
            charController.takedamage = true;
            charController.damagedirection = dir;
            Destroy(gameObject);

        }
        if (other.gameObject.tag == "block")
        {
            Destroy(gameObject);

        }
    }
}
