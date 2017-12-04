using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using System;

public class PositionCompass : MonoBehaviour {



	// Use this for initialization
	void Start () {
        //updatePosition();
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    public void updatePosition()
    {
        gameObject.transform.position = GazeManager.Instance.HitInfo.point;
    }
}
