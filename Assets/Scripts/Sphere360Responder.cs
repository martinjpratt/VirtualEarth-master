using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using System;

public class Sphere360Responder : MonoBehaviour, IInputClickHandler, IFocusable {

    public GameObject TurnOffObject;
    public bool selected = false;
    Material startMaterial;
    public Material backMaterial;

    public void OnFocusEnter()
    {
        
    }

    public void OnFocusExit()
    {
        
    }

    // Use this for initialization
    void Awake()
    {
        startMaterial = GetComponent<Renderer>().material;
    }


    public void OnInputClicked(InputClickedEventData eventData)
    {
        if (selected != true)
        {
            TurnOffObject.SetActive(false);
            Camera.main.clearFlags = CameraClearFlags.Skybox;
            GetComponent<Renderer>().material = backMaterial;
            selected = true;

        }
        else
        {
            TurnOffObject.SetActive(true);
            Camera.main.clearFlags = CameraClearFlags.SolidColor;
            GetComponent<Renderer>().material = startMaterial;
            selected = false;
        }

    }


	
	// Update is called once per frame
	void Update () {
		
	}
}
