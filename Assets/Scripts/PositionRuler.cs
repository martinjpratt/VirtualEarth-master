using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class PositionRuler : MonoBehaviour {
    public GameObject measureSphere;

    public void updatePosition()
    {
        gameObject.transform.position = GazeManager.Instance.HitInfo.point;
    }

    public void measurePosition()
    {
        measureSphere.transform.position = GazeManager.Instance.HitInfo.point;
    }
}
