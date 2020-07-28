using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pound : MonoBehaviour
{
    public GameObject player, dragonhead, dragontail;
    Rigidbody2D rb;
    Animator ani,anitail;
    // Start is called before the first frame update
    void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
        ani = dragonhead.GetComponent<Animator>();
        anitail = dragontail.GetComponent<Animator>();
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
        if (other.gameObject.tag == "dragon")
        {
            // rb.velocity = new Vector2(rb.velocity.x, 15);
            Debug.Log("dragon");
            ani.SetTrigger("damage");
            bossUI.decrease();
            rb.velocity = new Vector2(rb.velocity.x, 20);
        }
        if (other.gameObject.tag == "tail")
        {
            // rb.velocity = new Vector2(rb.velocity.x, 15);
            Debug.Log("dragon");
            anitail.SetTrigger("damage");
            bossUI.decrease();
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
