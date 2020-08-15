using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camshift : MonoBehaviour
{
    public int camint;
   // GameObject player;
    // Start is called before the first frame update
    void Start()
    {

        //player = GameObject.FindWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            camerasystem.camint = camint;
        }


    }

}
