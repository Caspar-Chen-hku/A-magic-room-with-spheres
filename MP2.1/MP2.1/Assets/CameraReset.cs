using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraReset : MonoBehaviour {
    public Transform t;
	// Use this for initialization
	void Start () {
        t = this.gameObject.transform.GetChild(0);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            transform.position -= t.position;
        }
	}
}