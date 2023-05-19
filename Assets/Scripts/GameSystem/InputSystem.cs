using System;
using StaticData;
using UnityEngine;

namespace GameSystem
{
    public class InputSystem : MonoBehaviour
    {
        public event Action<int> OnHorizontalInputEvent;

        private void Update() => 
            HandleHorizontalInput();

        private void HandleHorizontalInput()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                OnHorizontalInput(Constants.LeftDirection);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                OnHorizontalInput(Constants.RightDirection);
            }
        }

        private void OnHorizontalInput(int horizontalInput) => 
            OnHorizontalInputEvent?.Invoke(horizontalInput);
    }
}