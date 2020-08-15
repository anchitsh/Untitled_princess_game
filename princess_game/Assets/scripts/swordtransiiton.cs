using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordtransiiton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void charoff()
    {
        charController.charcontrollerenabled = false;
    }

    void charon()
    {
        charController.charcontrollerenabled = true;
    }
}
