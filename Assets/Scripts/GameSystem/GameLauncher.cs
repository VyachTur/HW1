using System;
using System.Collections;
using UnityEngine;

namespace GameSystem
{
    public sealed class GameLauncher : MonoBehaviour
    {
        [SerializeField] private GameManager _gameManager;
        public event Action<int> OnTimerTickEvent;
    
        public void LaunchGame() => 
            StartCoroutine(TimerTick());

        private IEnumerator TimerTick()
        {
            for (int i = 3; i > 0; i--)
            {
                OnTimerTickEvent?.Invoke(i);
                yield return new WaitForSeconds(1f);
            }
        
            _gameManager.StartGame();
        }
    }
}
