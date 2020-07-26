using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragonbehaviour : MonoBehaviour
{
    public GameObject head, body, tail;
    Animator hani, bani, tani;
    // Start is called before the first frame update
    void Start()
    {
        hani = head.GetComponent<Animator>();
        bani = body.GetComponent<Animator>();
        tani = tail.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void tailwhip()
    {

    }

    void stomp()
    {

    }
    
    void fireball()
    {

    }

    void flame()
    {

    }
}
