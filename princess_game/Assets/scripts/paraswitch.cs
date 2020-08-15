using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paraswitch : MonoBehaviour
{
    public static parallaxfixed par;
    // Start is called before the first frame update
    void Start()
    {
        par = GetComponent<parallaxfixed>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public static void parswitch()
    {
        par.enabled = !par.enabled;
    }
}
