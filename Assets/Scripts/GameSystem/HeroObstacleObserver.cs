using System;
using GameSystem.InterfaceListeners;
using Player;
using StaticData;
using UnityEngine;

namespace GameSystem
{
    public sealed class HeroObstacleObserver : MonoBehaviour, IStartGameListener, IEndGameListener
    {
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private Hero _hero;

        public event Action<string> OnCrashEvent;

        void IStartGameListener.OnStartGame() => 
            _hero.OnCollisionEvent += OnCrash;

        void IEndGameListener.OnEndGame() => 
            _hero.OnCollisionEvent -= OnCrash;

        private void OnCrash(Collision collision)
        {
            if (collision.gameObject.CompareTag(Constants.ObstacleTag))
            {
                OnCrashEvent?.Invoke("Проигрыш!");
                _gameManager.EndGame();
            }
        }
    }
}
