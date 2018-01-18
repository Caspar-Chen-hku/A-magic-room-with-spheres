using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class ToggleTracking : MonoBehaviour {
    bool trackingRot;
    bool trackingPos;

    GameObject cam;
    Quaternion camRot;
    Vector3 camRotAng;

    Quaternion negRot;
    Vector3 negAng;
    Quaternion initialRotation;

	// Use this for initialization
	void Start () {
        trackingRot = true;
        trackingPos = true;
        cam = GameObject.Find("Main Camera");
        initialRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
        camRot = cam.transform.rotation;
        camRotAng = camRot.eulerAngles;
        if (Input.GetKeyDown(KeyCode.R))
        {
            trackingRot = !trackingRot;
            if (!trackingRot)
            {
                print("Rotation tracking disabled");
            }
            else
                print("Rotation tracking enabled");
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            trackingPos = !trackingPos;
            if (!trackingPos)
            {
                print("Position tracking disabled");
            }
            else
                print("Position tracking enabled");
        }

        if (trackingRot)
        {
            transform.rotation = initialRotation;
        }
        if (!trackingRot)
        {
            negRot = Quaternion.Inverse(cam.transform.localRotation);
            negAng = negRot.eulerAngles;
            transform.eulerAngles = new Vector3(negAng.x, negAng.y + 180, negAng.z);
        }

        //if (!trackingPos)
        //{
        //    InputTracking.disablePositionalTracking = true;
        //}
        //else if (trackingPos)
        //{
        //    InputTracking.disablePositionalTracking = false;
        //}
        if (!trackingPos)
        {
            transform.position = new Vector3(-cam.transform.localPosition.x, -cam.transform.localPosition.y, -cam.transform.localPosition.z);
            //print(new Vector3(-cam.transform.localPosition.x, -cam.transform.localPosition.y, -cam.transform.localPosition.z));
        }
        if (trackingPos)
        {
            transform.position = new Vector3(0, 0, 0);
        }
    }
}
