using UnityEngine;
using System.Collections;

public class ExampleClass : MonoBehaviour {
	void Update() {
		Debug.DrawLine(Vector3.zero, new Vector3(1, 0, 0), Color.red);
	}
}