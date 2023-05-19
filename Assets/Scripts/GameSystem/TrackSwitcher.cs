using System;
using System.Linq;
using GameSystem.InterfaceListeners;
using StaticData;
using TrackMarkers;
using UnityEngine;

namespace GameSystem
{
    public class TrackSwitcher : MonoBehaviour, IStartGameListener, IEndGameListener, IPauseGameListener, IRestartGameListener
    {
        [SerializeField] private Player.Player _player;
        [SerializeField] private Input _input;
        [SerializeField] private TrackObject[] _tracks;

        private TrackObject _currentTrack;

        private void Awake()
        {
            _currentTrack = GetTrackFromType(TrackType.CenterMarker);
            enabled = false;
        }

        private void OnEnable() => 
            _input.OnHorizontalInputEvent += OnSetPosition;

        private void OnDisable() => 
            _input.OnHorizontalInputEvent -= OnSetPosition;

        private void OnSetPosition(int direction)
        {
            if (direction == Constants.LeftDirection)
                _currentTrack = TrackLeft();

            if (direction == Constants.RightDirection)
                _currentTrack = TrackRight();
            
            _player.SetPositionX(_currentTrack.GetTrackPositionX());
        }

        private TrackObject TrackLeft() => _currentTrack.TrackType switch
        {
            TrackType.CenterMarker => GetTrackFromType(TrackType.LeftMarker),
            TrackType.LeftMarker => GetTrackFromType(TrackType.LeftMarker),
            TrackType.RightMarker => GetTrackFromType(TrackType.CenterMarker),
            _ => throw new ArgumentOutOfRangeException()
        };

        private TrackObject TrackRight() => _currentTrack.TrackType switch
        {
            TrackType.CenterMarker => GetTrackFromType(TrackType.RightMarker),
            TrackType.LeftMarker => GetTrackFromType(TrackType.CenterMarker),
            TrackType.RightMarker => GetTrackFromType(TrackType.RightMarker),
            _ => throw new ArgumentOutOfRangeException()
        };

        private TrackObject GetTrackFromType(TrackType type) => 
            _tracks.FirstOrDefault(track => track.TrackType == type);

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