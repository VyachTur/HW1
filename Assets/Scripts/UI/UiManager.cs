using System;
using GameSystem;
using GameSystem.InterfaceListeners;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace UI
{
    public class UiManager : MonoBehaviour, IStartGameListener, IEndGameListener
    {
        [Header("Systems")] 
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private CrashListener _crashListener;
        [SerializeField] private FinishListener _finishListener;
        [SerializeField] private StartGameManager _startGameManager;

        
        #region UI Elements

        // StartGame OpenMenu
        [Header("UI Elements")]
        [SerializeField] private Button _startGameButton;
        [SerializeField] private Button _openMenuButton;

        // Finish GameOver
        [Space]
        [SerializeField] private TMP_Text _endGameText;
        
        // Menu Panel
        [Space]
        [SerializeField] private Button _continueButton;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _quitButton;
        
        [Space]
        [SerializeField] private TMP_Text _timerText;

        #endregion

        private void Awake()
        {
            _startGameButton.enabled = true;
        }

        void IStartGameListener.OnStartGame()
        {
            _crashListener.OnCrashEvent += ShowText;
            _finishListener.OnFinishEvent += ShowText;
            _startGameButton.onClick.AddListener(_startGameManager.StartGame);
        }
    
        void IEndGameListener.OnEndGame()
        {
            _crashListener.OnCrashEvent -= ShowText;
            _finishListener.OnFinishEvent -= ShowText;
            _startGameButton.onClick.RemoveListener(_startGameManager.StartGame);
        }

        private void ShowText(string text)
        {
            _endGameText.text = text;
            _endGameText.enabled = true;
        }
    }
}
