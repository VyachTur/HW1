using System;
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
                OnHorizontalInput(-1);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                OnHorizontalInput(1);
            }
        }

        private void OnHorizontalInput(int horizontalInput) => 
            OnHorizontalInputEvent?.Invoke(horizontalInput);
    }
}