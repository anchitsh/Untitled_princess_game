using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UItrans : MonoBehaviour
{
    int exitint, startint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        exitint = levelselectui.exitint;
        startint = UImanager.startint;
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
    void exitstart()
    {
        switch (startint)
        {
            case -1:
                Application.Quit();
                break;
            case 1:
                SceneManager.LoadScene("intro");
                break;
            case 2:
                SceneManager.LoadScene("test");
                break;
            case 3:
                SceneManager.LoadScene("test");
                break;         
        }
    }
}
