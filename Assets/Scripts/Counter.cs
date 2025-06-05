using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Counter : MonoBehaviour
{
    private int objectCounter = 0;
    [SerializeField] private GameObject chortScreen;
    [SerializeField] private GameObject[] catScreens;
    [SerializeField] private GameObject _chortButton;
    private void Awake()
    {
        if (PlayerPrefs.HasKey("IndexChort"))
        {
            string[] items = PlayerPrefs.GetString("IndexChort").Split(",");
            foreach (var itemName in items)
            {
                if (itemName == SceneManager.GetActiveScene().name)
                {
                    _chortButton.SetActive(true);
                }
                else
                {
                    _chortButton.SetActive(false);
                }
            }
        }
    }
    void Update()
    {
        if (PlayerPrefs.HasKey("IndexChort"))
        {
            string[] items = PlayerPrefs.GetString("IndexChort").Split(",");
            foreach (var itemName in items)
            {
                if (itemName == SceneManager.GetActiveScene().name)
                {
                    _chortButton.SetActive(true);
                }
            }
        }
        if (objectCounter == 2)
        {
            SaveState();
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
    private void SaveState()
    {
        PlayerPrefs.SetString("IndexChort",SceneManager.GetActiveScene().name + ",");
        PlayerPrefs.Save();
    }
}
