using GameSystem.InterfaceListeners;
using Player;
using UnityEngine;

namespace GameSystem
{
    public class CameraFollower : MonoBehaviour, IStartGameListener, IEndGameListener, IPauseGameListener, IRestartGameListener
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private Player.Player _player;
        [SerializeField] private Vector3 _offset;
        [SerializeField] private float _followSpeed = 1f;

        private void FixedUpdate()
        {
            Vector3 newPosition = _player.GetPosition() + _offset;
            _camera.transform.position = Vector3.Lerp(_camera.transform.position, 
                                                        newPosition, 
                                                        _followSpeed * Time.deltaTime);
        }

        void IStartGameListener.OnStartGame() => 
            enabled = true;

        void IEndGameListener.OnEndGame() => 
            enabled = false;

        void IPauseGameListener.OnPauseGame() => 
            enabled = false;

        void IRestartGameListener.OnRestartGame() => 
            enabled = true;
    }
}