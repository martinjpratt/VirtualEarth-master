using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitGround : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(GetComponent<Rigidbody>());
        //Vector3 hitPos = 
        //Vector3 hitNorm = 
        //transform.rotation = Quaternion.FromToRotation(Vector3.up, hitNorm);
        
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
