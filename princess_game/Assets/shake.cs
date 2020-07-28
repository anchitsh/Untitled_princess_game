using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shake : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void shakeplstail()
    {
        shakecine.flip = true;
        shakecine.ShakeDuration = 0.5f;
        shakecine.ShakeAmplitude = 1;
    }
    void shakeplshead()
    {
        shakecine.flip = true;
        shakecine.ShakeDuration = 1.5f;
        shakecine.ShakeAmplitude = 2;
    }
    void spawnshit()
    {

    }
}
