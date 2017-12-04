// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using UnityEngine;

namespace HoloToolkit.Unity.InputModule.Tests
{
    /// <summary>
    /// This class implements IInputClickHandler to handle the tap gesture.
    /// It increases the scale of the object when tapped.
    /// </summary>
    public class TapResponderWithComponent : MonoBehaviour, IInputClickHandler, IFocusable
    {
        public GameObject GoToObject;
        public GameObject TurnOffObject;

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
            GameObject[] flags = GameObject.FindGameObjectsWithTag("flag");
            foreach (GameObject fl in flags) {
                Destroy(fl);
            }
            TurnOffObject.SetActive(false);
            GoToObject.SetActive(true);
            GazeAudio.Instance.PlayClickSound();
            cachedMaterial.SetColor("_Color", originalColor);
        }
       

        //public void OnInputClicked(InputClickedEventData eventData)
        //{

        //        }
    }
}