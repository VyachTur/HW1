using UnityEngine;

namespace Tracks
{
    public sealed class TrackObject : MonoBehaviour
    {
        [field: SerializeField]
        public TrackType TrackType { get; private set; }

        public Vector3 GetTrackPosition() =>
            transform.position;
    }
}
