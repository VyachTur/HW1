using GameSystem.InterfaceListeners;
using Player;
using UnityEngine;

namespace GameSystem
{
    public sealed class HeroForwardMover : MonoBehaviour, 
        IStartGameListener, 
        IEndGameListener, 
        IPauseGameListener, 
        IResumeGameListener
    {
        [SerializeField] private Hero _hero;
        [SerializeField] private float _speed = 10f;

        private void MoveForward() => _hero.SetVelocity(Vector3.forward * _speed);

        private void Stop() => _hero.SetVelocity(Vector3.zero);

        void IStartGameListener.OnStartGame() => MoveForward();

        void IEndGameListener.OnEndGame() => Stop();

        void IPauseGameListener.OnPauseGame() => Stop();

        void IResumeGameListener.OnResumeGame() => MoveForward();
    }
}
