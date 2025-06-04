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
}
