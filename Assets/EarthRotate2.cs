using UnityEngine;
using System.Collections;

public class EarthRotate2 : MonoBehaviour {
	bool hasGrabbedPoint = false;
	Vector3 grabbedPoint;
	float minFov = 15f;
	float maxFov = 90f;
	float sensitivity = 10f;

	void Update () { 
		float fov = Camera.main.fieldOfView;
		fov -= Input.GetAxis("Mouse ScrollWheel") * sensitivity;
		fov = Mathf.Clamp(fov, minFov, maxFov);
		Camera.main.fieldOfView = fov;


		if (Input.GetMouseButton(0)) { 
			if(!hasGrabbedPoint) { 
				hasGrabbedPoint = true; 
				grabbedPoint = getTouchedPoint(); 
			} else { 
				Vector3 targetPoint = getTouchedPoint();
                Debug.Log("Mouse target point:");
                Debug.Log(targetPoint);
				Quaternion rot = Quaternion.FromToRotation (grabbedPoint, targetPoint); 
				transform.localRotation *= rot; 
			} 
		} else hasGrabbedPoint = false; 
	}


	Vector3 getTouchedPoint() { 
		RaycastHit hit; Physics.Raycast (Camera.main.ScreenPointToRay(Input.mousePosition), out hit);
		return transform.InverseTransformPoint(hit.point);
	}


}
