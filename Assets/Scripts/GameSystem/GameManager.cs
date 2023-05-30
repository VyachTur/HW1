using System.Collections.Generic;
using GameSystem.InterfaceListeners;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GameSystem
{
    public sealed class GameManager : MonoBehaviour
    {
        [ShowInInspector, ReadOnly]
        public GameState State => _state;
        private GameState _state;

        private List<IStartGameListener> _startGameListeners = new();
        private List<IEndGameListener> _endGameListeners = new();
        
        private List<IUpdateGameListener> _updateListeners = new();
        private List<ILateUpdateGameListener> _lateUpdateListeners = new();
        private List<IFixedUpdateGameListener> _fixedUpdateListeners = new();

        private void Update()
        {
            if (_state != GameState.Playing) return;

            float deltaTime = Time.deltaTime;
            for (int i = 0; i < _updateListeners.Count; i++)
            {
                var listener = _updateListeners[i];
                listener.OnUpdate(deltaTime);
            }
        }
        
        private void LateUpdate()
        {
            if (_state != GameState.Playing) return;

            float deltaTime = Time.deltaTime;
            for (int i = 0; i < _lateUpdateListeners.Count; i++)
            {
                var listener = _lateUpdateListeners[i];
                listener.OnLateUpdate(deltaTime);
            }
        }
        
        private void FixedUpdate()
        {
            if (_state != GameState.Playing) return;

            float deltaTime = Time.deltaTime;
            for (int i = 0; i < _fixedUpdateListeners.Count; i++)
            {
                var listener = _fixedUpdateListeners[i];
                listener.OnFixedUpdate(deltaTime);
            }
        }

        public void AddListener(IGameListener listener)
        {
            if (listener is null) return;
            
            if (listener is IStartGameListener startListener)
                _startGameListeners.Add(startListener);
            
            if (listener is IEndGameListener endListener)
                _endGameListeners.Add(endListener);
            
            if (listener is IUpdateGameListener updateListener)
                _updateListeners.Add(updateListener);
            
            if (listener is ILateUpdateGameListener lateUpdateListener)
                _lateUpdateListeners.Add(lateUpdateListener);
            
            if (listener is IFixedUpdateGameListener fixedUpdateListener)
                _fixedUpdateListeners.Add(fixedUpdateListener);
        }

        public void StartGame()
        {
            if (_state == GameState.Playing) return;
            
            for (int i = 0; i < _startGameListeners.Count; i++)
            {
                var listener = _startGameListeners[i];
                listener.OnStartGame();
            }

            _state = GameState.Playing;
        }
        
        public void EndGame()
        {
            if (_state != GameState.Playing) return;
            
            for (int i = 0; i < _endGameListeners.Count; i++)
            {
                var listener = _endGameListeners[i];
                listener.OnEndGame();
            }

            _state = GameState.Off;
        }


        
        
        public void FinishGame()
        {
            Debug.Log("Game over!");
            Time.timeScale = 0;
        }
    }
}