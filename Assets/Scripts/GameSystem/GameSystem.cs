using System.Collections.Generic;
using GameSystem.InterfaceListeners;
using UnityEngine;

namespace GameSystem
{
    public sealed class GameSystem : MonoBehaviour
    {
        public GameState State => _state;
        private GameState _state;
        
        private List<IGameListener> _listeners = new();

        public void AddListener(IGameListener listener)
        {
            if (listener is null) return;

            _listeners.Add(listener);
        }

        public void StartGame()
        {
            if (_state == GameState.Playing) return;

            foreach (var listener in _listeners)
            {
                if (listener is IStartGameListener startListener)
                {
                    startListener.OnStartGame();
                }
            }

            _state = GameState.Playing;
        }
        
        public void EndGame()
        {
            if (_state != GameState.Playing) return;
            
            foreach (var listener in _listeners)
            {
                if (listener is IEndGameListener endListener)
                {
                    endListener.OnEndGame();
                }
            }

            _state = GameState.Finished;
        }
        
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
        
        public void RestartGame()
        {
            if (_state == GameState.Off) return;
            
            foreach (var listener in _listeners)
            {
                if (listener is IRestartGameListener restartListener)
                {
                    restartListener.OnRestartGame();
                }
            }

            _state = GameState.Playing;
        }
        
        
        
    }
}
