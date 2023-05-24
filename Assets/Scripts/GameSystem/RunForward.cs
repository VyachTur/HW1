using System;
using GameSystem.InterfaceListeners;
using Player;
using UnityEngine;

namespace GameSystem
{
    public class RunForward : MonoBehaviour, IStartGameListener, IEndGameListener, IPauseGameListener, IResumeGameListener
    {
        [SerializeField] private Hero _hero;
        [SerializeField] private float _speed = 10f;

        private Rigidbody _heroRB;

        private void Awake()
        {
            if (!_hero.TryGetComponent<Rigidbody>(out _heroRB))
                throw new Exception("Rigidbody is not found!");
            enabled = false;
        }

        private void MoveForward() => 
            _heroRB.velocity = Vector3.forward * _speed;

        private void Stop() =>
            _heroRB.velocity = Vector3.zero;

        void IStartGameListener.OnStartGame() =>
            MoveForward();

        void IEndGameListener.OnEndGame() => 
            Stop();

        void IPauseGameListener.OnPauseGame() => 
            Stop();

        void IResumeGameListener.OnResumeGame() => 
            MoveForward();
    }
}
