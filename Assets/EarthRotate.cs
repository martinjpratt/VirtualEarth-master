using UnityEngine;
using System.Collections;

public class EarthRotate : MonoBehaviour {

	private float _sensitivity;
	private Vector3 _mouseReference;
	private Vector3 _mouseOffset;
	private Vector3 _rotation;
	private bool _isRotating;

	void Start ()
	{
		_sensitivity = 0.4f;
		//_rotation = Vector3.forward;
	}


		void Update()
	{
		//rotate around the World's Y axis
		//transform.Rotate (Vector3.forward * Time.deltaTime * 4);
		_rotation = Vector3.forward;
		
		if (_isRotating) {
			// offset
			_mouseOffset = (Input.mousePosition - _mouseReference);

			// apply rotation
			_rotation.z = -(_mouseOffset.x + _mouseOffset.y) * _sensitivity;
			//_rotation.y = -(_mouseOffset.x) * _sensitivity;


			// rotate
			transform.Rotate (_rotation);

			// store mouse
			_mouseReference = Input.mousePosition;
		}
	}

	void OnMouseDown()
	{
		// rotating flag
		_isRotating = true;

		// store mouse
		_mouseReference = Input.mousePosition;
	}

	void OnMouseUp()
	{
		// rotating flag
		_isRotating = false;
	}
}
