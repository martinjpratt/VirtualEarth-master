using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class RotateToTime : MonoBehaviour {

	// Use this for initialization
	void Start () {
        float hh = DateTime.UtcNow.Hour;
        float mm = DateTime.UtcNow.Minute;
        float rotAngle = ((180-(hh - (mm / 60))) / 24) * 360;
        transform.Rotate(new Vector3(0, rotAngle, 0), Space.Self);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
