using System;
using GameSystem.InterfaceListeners;
using StaticData;
using UnityEngine;

namespace GameSystem
{
    public sealed class KeyboardInput : MonoBehaviour, IUpdateGameListener
    {
        public event Action<int> OnHorizontalInputEvent;

        void IUpdateGameListener.OnUpdate(float deltaTime) =>
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
    }
}