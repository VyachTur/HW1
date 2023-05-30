using GameSystem;
using GameSystem.InterfaceListeners;
using UnityEngine;

namespace Enemy.Agents
{
    public sealed class EnemyMoveAgent : MonoBehaviour, IFixedUpdateGameListener
    {
        public bool IsReached
        {
            get { return _isReached; }
        }

        [SerializeField] private HorizontalMoveController _horizontalMoveController;

        private Vector2 _destination;

        private bool _isReached;

        void IFixedUpdateGameListener.OnFixedUpdate(float deltaTime)
        {
            if (_isReached)
            {
                return;
            }
            
            var vector = _destination - (Vector2) transform.position;
            if (vector.magnitude <= 0.25f)
            {
                _isReached = true;
                return;
            }

            var direction = vector.normalized * Time.fixedDeltaTime;
            // _horizontalMoveController.MoveByRigidbodyVelocity(direction);
        }

        public void SetDestination(Vector2 endPoint)
        {
            _destination = endPoint;
            _isReached = false;
        }
    }
}