using GameSystem.InterfaceListeners;
using UnityEngine;

namespace GameSystem
{
    public sealed class LevelBackgroundMover : MonoBehaviour, IUpdateGameListener
    {
        [SerializeField] private Transform _mainBackgroundTransform;
        [SerializeField] private float _startPositionY;
        [SerializeField] private float _endPositionY;
        [SerializeField] private float _movingSpeedY;

        private Transform _currentBottomTransform;
        private float _positionX;
        private float _positionY;
        private float _positionZ;

        private void Awake()
        {
            var position = _mainBackgroundTransform.position;
            _positionX = position.x;
            _positionZ = position.z;
        }

        void IUpdateGameListener.OnUpdate(float deltaTime)
        {
            _positionY = _mainBackgroundTransform.position.y;

            MoveBackground(_positionY, _endPositionY, deltaTime);
        }

        private void MoveBackground(float start, float end, float deltaTime)
        {
            if (_positionY <= _endPositionY)
            {
                UpBackgroundPosition();
            }

            Move(deltaTime);
        }

        private void UpBackgroundPosition()
        {
            _mainBackgroundTransform.position = new Vector3(
                _positionX,
                _startPositionY,
                _positionZ
            );
        }

        private void Move(float deltaTime)
        {
            _mainBackgroundTransform.position -= new Vector3(
                _positionX,
                _movingSpeedY * deltaTime,
                _positionZ
            );
        }
    }
}