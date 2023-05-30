using System;
using UnityEngine;
using GameSystem.InterfaceListeners;
using StaticData;

namespace PlayerInput
{
    public sealed class KeyboardInput : MonoBehaviour, IUpdateGameListener
    {
        public Action<int, float> OnHorizontalInputUpdatableEvent;
        // public float HorizontalDirection { get; private set; }

        // [SerializeField] private GameObject _character;

        // [SerializeField] private BulletController _bulletController;

        void IUpdateGameListener.OnUpdate(float deltaTime)
        {
            // if (Input.GetKeyDown(KeyCode.Space))
            // {
            //     _bulletController.FireRequired = true;
            // }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                // HorizontalDirection = -1;
                OnHorizontalInputUpdatableEvent?.Invoke(Constants.LeftDirection, deltaTime);
            } 
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                // HorizontalDirection = 1;
                OnHorizontalInputUpdatableEvent?.Invoke(Constants.RightDirection, deltaTime);
            }
            else
            {
                OnHorizontalInputUpdatableEvent?.Invoke(Constants.NoDirection, deltaTime);
            }
        }
    }
}