using Bullets;
using Components;
using GameSystem;
using GameSystem.InterfaceListeners;
using UnityEngine;

namespace Character
{
    public sealed class BulletController : MonoBehaviour, IFixedUpdateGameListener
    {
        [SerializeField] private GameObject _character; 
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private BulletSystem _bulletSystem;
        [SerializeField] private BulletConfig _bulletConfig;
        
        public bool FireRequired;

        private void OnEnable()
        {
            _character.GetComponent<HitPointsComponent>().HpEmpty += OnCharacterDeath;
        }

        private void OnDisable()
        {
            _character.GetComponent<HitPointsComponent>().HpEmpty -= OnCharacterDeath;
        }

        private void OnCharacterDeath(GameObject _) => _gameManager.FinishGame();

        void IFixedUpdateGameListener.OnFixedUpdate(float deltaTime)
        {
            if (FireRequired)
            {
                OnFlyBullet();
                FireRequired = false;
            }
        }

        private void OnFlyBullet()
        {
            var weapon = _character.GetComponent<WeaponComponent>();
            _bulletSystem.FlyBulletByArgs(new BulletSystem.Args
            {
                IsPlayer = true,
                PhysicsLayer = (int) _bulletConfig.PhysicsLayer,
                Color = _bulletConfig.Color,
                Damage = _bulletConfig.Damage,
                Position = weapon.Position,
                Velocity = weapon.Rotation * Vector3.up * _bulletConfig.Speed
            });
        }

        
    }
}