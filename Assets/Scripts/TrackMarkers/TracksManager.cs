using System;
using System.Linq;
using UnityEngine;

namespace TrackMarkers
{
    public sealed class TracksManager : MonoBehaviour
    {
        public TrackObject[] Tracks { get; private set; }
        
        private TrackObject TrackLeft(TrackObject currentTrack) => currentTrack.TrackType switch
        {
            TrackType.CenterObject => GetTrackFromType(TrackType.LeftObject),
            TrackType.LeftObject => GetTrackFromType(TrackType.LeftObject),
            TrackType.RightObject => GetTrackFromType(TrackType.CenterObject),
            _ => throw new ArgumentOutOfRangeException()
        };

        private TrackObject TrackRight(TrackObject currentTrack) => currentTrack.TrackType switch
        {
            TrackType.CenterObject => GetTrackFromType(TrackType.RightObject),
            TrackType.LeftObject => GetTrackFromType(TrackType.CenterObject),
            TrackType.RightObject => GetTrackFromType(TrackType.RightObject),
            _ => throw new ArgumentOutOfRangeException()
        };

        private TrackObject GetTrackFromType(TrackType type) => 
            Tracks.FirstOrDefault(track => track.TrackType == type);
    }
}