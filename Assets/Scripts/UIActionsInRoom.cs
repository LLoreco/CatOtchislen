using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIActionsInRoom : MonoBehaviour
{
    private bool _isInventoryOpened = false;
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void SaveGame()
    {
        print("Игра Сохранена");
    }
    public void OpenInventory()
    {
        _isInventoryOpened = !_isInventoryOpened;
        GameObject.FindGameObjectWithTag("InventoryManager").GetComponent<InventoryManager>().ToggleInventory(_isInventoryOpened);
    }
}
