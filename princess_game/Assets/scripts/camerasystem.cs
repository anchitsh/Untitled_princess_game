using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerasystem : MonoBehaviour
{
    public GameObject[] cameras;
    public static int camint;
    // Start is called before the first frame update
    void Start()
    {
        camint = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(camint == 2)
        {
            cameras[0].SetActive(true);
            cameras[1].SetActive(false);
            cameras[2].SetActive(false);
            cameras[3].SetActive(false);
            cameras[4].SetActive(false);
        }
        else if (camint == 3)
        {
            cameras[1].SetActive(true);
            cameras[0].SetActive(false);
            cameras[2].SetActive(false);
            cameras[3].SetActive(false);
            cameras[4].SetActive(false);

        }
        else if (camint == 4)
        {
            cameras[1].SetActive(false);
            cameras[0].SetActive(false);
            cameras[2].SetActive(true);
            cameras[3].SetActive(false);
            cameras[4].SetActive(false);

        }
        else if (camint == 5)
        {
            cameras[1].SetActive(false);
            cameras[0].SetActive(false);
            cameras[2].SetActive(false);
            cameras[3].SetActive(true);
            cameras[4].SetActive(false);

        }
        else if (camint == 6)
        {
            cameras[1].SetActive(false);
            cameras[0].SetActive(false);
            cameras[2].SetActive(false);
            cameras[3].SetActive(false);
            cameras[4].SetActive(true);

        }
    }
}
