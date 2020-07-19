using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UImanager : MonoBehaviour
{
    public GameObject sword;
    public int currentselect;
    float x, p1, p2, p3;

    // Start is called before the first frame update
    void Start()
    {
        currentselect = 1;
        x = sword.transform.position.x;
        p1 = 0f;
        p2 = -1.47f;
        p3 = -2.84f;
    }

    // Update is called once per frame
    void Update()
    {
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
                sword.transform.position = new Vector2(x,p1);
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
        else
        {

        }

        Debug.Log(currentselect);
    }


    void swordup()
    {
        if (currentselect == 1)
        {
            sword.transform.DOMove((new Vector2(x,p1)), 0.5f);
        }
        else if (currentselect == 2)
        {
            sword.transform.DOMove((new Vector2(x,p2)), 0.5f);
        }


    }

    void swordown()
    {
        if (currentselect == 2)
        {
            sword.transform.DOMove((new Vector2(x,p2)), 0.5f);
        }
        else if (currentselect == 3)
        {
            sword.transform.DOMove((new Vector2(x,p3)), 0.5f);
        }
    }
}
