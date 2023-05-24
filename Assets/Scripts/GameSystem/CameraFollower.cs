using GameSystem.InterfaceListeners;
using Player;
using UnityEngine;

namespace GameSystem
{
    public class CameraFollower : MonoBehaviour, IFixedUpdateGameListener
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private Hero _hero;
        [SerializeField] private Vector3 _offset;
        [SerializeField] private float _followSpeed = 1f;

        public void OnFixedUpdate(float deltaTime)
        {
            Vector3 newPosition = _hero.GetPosition() + _offset;
            _camera.transform.position = Vector3.Lerp(_camera.transform.position, 
                newPosition, 
                _followSpeed * Time.deltaTime);
        }
    }
}