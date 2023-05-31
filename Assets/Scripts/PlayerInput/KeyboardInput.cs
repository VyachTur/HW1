using System;
using UnityEngine;
using GameSystem.InterfaceListeners;
using StaticData;

namespace PlayerInput
{
    public sealed class KeyboardInput : MonoBehaviour, IUpdateGameListener
    {
        public event Action<int, float> OnHorizontalInputUpdatableEvent;
        public event Action OnFireEvent;

        void IUpdateGameListener.OnUpdate(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnFireEvent?.Invoke();
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                OnHorizontalInputUpdatableEvent?.Invoke(Constants.LeftDirection, deltaTime);
            } 
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                OnHorizontalInputUpdatableEvent?.Invoke(Constants.RightDirection, deltaTime);
            }
            else
            {
                OnHorizontalInputUpdatableEvent?.Invoke(Constants.NoDirection, deltaTime);
            }
        }
    }
}