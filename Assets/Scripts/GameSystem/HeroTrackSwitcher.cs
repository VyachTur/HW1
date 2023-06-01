using GameSystem.InterfaceListeners;
using StaticData;
using UnityEngine;
using Player;
using Tracks;

namespace GameSystem
{
    public sealed class HeroTrackSwitcher : MonoBehaviour, IStartGameListener, IEndGameListener
    {
        [SerializeField] private Hero _hero;
        [SerializeField] private KeyboardInput _keyboardInput;
        [SerializeField] private TracksManager _tracksManager;

        private TrackObject _currentTrack;

        private void Awake() =>
            _currentTrack = _tracksManager.GetCenterTrack();

        void IStartGameListener.OnStartGame()
        {
            _hero.SetPositionX(_currentTrack.GetTrackPosition().x);
            _keyboardInput.OnHorizontalInputEvent += OnSetPosition;
        }

        void IEndGameListener.OnEndGame() => 
            _keyboardInput.OnHorizontalInputEvent -= OnSetPosition;

        private void OnSetPosition(int direction)
        {
            if (direction == Constants.LeftDirection)
                _currentTrack = _tracksManager.TrackLeft(_currentTrack);

            if (direction == Constants.RightDirection)
                _currentTrack = _tracksManager.TrackRight(_currentTrack);
            
            _hero.SetPositionX(_currentTrack.GetTrackPosition().x);
        }
    }
}