using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRMirror : MonoBehaviour {
    bool pushed = false;
    GameObject cam;
    Vector3 dis;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        cam = GameObject.Find("Main Camera");
        print(dis);
        if (Input.GetKeyDown(KeyCode.M))
        {

        }

    }
}
