using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;


public class UImanager : MonoBehaviour
{
    public GameObject cursor;
    public int currentselect;
    Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        currentselect = 1;

        ani = cursor.GetComponent<Animator>();

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
                SceneManager.LoadScene("test");
            }
            else if (currentselect == 2)
            {
                SceneManager.LoadScene("test");

            }
            else if (currentselect == 3)
            {
                SceneManager.LoadScene("test");

            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitGame();
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
