using System.Collections;
using System.Collections.Generic;
using GameSystem;
using GameSystem.InterfaceListeners;
using UnityEngine;

public class StartGameManager : MonoBehaviour
{
    [SerializeField] private IGameManager _gameManager;

    public void StartGame() => 
        _gameManager.StartGame();
}
