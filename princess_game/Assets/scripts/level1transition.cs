using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level1transition : MonoBehaviour
{
    public GameObject swordtransition, blank, level1text;
    Animator ani;
    public static bool switchon;
    bool once;
    // Start is called before the first frame update
    void Start()
    {
        ani = swordtransition.GetComponent<Animator>();
        switchon = false;
        once = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (switchon && once){
            swordtransition.SetActive(true);
            StartCoroutine(tns());
            once = false;
        }
    }


    IEnumerator tns()
    {
        ani.SetTrigger("swordout");
        float duration = Time.time + .8f;
        while (Time.time < duration)
        {

            yield return null;

        }
        if (Time.time > duration)
        {
            blank.SetActive(true);
            level1text.SetActive(true);
            StartCoroutine(tns2());
            StopCoroutine(tns());
        }

    }
    IEnumerator tns2()
    {
        
        float duration = Time.time + 3f;
        while (Time.time < duration)
        {

            yield return null;

        }
        if (Time.time > duration)
        {
            blank.SetActive(false);
            level1text.SetActive(false);
            ani.SetTrigger("swordin");
            once = false;
            StopCoroutine(tns2());
        }

    }
}
