using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private int objectCounter = 0;
    [SerializeField] private GameObject chortScreen;
    [SerializeField] private GameObject[] catScreens;
    void Update()
    {
        if (objectCounter == 2)
        {
            foreach (GameObject catScreen in catScreens)
            {
                catScreen.SetActive(false);
            }
            chortScreen.SetActive(true);
        }
    }
    public void PlusObject()
    {
        objectCounter++;
    }
}
