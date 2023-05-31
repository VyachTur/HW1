using GameSystem.InterfaceListeners;
using Tracks;
using UnityEngine;

namespace GameSystem
{
    public sealed class ObstaclesGenerator : MonoBehaviour, ILoadGameListener
    {
        [SerializeField] private Transform _obstaclesContainer;
        [SerializeField] private TracksManager _tracksManager;
        
        private GameObject _obstacle;
        private TrackObject[] _tracks;
        private const int Step = 10;
        private const int Quantity = 15;

        void ILoadGameListener.OnLoadGame()
        {
            _tracks = _tracksManager.Tracks;
            _obstacle = Resources.Load<GameObject>("Prefabs/Obstacle");
            InstantiateObstacles();
        }

        private void InstantiateObstacles()
        {
            for (int i = 1; i < Quantity; i++)
            {
                int randomIndex = Random.Range(0, _tracks.Length);
                TrackObject randomTrack = _tracks[randomIndex];
                float randomPositionX = randomTrack.GetTrackPosition().x;

                Vector3 trackPosition = new Vector3(randomPositionX, 0f, i * Step);
                Quaternion trackRotation = Quaternion.identity;
                
                Instantiate(_obstacle, trackPosition, trackRotation, _obstaclesContainer);
            }
        }
    }
}
