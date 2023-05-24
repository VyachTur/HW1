using GameSystem.InterfaceListeners;
using TrackMarkers;
using UnityEngine;

namespace GameSystem
{
    public class GenerateObstacles : MonoBehaviour, ILoadGameListener
    {
        [SerializeField] private Transform _obstaclesContainer;
        [SerializeField] private TrackObject[] _tracks;
    
        private GameObject _obstacle;
        private const int Step = 10;
        private const int Quantity = 15;

        void ILoadGameListener.OnLoadGame()
        {
            _obstacle = Resources.Load<GameObject>("Prefabs/Obstacle");
            InstantiateObstacles();
        }


        private void InstantiateObstacles()
        {
            for (int i = 1; i < Quantity; i++)
            {
                float rndTrackPosX = _tracks[Random.Range(0, _tracks.Length)].transform.position.x;
                GameObject obstacle = Instantiate(_obstacle, new Vector3(rndTrackPosX, 0f, i * Step), Quaternion.identity, _obstaclesContainer);
            }
        }
    }
}
