using TrackMarkers;
using UnityEngine;

public class GenerateObstacles : MonoBehaviour
{
    [SerializeField] private TrackObject[] _tracks;
    
    private GameObject _obstacle;
    private const int Step = 10;
    private const int Quantity = 15;

    private void Awake() => 
        _obstacle = Resources.Load<GameObject>("Prefabs/Obstacle");

    private void Start() => 
        InstantiateObstacles();

    private void InstantiateObstacles()
    {
        for (int i = 1; i < Quantity; i++)
        {
            float rndTrackPosX = _tracks[Random.Range(0, _tracks.Length)].transform.position.x;
            Instantiate(_obstacle, new Vector3(rndTrackPosX, 0f, i * Step), Quaternion.identity);
        }
    }
}
