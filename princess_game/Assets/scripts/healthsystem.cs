using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthsystem : MonoBehaviour
{
     GameObject heart1;
     GameObject heart2;
     GameObject heart3;
     GameObject damage1;
     GameObject damage2;
     GameObject damage3;
    float hit;
    public static int health;
    // Start is called before the first frame update
    void Start()
    {
        heart1 = GameObject.FindWithTag("heart1");
        heart2 = GameObject.FindWithTag("heart2");
        heart3 = GameObject.FindWithTag("heart3");
        damage1 = GameObject.FindWithTag("damage1");
        damage2 = GameObject.FindWithTag("damage2");
        damage3 = GameObject.FindWithTag("damage3");

        heart1.SetActive(true);
        heart2.SetActive(true);
        heart3.SetActive(true);
        damage1.SetActive(false);
        damage2.SetActive(false);
        damage3.SetActive(false);
        health = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (health > 3)
        {
            health = 3;
        }
        hitcheck();
        
    }
    public  void hitcheck()
    {
        if (health == 3)
        {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(true);
            damage1.SetActive(false);
            damage2.SetActive(false);
            damage3.SetActive(false);
        }
        else if(health == 2)
        {
            heart1.SetActive(false);
            heart2.SetActive(true);
            heart3.SetActive(true);
            damage1.SetActive(true);
            damage2.SetActive(false);
            damage3.SetActive(false);
        }
        else if (health == 1)
        {
            heart1.SetActive(false);
            heart2.SetActive(false);
            heart3.SetActive(true);
            damage1.SetActive(true);
            damage2.SetActive(true);
            damage3.SetActive(false);
        }
        else if (health == 0)
        {
            heart1.SetActive(false);
            heart2.SetActive(false);
            heart3.SetActive(false);
            damage1.SetActive(true);
            damage2.SetActive(true);
            damage3.SetActive(true);
        }
    }
}
