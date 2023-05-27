using System;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    public sealed class Hero : MonoBehaviour
    {
        public event Action<Collision> OnCollisionEvent;
        
        private Rigidbody _heroRigidbody;

        private void Awake() => 
            _heroRigidbody = GetComponent<Rigidbody>();

        public Vector3 GetPosition() => transform.position;

        public void SetPositionX(float xPosition)
        {
            Vector3 position = transform.position;
            
            transform.position = new Vector3(xPosition,
                                    position.y,
                                    position.z);
        }

        public void SetVelocity(Vector3 velocity) => 
            _heroRigidbody.velocity = velocity;

        private void OnCollisionEnter(Collision other) => 
            OnCollisionEvent?.Invoke(other);
    }
}