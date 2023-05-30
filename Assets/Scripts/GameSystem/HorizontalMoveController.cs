using Character;
using GameSystem.InterfaceListeners;
using Level;
using PlayerInput;
using UnityEngine;

namespace GameSystem
{
    public sealed class HorizontalMoveController : MonoBehaviour, IStartGameListener, IEndGameListener
    {
        [SerializeField] private CharacterObject _character;
        [SerializeField] private KeyboardInput _input;
        [SerializeField] private LevelBounds _bounds;
        [SerializeField] private float _speed = 5f;
        
        private Transform _characterTransform;

        void IStartGameListener.OnStartGame()
        {
            _characterTransform = _character.GetTransform;
            _input.OnHorizontalInputUpdatableEvent += HorizontalMove;
        }

        private void HorizontalMove(int direction, float deltaTime)
        {
            float translateX = direction * _speed * deltaTime;
            _characterTransform.Translate(translateX, 0f, 0f);

            float positionX = Mathf.Clamp(_character.GetPosition.x, _bounds.LeftBoundX, _bounds.RightBoundX);
            _character.SetPositionX(positionX);
        }

        void IEndGameListener.OnEndGame()
        {
            _input.OnHorizontalInputUpdatableEvent -= HorizontalMove;
        }
    }
}