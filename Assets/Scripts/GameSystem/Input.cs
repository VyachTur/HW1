using System;
using GameSystem.InterfaceListeners;
using StaticData;
using UnityEngine;

namespace GameSystem
{
    public class Input : MonoBehaviour, IStartGameListener, IEndGameListener, IRestartGameListener, IPauseGameListener
    {
        public event Action<int> OnHorizontalInputEvent;

        private void Awake() => 
            enabled = false;

        private void Update() => 
            HandleHorizontalInput();

        private void HandleHorizontalInput()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.LeftArrow))
            {
                OnHorizontalInput(Constants.LeftDirection);
            }

            if (UnityEngine.Input.GetKeyDown(KeyCode.RightArrow))
            {
                OnHorizontalInput(Constants.RightDirection);
            }
        }

        private void OnHorizontalInput(int horizontalInput) => 
            OnHorizontalInputEvent?.Invoke(horizontalInput);

        void IStartGameListener.OnStartGame() => 
            enabled = true;

        void IEndGameListener.OnEndGame() => 
            enabled = true;

        void IRestartGameListener.OnRestartGame() => 
            enabled = true;

        void IPauseGameListener.OnPauseGame() => 
            enabled = true;
    }
}