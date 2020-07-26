using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pound : MonoBehaviour
{
    public GameObject player;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
           // rb.velocity = new Vector2(rb.velocity.x, 15);
            Debug.Log("pound detect");
            other.gameObject.GetComponent<enemydeath>().death = true;
        }

    }
    private void OnTriggerStay2D(Collider2D other)
    {
         if (other.gameObject.tag == "slime")
        {
            // rb.velocity = new Vector2(rb.velocity.x, 15);
            Debug.Log("pound detect");
            rb.velocity = new Vector2(rb.velocity.x, 20);
        }
    }
}
