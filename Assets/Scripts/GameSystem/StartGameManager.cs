using System;
using System.Collections;
using UnityEngine;

namespace GameSystem
{
    public class StartGameManager : MonoBehaviour
    {
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private SceneLoader _sceneLoader;
        public event Action<int> OnTimerTickEvent;
    
        public void StartGame() => 
            StartCoroutine(TimerTick());

        public void RestartGame(float secondDelay = 0f)
        {
            Delay(secondDelay);
            _sceneLoader.RestartCurrentScene();
        }

        private IEnumerator TimerTick()
        {
            for (int i = 3; i > 0; i--)
            {
                OnTimerTickEvent?.Invoke(i);
                yield return new WaitForSeconds(1f);
            }
        
            _gameManager.StartGame();
        }

        private IEnumerator Delay(float second)
        {
            yield return new WaitForSeconds(second);
        }
    }
}
