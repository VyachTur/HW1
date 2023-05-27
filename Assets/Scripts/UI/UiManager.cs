using GameSystem;
using GameSystem.InterfaceListeners;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public sealed class UiManager : MonoBehaviour, ILoadGameListener, IStartGameListener, IEndGameListener
    {
        [Header("Systems")] 
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private HeroObstacleObserver _heroObstacleObserver;
        [SerializeField] private HeroFinishedObserver _heroFinishedObserver;
        [SerializeField] private GameLauncher _gameLauncher;
        [SerializeField] private SceneLoader _sceneLoader;
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
            _gameLauncher.OnTimerTickEvent += ShowTimer;
            
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
            
            _heroObstacleObserver.OnCrashEvent += GameEnd;
            _heroFinishedObserver.OnFinishEvent += GameEnd;
            
            _openMenuButton.onClick.AddListener(ShowPausedMenu);
            
            _continueButton.onClick.AddListener(ResumeGame);
            _restartButton.onClick.AddListener(() => RestartGame(0f));
            _quitButton.onClick.AddListener(QuitGame);
        }

        void IEndGameListener.OnEndGame()
        {
            _heroObstacleObserver.OnCrashEvent -= GameEnd;
            _heroFinishedObserver.OnFinishEvent -= GameEnd;
            
            _openMenuButton.onClick.RemoveListener(ShowPausedMenu);
            _startGameButton.onClick.RemoveListener(StartGame);
            
            _continueButton.onClick.RemoveListener(ResumeGame);
            _restartButton.onClick.RemoveListener(() => RestartGame(0f));
            _quitButton.onClick.RemoveListener(QuitGame);
            
            _gameLauncher.OnTimerTickEvent -= ShowTimer;
        }
        
        private void StartGame()
        {
            _gameLauncher.LaunchGame();
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
            _sceneLoader.RestartSceneFromSeconds(delaySecond);

        private void QuitGame() =>
            _quitGameManager.Quit();

        private void GameEnd(string text)
        {
            ShowText(text);
            _openMenuButton.gameObject.SetActive(false);
            
            RestartGame(2f);
        }
        
        private void ShowText(string text)
        {
            _endGameText.text = text;
            _endGameText.enabled = true;
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
