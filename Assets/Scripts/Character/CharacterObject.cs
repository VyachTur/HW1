using System;
using UnityEngine;

namespace Character
{
    public class CharacterObject : MonoBehaviour
    {
        public event Action<Collision> OnCollisionEvent;

        public Transform GetTransform => transform;

        public Vector3 GetPosition => transform.position;

        public void SetPositionX(float xPosition)
        {
            Vector3 position = transform.position;
            
            transform.position = new Vector3(xPosition,
                position.y,
                position.z);
        }

        private void OnCollisionEnter(Collision other) => 
            OnCollisionEvent?.Invoke(other);
    }
}