using System;
using System.Linq;
using UnityEngine;

namespace Tracks
{
    public sealed class TracksManager : MonoBehaviour
    {
        [field: SerializeField]
        public TrackObject[] Tracks { get; private set; }
        
        public TrackObject TrackLeft(TrackObject currentTrack) => currentTrack.TrackType switch
        {
            TrackType.CenterObject => GetTrackFromType(TrackType.LeftObject),
            TrackType.LeftObject => GetTrackFromType(TrackType.LeftObject),
            TrackType.RightObject => GetTrackFromType(TrackType.CenterObject),
            _ => throw new ArgumentOutOfRangeException()
        };

        public TrackObject TrackRight(TrackObject currentTrack) => currentTrack.TrackType switch
        {
            TrackType.CenterObject => GetTrackFromType(TrackType.RightObject),
            TrackType.LeftObject => GetTrackFromType(TrackType.CenterObject),
            TrackType.RightObject => GetTrackFromType(TrackType.RightObject),
            _ => throw new ArgumentOutOfRangeException()
        };

        public TrackObject GetCenterTrack() =>
            GetTrackFromType(TrackType.CenterObject);

        private TrackObject GetTrackFromType(TrackType type) => 
            Tracks.FirstOrDefault(track => track.TrackType == type);
    }
}