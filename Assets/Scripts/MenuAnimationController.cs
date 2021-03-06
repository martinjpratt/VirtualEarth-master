﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimationController : MonoBehaviour {

    public float distanceDown;
    public float speed = 1.0F;
    private float startTime;
    private float journeyLength;


    // Use this for initialization
    void Start () {
        startTime = Time.time;
        journeyLength = Vector3.Distance(transform.localPosition, new Vector3(0, distanceDown, 0));

    }
	
	// Update is called once per frame
	void Update () {
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(0, distanceDown, 0), fracJourney);

    }
}
