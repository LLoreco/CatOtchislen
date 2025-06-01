using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIActionsInRoom : MonoBehaviour
{
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
        print("Инвентарь открыт");
    }
}
