using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hiteffect : MonoBehaviour
{
    Rigidbody2D rb;
    public float thrust = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gb = GameObject.FindGameObjectWithTag("Player");
        rb = gb.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "enemy")
        {
            Debug.Log("in"); 
            rb.AddForce(transform.up *thrust);

        }
        Debug.Log("out");
    }

}
