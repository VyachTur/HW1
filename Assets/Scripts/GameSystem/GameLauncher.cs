using UnityEngine;

namespace GameSystem
{
    public class GameLauncher : MonoBehaviour
    {
        [SerializeField] private GameManager _gameManager;

        private void Start()
        {
            _gameManager.StartGame();
        }
    }
}