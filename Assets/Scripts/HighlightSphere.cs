using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using System;

public class HighlightSphere : MonoBehaviour, IFocusable {

    Material mat;

    public void OnFocusEnter()
    {
        mat = gameObject.GetComponent<Renderer>().material;
        mat.SetColor("_EmissionColor", Color.magenta);
    }

    public void OnFocusExit()
    {
        mat.SetColor("_EmissionColor", Color.black);
    }



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
