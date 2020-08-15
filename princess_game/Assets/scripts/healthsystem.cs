using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthsystem : MonoBehaviour
{
     public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public GameObject damage1;
    public GameObject damage2;
    public GameObject damage3;
    float hit;
    public static int health;

    // Start is called before the first frame update

    void Start()
    {
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
