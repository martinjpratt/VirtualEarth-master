using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateDistance : MonoBehaviour {
    public GameObject ball1;
    public GameObject ball2;
    public GameObject directText;
    public GameObject horizontalText;
    public GameObject verticalText;
    float dist;
    LineRenderer line;
    LineRenderer line2;
    public Material measuringTape;

    // Use this for initialization
    void Start () {
        

        line = gameObject.AddComponent<LineRenderer>();
        line.material = measuringTape;
        line.widthMultiplier = 0.01f;
        line.positionCount = 4;
        line.SetPosition(0, ball1.transform.position);
        line.SetPosition(1, ball2.transform.position);
        line.SetPosition(2, new Vector3(ball1.transform.localPosition.x, ball2.transform.position.y, ball1.transform.position.z));
        line.SetPosition(3, ball1.transform.position);
    }
	
	// Update is called once per frame
	void Update () {
        dist = Vector3.Distance(ball1.transform.position, ball2.transform.position) / ScaleManager.outcropScale;
        float yDist = Mathf.Abs(ball2.transform.position.y - ball1.transform.position.y) / ScaleManager.outcropScale;
        float xDist = Mathf.Abs(Vector2.Distance(new Vector2(ball2.transform.position.x, ball2.transform.position.z), new Vector2(ball1.transform.position.x, ball1.transform.position.z))) / ScaleManager.outcropScale;

        line.SetPosition(0, ball1.transform.position);
        line.SetPosition(1, ball2.transform.position);
        line.SetPosition(2, new Vector3(ball1.transform.position.x, ball2.transform.position.y, ball1.transform.position.z));
        line.SetPosition(3, ball1.transform.position);

        directText.GetComponent<TextMesh>().text = "Direct: " + dist.ToString("#.00");
        horizontalText.GetComponent<TextMesh>().text = "Horizontal: " + xDist.ToString("#.00");
        verticalText.GetComponent<TextMesh>().text = "Vertical: " + yDist.ToString("#.00");
    }
}
