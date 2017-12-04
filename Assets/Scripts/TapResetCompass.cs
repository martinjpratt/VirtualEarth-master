using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloToolkit.Unity.InputModule.Tests
{
    public class TapResetCompass : MonoBehaviour, IInputClickHandler, IFocusable
    {

        public GameObject resetObject;

        Material cachedMaterial;
        Color originalColor;
        Vector3 originalPosition;

        private void Awake()
        {
            cachedMaterial = GetComponent<Renderer>().material;
            originalColor = cachedMaterial.GetColor("_Color");

            originalPosition = resetObject.transform.localPosition;
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
            resetObject.transform.localPosition = originalPosition;
            
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
