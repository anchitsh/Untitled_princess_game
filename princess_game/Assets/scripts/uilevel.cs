using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uilevel : MonoBehaviour
{
    public GameObject youdead;
    public GameObject bg;
    public GameObject sword;
    public GameObject play;
    public GameObject end;

    Animator swordani;
    public static bool dead, finish;
    bool oncedead, oncefinish;
    
    // Start is called before the first frame update
    void Start()
    {
        swordani = sword.GetComponent<Animator>();
        dead = false;
        youdead.SetActive(false);
        oncedead = false;
        oncefinish = false;
        play.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (dead&& oncedead == false)
        {
            sword.SetActive(true);
            youdead.SetActive(true);
            StartCoroutine(tns());
            oncedead = true;
            
        }
        if(finish && oncefinish == false)
        {
            sword.SetActive(true);
            play.SetActive(false);
            end.SetActive(true);
            oncefinish =true;
            StartCoroutine(fin());
        }
    }

    IEnumerator tns()
    {

        float duration = Time.time + 1.5f;
        while (Time.time < duration)
        {

            yield return null;

        }
        if (Time.time > duration)
        {
            swordani.SetTrigger("swordout");
            StartCoroutine(tns2());
            StopCoroutine(tns());
        }

    }
    IEnumerator tns2()
    {

        float duration = Time.time + .8f;
        while (Time.time < duration)
        {

            yield return null;

        }
        if (Time.time > duration)
        {
            bg.SetActive(true);
            StartCoroutine(tns3());
            StopCoroutine(tns());
        }

    }
    IEnumerator tns3()
    {

        float duration = Time.time + 2f;
        while (Time.time < duration)
        {

            yield return null;

        }
        if (Time.time > duration)
        {
            
        }

    }
    IEnumerator fin()
    {

        float duration = Time.time + 4f;
        while (Time.time < duration)
        {

            yield return null;

        }
        if (Time.time > duration)
        {
            Debug.Log("endlamo");
            swordani.SetTrigger("swordout");
            StartCoroutine(tns2());
            StopCoroutine(fin());
        }

    }
}
