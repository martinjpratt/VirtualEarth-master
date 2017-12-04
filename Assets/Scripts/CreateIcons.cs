using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule.Tests;

public class CreateIcons : MonoBehaviour
{

    public GameObject iconPrefab;
    public GameObject additionalPrefab;
    public GameObject[] targetObjects;

    float earthRadius = 1f;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(Check());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator Check()
    {
        WWW w = new WWW("http://epsc.wustl.edu/~martinpratt/AssetBundles/MetaData.txt");
        yield return w;
        if (w.error != null)
        {
            Debug.Log("Error .. " + w.error);
        }
        else
        {
            Debug.Log("Found ... ==>" + w.text + "<==");
        }

        var iconList = w.text.Split("\n"[0]);
        for (int i = 0; i < iconList.Length; i++)
        {
            var dataList = iconList[i].Split("\t"[0]);

            GameObject newIconPrefab = Instantiate(iconPrefab);
            newIconPrefab.transform.SetParent(this.transform);

            newIconPrefab.GetComponentInChildren<TextMesh>().text = dataList[0];

            GameObject bc = newIconPrefab.transform.GetChild(1).gameObject;
            bc.AddComponent<BoxCollider>();
            newIconPrefab.name = (dataList[0] + " Button");
            float lon = float.Parse(dataList[1]);
            float lat = float.Parse(dataList[2]);

            float xpos = earthRadius * Mathf.Cos(lat * Mathf.Deg2Rad) * Mathf.Cos((lon - 90) * Mathf.Deg2Rad) * -1;
            float zpos = earthRadius * Mathf.Cos(lat * Mathf.Deg2Rad) * Mathf.Sin((lon - 90) * Mathf.Deg2Rad) * -1;
            float ypos = earthRadius * Mathf.Sin(lat * Mathf.Deg2Rad);

            newIconPrefab.transform.localPosition = new Vector3(xpos, ypos, zpos);
            newIconPrefab.transform.localEulerAngles = new Vector3(-(90 - lat), -180, 0);
            newIconPrefab.transform.Rotate(Vector3.up, -lon, Space.World);

            float numberOfAdditionals = float.Parse(dataList[3]);
            if (numberOfAdditionals > 1)
            {
                Destroy(bc.GetComponent<TapResponderWithComponent>());
                bc.AddComponent<MenuDropDown>();
                


                for (int j = 0; j < numberOfAdditionals; j++)
                {
                    GameObject newMenuPrefab = Instantiate(additionalPrefab);
                    bc.GetComponent<MenuDropDown>().iList.Add(newMenuPrefab);
                    newMenuPrefab.transform.SetParent(bc.transform);
                    newMenuPrefab.tag = "menuItem";
                    newMenuPrefab.transform.localPosition = new Vector3(0, 0, 0);
                    newMenuPrefab.transform.localScale = new Vector3(1, 1, 1);
                    newMenuPrefab.name = (dataList[(j * 3) + 4] + "Button");
                    newMenuPrefab.GetComponent<MenuAnimationController>().distanceDown = -14 * (j + 1);
                    newMenuPrefab.GetComponent<TextMesh>().text = dataList[(j*3) + 4];
                    newMenuPrefab.AddComponent<BoxCollider>();

                    foreach (GameObject go in targetObjects)
                    {
                        if (go.name == dataList[(j*3) + 5])
                        {
                            newMenuPrefab.GetComponentInChildren<TapResponderWithComponent>().GoToObject = go;
                        }
                        else
                        {
                            if (go.name == dataList[(j*3) + 6])
                            {
                                newMenuPrefab.GetComponentInChildren<TapResponderWithComponent>().TurnOffObject = go;
                            }
                        }
                    }

                }


            }
            else
            {
                foreach (GameObject go in targetObjects)
                {
                    if (go.name == dataList[4])
                    {
                        newIconPrefab.GetComponentInChildren<TapResponderWithComponent>().GoToObject = go;
                    }
                    else
                    {
                        if (go.name == dataList[5])
                        {
                            newIconPrefab.GetComponentInChildren<TapResponderWithComponent>().TurnOffObject = go;
                        }
                    }
                }
            }
            
            

        }


    }
}
