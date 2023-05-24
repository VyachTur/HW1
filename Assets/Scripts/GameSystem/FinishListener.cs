using System;
using GameSystem.InterfaceListeners;
using Player;
using StaticData;
using UnityEngine;

namespace GameSystem
{
    // Есть нарушение принципа DRY, но это сделано сознательно, т.к. в будущем,
    // вполне вероятно, что логика классов CrashListener и FinishListener поменяется
    // и отличий станет много
    public class FinishListener : MonoBehaviour, IStartGameListener, IEndGameListener
    {
        [SerializeField] private IGameManager _gameManager;
        [SerializeField] private Hero _hero;
        
        public event Action<string> OnFinishEvent;
        
        void IStartGameListener.OnStartGame() => 
            _hero.OnCollisionEvent += OnFinish;
        
        void IEndGameListener.OnEndGame() => 
            _hero.OnCollisionEvent -= OnFinish;
        
        private void OnFinish(string marker)
        {
            if (marker == Constants.FinishTag)
            {
                OnFinishEvent?.Invoke("Выигрыш!");
                _gameManager.EndGame();
            }
        }
    }
}
