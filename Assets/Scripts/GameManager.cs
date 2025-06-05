using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool _isGameOver;
    public bool isPlatformer = true;
    public bool IsGameOver
    {
        get {  return _isGameOver; }
        set { _isGameOver = value; }
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.RightAlt))
        {
            PlayerPrefs.DeleteKey("FoundObjects");
            GameObject.FindGameObjectWithTag("InventoryManager").GetComponent<InventoryManager>().DeleteInventory();
            PlayerPrefs.DeleteKey("InventoryData");
            PlayerPrefs.Save();
        }
    }
}
