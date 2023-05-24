using System;
using System.Linq;
using GameSystem.InterfaceListeners;
using StaticData;
using TrackMarkers;
using UnityEngine;
using Player;
using UnityEngine.Serialization;

namespace GameSystem
{
    public class HorizontalMoveController : MonoBehaviour, IStartGameListener, IEndGameListener
    {
        [SerializeField] private Hero _hero;
        [SerializeField] private Input _input;
        [SerializeField] private TrackObject[] _tracks;

        private TrackObject _currentTrack;

        private void Awake() =>
            _currentTrack = GetTrackFromType(TrackType.CenterObject);

        void IStartGameListener.OnStartGame()
        {
            _hero.SetPositionX(_currentTrack.GetTrackPositionX());
            _input.OnHorizontalInputEvent += OnSetPosition;
        }


        void IEndGameListener.OnEndGame() => 
            _input.OnHorizontalInputEvent -= OnSetPosition;

        private void OnSetPosition(int direction)
        {
            if (direction == Constants.LeftDirection)
                _currentTrack = TrackLeft();

            if (direction == Constants.RightDirection)
                _currentTrack = TrackRight();
            
            _hero.SetPositionX(_currentTrack.GetTrackPositionX());
        }

        private TrackObject TrackLeft() => _currentTrack.TrackType switch
        {
            TrackType.CenterObject => GetTrackFromType(TrackType.LeftObject),
            TrackType.LeftObject => GetTrackFromType(TrackType.LeftObject),
            TrackType.RightObject => GetTrackFromType(TrackType.CenterObject),
            _ => throw new ArgumentOutOfRangeException()
        };

        private TrackObject TrackRight() => _currentTrack.TrackType switch
        {
            TrackType.CenterObject => GetTrackFromType(TrackType.RightObject),
            TrackType.LeftObject => GetTrackFromType(TrackType.CenterObject),
            TrackType.RightObject => GetTrackFromType(TrackType.RightObject),
            _ => throw new ArgumentOutOfRangeException()
        };

        private TrackObject GetTrackFromType(TrackType type) => 
            _tracks.FirstOrDefault(track => track.TrackType == type);
    }
}