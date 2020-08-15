using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragonbehaviour : MonoBehaviour
{
    public GameObject head, body, tail;
    Animator hani, bani, tani;
    bool changeattack, corbool;
    int b, blast;
    // Start is called before the first frame update
    void Start()
    {
        hani = head.GetComponent<Animator>();
        bani = body.GetComponent<Animator>();
        tani = tail.GetComponent<Animator>();
        blast = 0;
        changeattack = true;
        corbool = true;
    }

    // Update is called once per frame
    void Update()
    {
        chooseattack();

    }

    void chooseattack()
    {
        if (changeattack)
        {

            b = Random.Range(0, 5);

            if (b == 1)
            {
                tailwhip();
                Debug.Log("1");

            }
            else if (b == 2)
            {
                tailwhip();
                Debug.Log("2");

            }
            else if (b == 3)
            {
                flame();
                Debug.Log("3");

            }
            else if (b == 4)
            {
                tailwhip();
                Debug.Log("4");

            }

            blast = b;
        }
    }
    void tailwhip()
    {
        changeattack = false;
        corbool = true;
        StartCoroutine(tailco());
        
    }

    void stomp()
    {
        changeattack = false;
        corbool = true;
        StartCoroutine(stompco());
    }
    
    void fireball()
    {
        changeattack = false;
        corbool = true;
        StartCoroutine(fireco());

    }

    void flame()
    {
        changeattack = false;
        corbool = true;
        StartCoroutine(flameco());

    }

    IEnumerator flameco()
    {
        while (corbool)
        {
            hani.SetTrigger("leave");
            hani.SetTrigger("flame");
            Debug.Log("flame initiating");
            yield return new WaitForSeconds(10);
            changeattack = true;
            corbool = false;
            StopCoroutine(flameco());

        }
    }
    IEnumerator fireco()
    {
        while (corbool)
        {
            hani.SetTrigger("leave");
            hani.SetTrigger("fireball");
            Debug.Log("fire ball initiating");

            yield return new WaitForSeconds(10);
            changeattack = true;
            corbool = false;
            StopCoroutine(fireco());


        }
    }
    IEnumerator stompco()
    {
        while (corbool)
        {
            bani.SetTrigger("stomp");
            Debug.Log("stomp initiating");

            yield return new WaitForSeconds(10);

            changeattack = true;
            corbool = false;
            StopCoroutine(stompco());

        }
    }
    IEnumerator tailco()
    {
        while (corbool)
        {
            tani.SetTrigger("attack");
            Debug.Log("tail initiating");

            yield return new WaitForSeconds(10);
            changeattack = true;
            corbool = false;
            StopCoroutine(tailco());


        }
    }
}
