using System;
using UnityEngine;
using HoloToolkit.Unity;
using HoloToolkit.Sharing;

namespace HoloToolkit.Unity.InputModule.Tests
{

    public class TapScaleResponder : MonoBehaviour, IInputClickHandler, IFocusable
    {
        GameObject ScalingObject;
        public float xPos;
        public float yPos;
        public float zPos;
        public float scaleValue;

        


        Material cachedMaterial;
        Color originalColor;

        private void Awake()
        {
            cachedMaterial = GetComponent<Renderer>().material;
            originalColor = cachedMaterial.GetColor("_Color");
        }


        public void OnFocusEnter()
        {
            cachedMaterial.SetColor("_Color", Color.red);
        }

        public void OnFocusExit()
        {
            cachedMaterial.SetColor("_Color", originalColor);
        }

        public void OnInputClicked(InputClickedEventData eventData)
        {
            ScalingObject = GameObject.FindGameObjectWithTag("scalable");
            ScalingObject.transform.localPosition = new Vector3(xPos,yPos,zPos);
            ScalingObject.transform.localScale = new Vector3(scaleValue,scaleValue,scaleValue);
            ScalingObject.AddComponent<HandDragging>();
            ScaleManager.outcropScale = scaleValue;

            GazeAudio.Instance.PlayClickSound();
            cachedMaterial.SetColor("_Color", originalColor);
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
