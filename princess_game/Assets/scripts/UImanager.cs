using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;


public class UImanager : MonoBehaviour
{
    public GameObject cursor;
    public GameObject transition1, transition2;
    Animator tn1, tn2;
    public int currentselect;
    Animator ani;
    public static int startint;
    // Start is called before the first frame update
    void Start()
    {
        tn1 = transition1.GetComponent<Animator>();
        tn2 = transition2.GetComponent<Animator>();
        transition1.SetActive(true);
        transition2.SetActive(true);
        currentselect = 1;

        ani = cursor.GetComponent<Animator>();
        tn1.SetTrigger("out");
        tn2.SetTrigger("out");
    }

    // Update is called once per frame
    void Update()
    {

        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(currentselect == 1)
            {
                sword.transform.DOMove((new Vector2(8, p1)), 1f);
            }
            else if (currentselect == 2)
            {
                sword.transform.DOMove((new Vector2(8, p2)),1f);
            }
            else if (currentselect == 3)
            {
                sword.transform.DOMove((new Vector2(8, p3)), 1f);
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentselect == 3)
            {
                currentselect = 1;
                sword.transform.position = new Vector2(x, p1);
            }
            else
            {
                currentselect++;
                swordown();
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentselect == 1)
            {
                currentselect = 3;
                sword.transform.position = new Vector2(x,p3);
            }
            else
            {
                currentselect--;
                swordup();
            }

        }


        

    */

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentselect == 3)
            {
                currentselect = 1;
                
            }
            else
            {
                currentselect++;
                
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentselect == 1)
            {
                currentselect = 3;
                
            }
            else
            {
                currentselect--;
                
            }

        }
        switch (currentselect)
        {
            case 1:
                ani.SetInteger("cursor", 1);
                break;
            case 2:
                ani.SetInteger("cursor", 2);
                break;
            case 3:
                ani.SetInteger("cursor", 3);
                break;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            if (currentselect == 1)
            {
                startint = 1;
               // SceneManager.LoadScene("intro");
            }
            else if (currentselect == 2)
            {
                startint = 2;
                //SceneManager.LoadScene("test");

            }
            else if (currentselect == 3)
            {
                startint = 3;
                //SceneManager.LoadScene("test");

            }
            tn1.SetTrigger("in");
            tn2.SetTrigger("in");
            tn1.SetBool("start", true);
        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            startint = -1;
            tn1.SetTrigger("in");
            tn2.SetTrigger("in");
            tn1.SetBool("start", true);
            // ExitGame();
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
