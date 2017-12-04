using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseText : MonoBehaviour {

    Renderer rend;
    Color colorStart;
    Color colorEnd;
    

    // Use this for initialization
    void Start () {
        rend = gameObject.GetComponent<Renderer>();
        colorStart = rend.material.color;
    }
	
	// Update is called once per frame
	void Update () {
        float lerp = Mathf.PingPong(Time.time, 1.0f) / 1.0f;

        float alpha = Mathf.Lerp(0.0f, 1.0f, lerp);
        rend.material.color = new Color(colorStart.r, colorStart.g, colorStart.b, alpha); ;
    }
}
