using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pausemenu : MonoBehaviour
{
    public GameObject cursor;
    public int cur;
    Animator ani;
    GameObject[] pause;
    bool gameon, pauseon;

    // Start is called before the first frame update
    void Start()
    {
        cur = 1;
        ani = cursor.GetComponent<Animator>();
        pause = GameObject.FindGameObjectsWithTag("onpause");
        pauseon = false;
        gameon = true;
              hidepaused();
    }

    // Update is called once per frame
    void Update()
    {

        if (gameon == true && Input.GetKey(KeyCode.Escape))
        {
            pauseon = true;
            gameon = false;
            showpaused();

            Time.timeScale = 0;
        }
        if (pauseon == true)
        {
            pausemen();
        }

    }

    void showpaused()
    {
        foreach (GameObject g in pause)
        {
            g.SetActive(true);
        }
    }
    void hidepaused()
    {
        foreach (GameObject g in pause)
        {
            g.SetActive(false);
        }
    }

    void pausemen()
    {

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (cur == 3)
            {
                cur = 1;

            }
            else
            {
                cur++;

            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (cur == 1)
            {
                cur = 3;

            }
            else
            {
                cur--;

            }

        }
        switch (cur)
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

            if (cur == 1)
            {
                pauseon = false;
                gameon = true;
                hidepaused();

                Time.timeScale = 1;
            }
            else if (cur == 2)
            {
                SceneManager.LoadScene("test");

            }
            else if (cur == 3)
            {
                SceneManager.LoadScene("test");

            }
        }
        /*if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseon = false;
            gameon = true;
            hidepaused();

            Time.timeScale = 1;
        }*/
    }
}
