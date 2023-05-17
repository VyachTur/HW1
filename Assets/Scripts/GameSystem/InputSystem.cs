using System;
using UnityEngine;

namespace GameSystem
{
    public class InputSystem : MonoBehaviour
    {
        public event Action<float> OnHorizontalInputEvent;

        private void Update() => 
            HandleHorizontalInput();

        private void HandleHorizontalInput()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                OnHorizontalInput(-1f);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                OnHorizontalInput(1f);
            }
        }

        private void OnHorizontalInput(float horizontalInput) => 
            OnHorizontalInputEvent?.Invoke(horizontalInput);
    }
}