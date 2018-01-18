using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateStimuli : MonoBehaviour
{
    float disB1;
    float disB2;
    float disR;
    float size;

    float countdown;

    bool scaling;
    bool appearing;
    bool waiting;

    Renderer R;
    Renderer B1;
    Renderer B2;
    // Use this for initialization
    void Start()
    {
        scaling = false;
        appearing = true;
        R = transform.Find("Red").GetComponent<Renderer>();
        B1 = transform.Find("Blue_one").GetComponent<Renderer>();
        B2 = transform.Find("Blue_two").GetComponent<Renderer>();
        countdown = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && !scaling)
        {
            scaling = true;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(WaitForIt());
        }

        if (scaling)
        {
            disR = Vector3.Distance(transform.GetChild(0).transform.position, GameObject.Find("Main Camera").transform.position);
            disB1 = Vector3.Distance(transform.GetChild(1).transform.position, GameObject.Find("Main Camera").transform.position);
            disB2 = Vector3.Distance(transform.GetChild(2).transform.position, GameObject.Find("Main Camera").transform.position);
            size = (disB1 / disR) * (float)0.5;
            transform.GetChild(1).transform.localScale = new Vector3(size, size, size);
            size = (disB2 / disR) * (float)0.5;
            transform.GetChild(2).transform.localScale = new Vector3(size, size, size);
        }
    }
    IEnumerator WaitForIt()
    {
        R.enabled = !R.enabled;
        yield return new WaitForSeconds(2);
        B1.enabled = !B1.enabled;
        B2.enabled = !B2.enabled;
    }
}
