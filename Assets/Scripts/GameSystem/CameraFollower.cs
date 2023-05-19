using Player;
using UnityEngine;

namespace GameSystem
{
    public class CameraFollower : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private PlayerObject _player;
        [SerializeField] private Vector3 _offset;
        [SerializeField] private float _followSpeed = 1f;

        private void FixedUpdate()
        {
            Vector3 newPosition = _player.GetPosition() + _offset;
            _camera.transform.position = Vector3.Lerp(_camera.transform.position, 
                                                        newPosition, 
                                                        _followSpeed * Time.deltaTime);
        }
            
    }
}