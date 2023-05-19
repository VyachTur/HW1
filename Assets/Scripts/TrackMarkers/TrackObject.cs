using UnityEngine;

namespace TrackMarkers
{
    public class TrackObject : MonoBehaviour
    {
        [field: SerializeField]
        public TrackType TrackType { get; private set; }

        public float GetTrackPositionX() =>
            transform.position.x;
    }
}
