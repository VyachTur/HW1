using GameManagers.Player;
using UnityEngine;

namespace GameManagers.GameSystem
{
    public class MoveController : MonoBehaviour
    {
        [SerializeField] private PlayerObject _player;
        [SerializeField] private InputSystem _input;

        [SerializeField] private float _step = 2f;

        private void OnEnable() => 
            _input.OnHorizontalInputEvent += OnMove;

        private void OnDisable() => 
            _input.OnHorizontalInputEvent -= OnMove;

        private void OnMove(float horizontal) => 
            _player.Move(horizontal * _step);
    }
}