using System;
using System.Collections.Generic;
using GameSystem.InterfaceListeners;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GameSystem
{
    public sealed class GameManager : MonoBehaviour, IGameManager
    {
        [ShowInInspector, ReadOnly]
        public GameState State => _state;
        private GameState _state;
        
        private List<IGameListener> _listeners = new();

        private List<IUpdateGameListener> _updateListeners = new();
        private List<IFixedUpdateGameListener> _fixedUpdateListeners = new();
        private List<ILateUpdateGameListener> _lateUpdateListeners = new();
        
        private void Update()
        {
            if (_state != GameState.Playing)
                return;

            float deltaTime = Time.deltaTime;
            for (int i = 0, count = _updateListeners.Count; i < count; i++)
            {
                var listener = _updateListeners[i];
                listener.OnUpdate(deltaTime);
            }
        }
    
        private void FixedUpdate()
        {
            if (_state != GameState.Playing)
                return;
            
            float deltaTime = Time.fixedDeltaTime;
            for (int i = 0, count = _fixedUpdateListeners.Count; i < count; i++)
            {
                var listener = _fixedUpdateListeners[i];
                listener.OnFixedUpdate(deltaTime);
            }
        }

        private void LateUpdate()
        {
            if (_state != GameState.Playing)
                return;
            
            float deltaTime = Time.deltaTime;
            for (int i = 0, count = _lateUpdateListeners.Count; i < count; i++)
            {
                var listener = _lateUpdateListeners[i];
                listener.OnLateUpdate(deltaTime);
            }
        }

        public void AddListener(IGameListener listener)
        {
            if (listener is null) return;

            _listeners.Add(listener);

            if (listener is IUpdateGameListener updateListener)
                _updateListeners.Add(updateListener);
            
            if (listener is ILateUpdateGameListener lateUpdateListener)
                _lateUpdateListeners.Add(lateUpdateListener);
            
            if (listener is IFixedUpdateGameListener fixedUpdateListener)
                _fixedUpdateListeners.Add(fixedUpdateListener);
        }
        
        [Button]
        public void LoadGame()
        {
            if (_state != GameState.Off) return;
        
            foreach (var listener in _listeners)
            {
                if (listener is ILoadGameListener loadListener)
                {
                    loadListener.OnLoadGame();
                }
            }
        
            _state = GameState.Loading;
        }

        [Button]
        public void StartGame()
        {
            if (_state != GameState.Loading) return;

            foreach (var listener in _listeners)
            {
                if (listener is IStartGameListener startListener)
                {
                    startListener.OnStartGame();
                }
            }

            _state = GameState.Playing;
        }
        
        [Button]
        public void PauseGame()
        {
            if (_state != GameState.Playing) return;
            
            foreach (var listener in _listeners)
            {
                if (listener is IPauseGameListener pauseListener)
                {
                    pauseListener.OnPauseGame();
                }
            }

            _state = GameState.Paused;
        }
        
        [Button]
        public void ResumeGame()
        {
            if (_state != GameState.Paused) return;
            
            foreach (var listener in _listeners)
            {
                if (listener is IResumeGameListener restartListener)
                {
                    restartListener.OnResumeGame();
                }
            }

            _state = GameState.Playing;
        }
        
        [Button]
        public void EndGame()
        {
            if (_state != GameState.Playing && _state != GameState.Paused) return;
            
            foreach (var listener in _listeners)
            {
                if (listener is IEndGameListener endListener)
                {
                    endListener.OnEndGame();
                }
            }

            _state = GameState.Finished;
        }
    }
}
