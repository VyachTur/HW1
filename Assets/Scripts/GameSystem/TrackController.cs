using System;
using System.Linq;
using Player;
using TrackMarkers;
using UnityEngine;

namespace GameSystem
{
    public class TrackController : MonoBehaviour
    {
        [SerializeField] private PlayerObject _player;
        [SerializeField] private InputSystem _input;
        [SerializeField] private TrackObject[] _tracks;

        private TrackObject _currentTrack;

        private void Awake()
        {
            _currentTrack = GetTrackFromType(TrackType.CenterMarker);
        }

        private void OnEnable() => 
            _input.OnHorizontalInputEvent += OnSetPosition;

        private void OnDisable() => 
            _input.OnHorizontalInputEvent -= OnSetPosition;

        private void OnSetPosition(int direction)
        {
            if (direction == -1)
                _currentTrack = TrackLeft();

            if (direction == 1)
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
    }
}