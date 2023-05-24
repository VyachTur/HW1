using GameSystem;
using GameSystem.InterfaceListeners;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UiManager : MonoBehaviour, ILoadGameListener, IStartGameListener, IEndGameListener
    {
        [Header("Systems")] 
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private CrashListener _crashListener;
        [SerializeField] private FinishListener _finishListener;
        [SerializeField] private StartGameManager _startGameManager;
        [SerializeField] private QuitGameManager _quitGameManager;

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
        [SerializeField] private GameObject _panel;
        [SerializeField] private Button _continueButton;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _quitButton;
        
        [Space]
        [SerializeField] private TMP_Text _timerText;

        #endregion

        private void Start()
        {
            _gameManager.LoadGame();
            _startGameManager.OnTimerTickEvent += ShowTimer;
            
            _startGameButton.gameObject.SetActive(true);
            _startGameButton.onClick.AddListener(StartGame);
        }

        private void ShowTimer(int timer)
        {
            _timerText.enabled = true;
            _timerText.text = timer.ToString();
        }

        void ILoadGameListener.OnLoadGame()
        {
            _panel.SetActive(false);
            EndGameTextClear();
        }

        void IStartGameListener.OnStartGame()
        {
            _timerText.enabled = false;
            
            _crashListener.OnCrashEvent += GameEnd;
            _finishListener.OnFinishEvent += GameEnd;
            
            _openMenuButton.onClick.AddListener(ShowPausedMenu);
            
            _continueButton.onClick.AddListener(ResumeGame);
            _restartButton.onClick.AddListener(() => RestartGame(0f));
            _quitButton.onClick.AddListener(QuitGame);
        }

        void IEndGameListener.OnEndGame()
        {
            _crashListener.OnCrashEvent -= GameEnd;
            _finishListener.OnFinishEvent -= GameEnd;
            
            _openMenuButton.onClick.RemoveListener(ShowPausedMenu);
            _startGameButton.onClick.RemoveListener(StartGame);
            
            _continueButton.onClick.RemoveListener(ResumeGame);
            _restartButton.onClick.RemoveListener(() => RestartGame(0f));
            _quitButton.onClick.RemoveListener(QuitGame);
            
            _startGameManager.OnTimerTickEvent -= ShowTimer;
        }
        
        private void StartGame()
        {
            _startGameManager.StartGame();
            _startGameButton.gameObject.SetActive(false);;
            _openMenuButton.gameObject.SetActive(true);
        }

        private void ResumeGame()
        {
            _gameManager.ResumeGame();
            _panel.SetActive(false);
            _openMenuButton.gameObject.SetActive(true);
        }

        private void RestartGame(float delaySecond) => 
            _startGameManager.RestartGame(delaySecond);

        private void QuitGame() =>
            _quitGameManager.Quit();

        private void GameEnd(string text)
        {
            ShowText(text);
            _openMenuButton.gameObject.SetActive(false);
            RestartGame(5f);
        }
        
        private void ShowText(string text)
        {
            _endGameText.text = text;
            _endGameText.enabled = true;
            _startGameManager.RestartGame();
        }

        private void EndGameTextClear()
        {
            _endGameText.text = "";
            _endGameText.enabled = false;
        }

        private void ShowPausedMenu()
        {
            _gameManager.PauseGame();
            _panel.SetActive(true);
            _openMenuButton.gameObject.SetActive(false);
        }
    }
}
