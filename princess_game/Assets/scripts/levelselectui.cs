using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class levelselectui : MonoBehaviour
{
    public GameObject bigspring, bigsummer, bigautumn, bigwinter;
    public GameObject summergrey, autumngrey, wintergrey;
    public GameObject springcolor, summercolor, autumncolor, wintercolor;
    public GameObject cursor;
    Animator springani, summerani, autumnani, winterani, cursorani;
    public int current;
    int level;
    public GameObject dragoncolor, dragongrey, dragonmask;
    public GameObject mask1, mask2, mask3, mask4;
    public GameObject arrowleft, arrowright;
    public GameObject transition1, transition2;
    Animator tn1, tn2;
    bool open;
    public static int exitint;
    // Start is called before the first frame update
    void Start()
    {
        springani = bigspring.GetComponent<Animator>();
        summerani = bigsummer.GetComponent<Animator>();
        autumnani = bigautumn.GetComponent<Animator>();
        winterani = bigwinter.GetComponent<Animator>();
        cursorani = cursor.GetComponent<Animator>();
        tn1 = transition1.GetComponent<Animator>();
        tn2 = transition2.GetComponent<Animator>();
        level = PlayerPrefs.GetInt("level", 1);
        level = 3;
        exitint = 0;
        transition1.SetActive(true);
        transition2.SetActive(true);
        tn1.SetTrigger("out");
        tn2.SetTrigger("out");
        switch (level)
        {
            case 1:
                current = 1;

                summergrey.SetActive(true);
                autumngrey.SetActive(true);
                wintergrey.SetActive(true);
                bigsummer.SetActive(false);
                bigautumn.SetActive(false);
                bigwinter.SetActive(false);
                bigspring.SetActive(true);
                springcolor.SetActive(false);
                summercolor.SetActive(false);
                autumncolor.SetActive(false);
                wintercolor.SetActive(false);
                dragoncolor.SetActive(false);
                dragongrey.SetActive(false);
                dragonmask.SetActive(false);
                mask1.SetActive(true);
                mask2.SetActive(true);
                mask3.SetActive(true);
                mask4.SetActive(true);
                break;
            case 2:
                summergrey.SetActive(false);
                autumngrey.SetActive(true);
                wintergrey.SetActive(true);
                bigsummer.SetActive(true);
                bigautumn.SetActive(false);
                bigwinter.SetActive(false);
                bigspring.SetActive(false);
                springcolor.SetActive(true);
                summercolor.SetActive(false);
                autumncolor.SetActive(false);
                wintercolor.SetActive(false);
                current = 2;
                dragoncolor.SetActive(false);
                dragongrey.SetActive(false);
                dragonmask.SetActive(false);
                mask1.SetActive(true);
                mask2.SetActive(true);
                mask3.SetActive(true);
                mask4.SetActive(true);
                break;
            case 3:
                summergrey.SetActive(false);
                autumngrey.SetActive(false);
                wintergrey.SetActive(true);
                bigsummer.SetActive(false);
                bigautumn.SetActive(true);
                bigwinter.SetActive(false);
                bigspring.SetActive(false);
                springcolor.SetActive(true);
                summercolor.SetActive(true);
                autumncolor.SetActive(false);
                wintercolor.SetActive(false);
                current = 3;
                dragoncolor.SetActive(false);
                dragongrey.SetActive(false);
                dragonmask.SetActive(false);
                mask1.SetActive(true);
                mask2.SetActive(true);
                mask3.SetActive(true);
                mask4.SetActive(true);
                break;
            case 4:
                summergrey.SetActive(false);
                autumngrey.SetActive(false);
                wintergrey.SetActive(false);
                bigsummer.SetActive(false);
                bigautumn.SetActive(false);
                bigwinter.SetActive(true);
                bigspring.SetActive(false);
                springcolor.SetActive(true);
                summercolor.SetActive(true);
                autumncolor.SetActive(true);
                wintercolor.SetActive(false);
                dragoncolor.SetActive(false);
                dragongrey.SetActive(false);
                dragonmask.SetActive(false);
                mask1.SetActive(true);
                mask2.SetActive(true);
                mask3.SetActive(true);
                mask4.SetActive(true);
                current = 4;
                break;
            case 5:
                summergrey.SetActive(false);
                autumngrey.SetActive(false);
                wintergrey.SetActive(false);
                bigsummer.SetActive(false);
                bigautumn.SetActive(false);
                bigwinter.SetActive(false);
                bigspring.SetActive(false);
                springcolor.SetActive(false);
                summercolor.SetActive(false);
                autumncolor.SetActive(false);
                wintercolor.SetActive(false);
                dragoncolor.SetActive(false);
                dragongrey.SetActive(true);
                dragonmask.SetActive(true);
                mask1.SetActive(false);
                mask2.SetActive(false);
                mask3.SetActive(false);
                mask4.SetActive(false);
                current = 5;
                break;
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (current <= 4)
        {
            arrowright.SetActive(true);
            arrowleft.SetActive(false);
        }
        else if(current ==5)
        {
            arrowright.SetActive(false);
            arrowleft.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            current++;
            if (current > 5)
            {
                current = 5;
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            current--;
            if (current < 1)
            {
                current = 1;
            }
        }
        switch (current)
        {
            case 1:
                cursorani.SetInteger("cursor", 1);
                {
                    switch (level)
                    {
                        case 1:
                            bigspring.SetActive(true);
                            springani.SetBool("mov", true);
                            springcolor.SetActive(false);
                            autumngrey.SetActive(true);
                            wintergrey.SetActive(true);
                            summergrey.SetActive(true);
                            mask1.SetActive(true);
                            mask2.SetActive(true);
                            mask3.SetActive(true);
                            mask4.SetActive(true);
                            dragoncolor.SetActive(false);
                            dragongrey.SetActive(false);
                            dragonmask.SetActive(false);
                            break;
                        case 2:
                            bigspring.SetActive(true);
                            bigsummer.SetActive(true);
                            springani.SetBool("mov", true);
                            summerani.SetBool("mov", false);
                            springcolor.SetActive(false);
                            summercolor.SetActive(true);
                            wintergrey.SetActive(true);
                            autumngrey.SetActive(true);
                            mask1.SetActive(true);
                            mask2.SetActive(true);
                            mask3.SetActive(true);
                            mask4.SetActive(true);
                            dragoncolor.SetActive(false);
                            dragongrey.SetActive(false);
                            dragonmask.SetActive(false);
                            break;
                        case 3:
                            bigspring.SetActive(true);
                            bigsummer.SetActive(true);
                            bigautumn.SetActive(true);
                            springani.SetBool("mov", true);
                            summerani.SetBool("mov", false);
                            autumnani.SetBool("mov", false);
                            springcolor.SetActive(false);
                            summercolor.SetActive(true);
                            wintergrey.SetActive(true);
                            autumncolor.SetActive(true);
                            mask1.SetActive(true);
                            mask2.SetActive(true);
                            mask3.SetActive(true);
                            mask4.SetActive(true);
                            dragoncolor.SetActive(false);
                            dragongrey.SetActive(false);
                            dragonmask.SetActive(false);
                            break;
                        case 4:
                            bigspring.SetActive(true);
                            bigsummer.SetActive(true);
                            bigautumn.SetActive(true);
                            bigwinter.SetActive(true);
                            springani.SetBool("mov", true);
                            summerani.SetBool("mov", false);
                            autumnani.SetBool("mov", false);
                            winterani.SetBool("mov", false);
                            springcolor.SetActive(false);
                            summercolor.SetActive(true);
                            wintercolor.SetActive(true);
                            autumncolor.SetActive(true);
                            mask1.SetActive(true);
                            mask2.SetActive(true);
                            mask3.SetActive(true);
                            mask4.SetActive(true);
                            dragoncolor.SetActive(false);
                            dragongrey.SetActive(false);
                            dragonmask.SetActive(false);
                            break;
                        case 5:
                            bigspring.SetActive(true);
                            bigsummer.SetActive(true);
                            bigautumn.SetActive(true);
                            bigwinter.SetActive(true);
                            springani.SetBool("mov", true);
                            summerani.SetBool("mov", false);
                            autumnani.SetBool("mov", false);
                            winterani.SetBool("mov", false);
                            springcolor.SetActive(false);
                            summercolor.SetActive(true);
                            wintercolor.SetActive(true);
                            autumncolor.SetActive(true);
                            mask1.SetActive(true);
                            mask2.SetActive(true);
                            mask3.SetActive(true);
                            mask4.SetActive(true);
                            dragoncolor.SetActive(false);
                            dragongrey.SetActive(false);
                            dragonmask.SetActive(false);
                            break;

                    }
                }
                break;
            case 2:
                cursorani.SetInteger("cursor", 2);
                switch (level)
                {
                    case 1:
                        bigspring.SetActive(true);
                        springani.SetBool("mov", false);
                        springcolor.SetActive(true);
                        autumngrey.SetActive(true);
                        wintergrey.SetActive(true);
                        summergrey.SetActive(true);
                        mask1.SetActive(true);
                        mask2.SetActive(true);
                        mask3.SetActive(true);
                        mask4.SetActive(true);
                        dragoncolor.SetActive(false);
                        dragongrey.SetActive(false);
                        dragonmask.SetActive(false);
                        break;
                    case 2:
                        bigspring.SetActive(true);
                        bigsummer.SetActive(true);
                        springani.SetBool("mov", false);
                        summerani.SetBool("mov", true);
                        springcolor.SetActive(true);
                        summercolor.SetActive(false);
                        wintergrey.SetActive(true);
                        autumngrey.SetActive(true);
                        mask1.SetActive(true);
                        mask2.SetActive(true);
                        mask3.SetActive(true);
                        mask4.SetActive(true);
                        dragoncolor.SetActive(false);
                        dragongrey.SetActive(false);
                        dragonmask.SetActive(false);
                        break;
                    case 3:
                        bigspring.SetActive(true);
                        bigsummer.SetActive(true);
                        bigautumn.SetActive(true);
                        springani.SetBool("mov", false);
                        summerani.SetBool("mov", true);
                        autumnani.SetBool("mov", false);
                        springcolor.SetActive(true);
                        summercolor.SetActive(false);
                        wintergrey.SetActive(true);
                        autumncolor.SetActive(true);
                        mask1.SetActive(true);
                        mask2.SetActive(true);
                        mask3.SetActive(true);
                        mask4.SetActive(true);
                        dragoncolor.SetActive(false);
                        dragongrey.SetActive(false);
                        dragonmask.SetActive(false);
                        break;
                    case 4:
                        bigspring.SetActive(true);
                        bigsummer.SetActive(true);
                        bigautumn.SetActive(true);
                        bigwinter.SetActive(true);
                        springani.SetBool("mov", false);
                        summerani.SetBool("mov", true);
                        autumnani.SetBool("mov", false);
                        winterani.SetBool("mov", false);
                        springcolor.SetActive(true);
                        summercolor.SetActive(false);
                        wintercolor.SetActive(true);
                        autumncolor.SetActive(true);
                        mask1.SetActive(true);
                        mask2.SetActive(true);
                        mask3.SetActive(true);
                        mask4.SetActive(true);
                        dragoncolor.SetActive(false);
                        dragongrey.SetActive(false);
                        dragonmask.SetActive(false);
                        break;
                    case 5:
                        bigspring.SetActive(true);
                        bigsummer.SetActive(true);
                        bigautumn.SetActive(true);
                        bigwinter.SetActive(true);
                        springani.SetBool("mov", false);
                        summerani.SetBool("mov", true);
                        autumnani.SetBool("mov", false);
                        winterani.SetBool("mov", false);
                        springcolor.SetActive(true);
                        summercolor.SetActive(false);
                        wintercolor.SetActive(true);
                        autumncolor.SetActive(true);
                        mask1.SetActive(true);
                        mask2.SetActive(true);
                        mask3.SetActive(true);
                        mask4.SetActive(true);
                        dragoncolor.SetActive(false);
                        dragongrey.SetActive(false);
                        dragonmask.SetActive(false);
                        break;

                }
                break;
            case 3:
                cursorani.SetInteger("cursor", 3);
                switch (level)
                {
                    case 1:
                        bigspring.SetActive(true);
                        springani.SetBool("mov", false);
                        springcolor.SetActive(true);
                        autumngrey.SetActive(true);
                        wintergrey.SetActive(true);
                        summergrey.SetActive(true);
                        mask1.SetActive(true);
                        mask2.SetActive(true);
                        mask3.SetActive(true);
                        mask4.SetActive(true);
                        dragoncolor.SetActive(false);
                        dragongrey.SetActive(false);
                        dragonmask.SetActive(false);
                        break;
                    case 2:
                        bigspring.SetActive(true);
                        bigsummer.SetActive(true);
                        springani.SetBool("mov", false);
                        summerani.SetBool("mov", false);
                        springcolor.SetActive(true);
                        summercolor.SetActive(true);
                        wintergrey.SetActive(true);
                        autumngrey.SetActive(true);
                        mask1.SetActive(true);
                        mask2.SetActive(true);
                        mask3.SetActive(true);
                        mask4.SetActive(true);
                        dragoncolor.SetActive(false);
                        dragongrey.SetActive(false);
                        dragonmask.SetActive(false);
                        break;
                    case 3:
                        bigspring.SetActive(true);
                        bigsummer.SetActive(true);
                        bigautumn.SetActive(true);
                        springani.SetBool("mov", false);
                        summerani.SetBool("mov", false);
                        autumnani.SetBool("mov", true);
                        springcolor.SetActive(true);
                        summercolor.SetActive(true);
                        wintergrey.SetActive(true);
                        autumncolor.SetActive(false);
                        mask1.SetActive(true);
                        mask2.SetActive(true);
                        mask3.SetActive(true);
                        mask4.SetActive(true);
                        dragoncolor.SetActive(false);
                        dragongrey.SetActive(false);
                        dragonmask.SetActive(false);
                        break;
                    case 4:
                        bigspring.SetActive(true);
                        bigsummer.SetActive(true);
                        bigautumn.SetActive(true);
                        bigwinter.SetActive(true);
                        springani.SetBool("mov", false);
                        summerani.SetBool("mov", false);
                        autumnani.SetBool("mov", true);
                        winterani.SetBool("mov", false);
                        springcolor.SetActive(true);
                        summercolor.SetActive(true);
                        wintercolor.SetActive(true);
                        autumncolor.SetActive(false);
                        mask1.SetActive(true);
                        mask2.SetActive(true);
                        mask3.SetActive(true);
                        mask4.SetActive(true);
                        dragoncolor.SetActive(false);
                        dragongrey.SetActive(false);
                        dragonmask.SetActive(false);
                        break;
                    case 5:
                        bigspring.SetActive(true);
                        bigsummer.SetActive(true);
                        bigautumn.SetActive(true);
                        bigwinter.SetActive(true);
                        springani.SetBool("mov", false);
                        summerani.SetBool("mov", false);
                        autumnani.SetBool("mov", true);
                        winterani.SetBool("mov", false);
                        springcolor.SetActive(true);
                        summercolor.SetActive(true);
                        wintercolor.SetActive(true);
                        autumncolor.SetActive(false);
                        mask1.SetActive(true);
                        mask2.SetActive(true);
                        mask3.SetActive(true);
                        mask4.SetActive(true);
                        dragoncolor.SetActive(false);
                        dragongrey.SetActive(false);
                        dragonmask.SetActive(false);
                        break;

                }
                break;
            case 4:
                cursorani.SetInteger("cursor", 4);
                switch (level)
                {
                    case 1:
                        bigspring.SetActive(true);
                        springani.SetBool("mov", false);
                        springcolor.SetActive(true);
                        autumngrey.SetActive(true);
                        wintergrey.SetActive(true);
                        summergrey.SetActive(true);
                        mask1.SetActive(true);
                        mask2.SetActive(true);
                        mask3.SetActive(true);
                        mask4.SetActive(true);
                        dragoncolor.SetActive(false);
                        dragongrey.SetActive(false);
                        dragonmask.SetActive(false);
                        break;
                    case 2:
                        bigspring.SetActive(true);
                        bigsummer.SetActive(true);
                        springani.SetBool("mov", false);
                        summerani.SetBool("mov", false);
                        springcolor.SetActive(true);
                        summercolor.SetActive(true);
                        wintergrey.SetActive(true);
                        autumngrey.SetActive(true);
                        mask1.SetActive(true);
                        mask2.SetActive(true);
                        mask3.SetActive(true);
                        mask4.SetActive(true);
                        dragoncolor.SetActive(false);
                        dragongrey.SetActive(false);
                        dragonmask.SetActive(false);
                        break;
                    case 3:
                        bigspring.SetActive(true);
                        bigsummer.SetActive(true);
                        bigautumn.SetActive(true);
                        springani.SetBool("mov", false);
                        summerani.SetBool("mov", false);
                        autumnani.SetBool("mov", false);
                        springcolor.SetActive(true);
                        summercolor.SetActive(true);
                        wintergrey.SetActive(true);
                        autumncolor.SetActive(true);
                        mask1.SetActive(true);
                        mask2.SetActive(true);
                        mask3.SetActive(true);
                        mask4.SetActive(true);
                        dragoncolor.SetActive(false);
                        dragongrey.SetActive(false);
                        dragonmask.SetActive(false);
                        break;
                    case 4:
                        bigspring.SetActive(true);
                        bigsummer.SetActive(true);
                        bigautumn.SetActive(true);
                        bigwinter.SetActive(true);
                        springani.SetBool("mov", false);
                        summerani.SetBool("mov", false);
                        autumnani.SetBool("mov", false);
                        winterani.SetBool("mov", true);
                        springcolor.SetActive(true);
                        summercolor.SetActive(true);
                        wintercolor.SetActive(false);
                        autumncolor.SetActive(true);
                        mask1.SetActive(true);
                        mask2.SetActive(true);
                        mask3.SetActive(true);
                        mask4.SetActive(true);
                        dragoncolor.SetActive(false);
                        dragongrey.SetActive(false);
                        dragonmask.SetActive(false);
                        break;
                    case 5:
                        bigspring.SetActive(true);
                        bigsummer.SetActive(true);
                        bigautumn.SetActive(true);
                        bigwinter.SetActive(true);
                        springani.SetBool("mov", false);
                        summerani.SetBool("mov", false);
                        autumnani.SetBool("mov", false);
                        winterani.SetBool("mov", true);
                        springcolor.SetActive(true);
                        summercolor.SetActive(true);
                        wintercolor.SetActive(false);
                        autumncolor.SetActive(true);
                        mask1.SetActive(true);
                        mask2.SetActive(true);
                        mask3.SetActive(true);
                        mask4.SetActive(true);
                        dragoncolor.SetActive(false);
                        dragongrey.SetActive(false);
                        dragonmask.SetActive(false);
                        break;

                }
                break;
            case 5:
                cursorani.SetInteger("cursor", 5);
                switch (level)
                {
                    case 1:
                        dragoncolor.SetActive(false);
                        dragongrey.SetActive(true);
                        dragonmask.SetActive(true);
                        mask1.SetActive(false);
                        mask2.SetActive(false);
                        mask3.SetActive(false);
                        mask4.SetActive(false);
                        break;
                    case 2:
                        dragongrey.SetActive(true);
                        dragonmask.SetActive(true);
                        mask1.SetActive(false);
                        mask2.SetActive(false);
                        mask3.SetActive(false);
                        mask4.SetActive(false);
                        break;
                    case 3:
                        dragongrey.SetActive(true);
                        dragonmask.SetActive(true);
                        mask1.SetActive(false);
                        mask2.SetActive(false);
                        mask3.SetActive(false);
                        mask4.SetActive(false);
                        break;
                    case 4:
                        dragongrey.SetActive(true);
                        dragonmask.SetActive(true);
                        mask1.SetActive(false);
                        mask2.SetActive(false);
                        mask3.SetActive(false);
                        mask4.SetActive(false);
                        break;
                    case 5:
                        dragoncolor.SetActive(true);
                        dragongrey.SetActive(false);
                        dragonmask.SetActive(true);
                        mask1.SetActive(false);
                        mask2.SetActive(false);
                        mask3.SetActive(false);
                        mask4.SetActive(false);
                        break;


                }
                break;
        }



        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (current == 1)
            {
                exitint = 1;
                
            }
            else if (current == 2 && level >= 2)
            {
                exitint = 2;
                

            }
            else if (current == 3 && level >= 3)
            {
                exitint = 3;
                

            }
         
            else if (current == 4 && level >= 4)
            {
                exitint = 4;
                

            }
            else if (current == 5 && level == 5)
            {
                exitint = 5;
                

            }

            tn1.SetTrigger("in");
            tn2.SetTrigger("in");
            tn1.SetBool("exit", true);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            exitint = -1;
            tn1.SetTrigger("in");
            tn2.SetTrigger("in");
            tn1.SetBool("exit", true);
        }
           
    }

    void exitseq()
    {
        switch (exitint)
        {
            case 1:
                SceneManager.LoadScene("test");
                break;
            case 2:
                SceneManager.LoadScene("summer");
                break;
            case 3:
                SceneManager.LoadScene("autumn");
                break;
            case 4:
                SceneManager.LoadScene("winter");
                break;
            case 5:
                SceneManager.LoadScene("boss");
                break;
            case -1:
                SceneManager.LoadScene("menu");
                break;
        }
    }

}
