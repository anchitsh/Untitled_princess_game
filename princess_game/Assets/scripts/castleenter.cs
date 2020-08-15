using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class castleenter : MonoBehaviour
{
    public GameObject toposition;
    Rigidbody2D rb;
   // public CinemachineVirtualCamera camera1, camera2;
    public GameObject cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            rb = other.gameObject.GetComponent<Rigidbody2D>();
            
            

            level1transition.switchon = true;
            
            StartCoroutine(tns());
        }

    }
    IEnumerator tns()
    {
        float duration = Time.time + 1f;
        while (Time.time < duration)
        {

            yield return null;

        }
        if (Time.time > duration)
        {
            cam.SetActive(!cam.activeSelf);

            rb.transform.position = new Vector2(toposition.transform.position.x, rb.transform.position.y);
            paraswitch.parswitch();
            StopCoroutine(tns());
        }

    }
}
