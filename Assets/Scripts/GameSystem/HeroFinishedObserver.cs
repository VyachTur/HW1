using System;
using GameSystem.InterfaceListeners;
using Player;
using StaticData;
using UnityEngine;

namespace GameSystem
{
    public sealed class HeroFinishedObserver : MonoBehaviour, IStartGameListener, IEndGameListener
    {
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private Hero _hero;
        
        public event Action<string> OnFinishEvent;
        
        void IStartGameListener.OnStartGame() => 
            _hero.OnCollisionEvent += OnFinish;
        
        void IEndGameListener.OnEndGame() => 
            _hero.OnCollisionEvent -= OnFinish;
        
        private void OnFinish(Collision collision)
        {
            if (collision.gameObject.CompareTag(Constants.FinishTag))
            {
                OnFinishEvent?.Invoke("Выигрыш!");
                _gameManager.EndGame();
            }
        }
    }
}
