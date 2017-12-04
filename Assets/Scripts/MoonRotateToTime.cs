using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoonRotateToTime : MonoBehaviour {

    float period = 27.232f;
    float radius = 5;
    DateTime startTime = DateTime.Parse("2017-09-06T08:03");

	// Use this for initialization
	void Start () {
        DateTime dateNow = DateTime.Now;
        
        double totalDays = (dateNow-startTime).TotalDays;

        float numberOfPeriods = (float)totalDays / period;

        float x = radius * Mathf.Cos(-numberOfPeriods * 2 * Mathf.PI);
        float y = radius * Mathf.Sin(-numberOfPeriods * 2 * Mathf.PI);

        transform.localPosition = new Vector3(y, 0, x);
        transform.Rotate(0,  (Mathf.Rad2Deg * -numberOfPeriods * 2 * Mathf.PI), 0,Space.Self);
    }
}
