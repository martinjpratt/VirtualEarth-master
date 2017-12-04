using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSun : MonoBehaviour
{
    public Vector3 targetAngle = new Vector3(45f, 0f, 0f);

    private Vector3 currentAngle;


    // Use this for initialization
    void Start()
    {
        currentAngle = transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        currentAngle = new Vector3(
            Mathf.LerpAngle(currentAngle.x, targetAngle.x, Time.deltaTime / 2f),
            Mathf.LerpAngle(currentAngle.y, targetAngle.y, Time.deltaTime / 2f),
            Mathf.LerpAngle(currentAngle.z, targetAngle.z, Time.deltaTime / 2f));

        transform.eulerAngles = currentAngle;
    }
}
