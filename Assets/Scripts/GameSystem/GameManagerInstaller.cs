using GameSystem.InterfaceListeners;
using UnityEngine;

namespace GameSystem
{
    [RequireComponent(typeof(GameManager))]
    public class GameManagerInstaller : MonoBehaviour
    {
        private void Awake()
        {
            var gameManager = GetComponent<GameManager>();
            var listeners = GetComponentsInChildren<IGameListener>();

            foreach (var listener in listeners)
            {
                gameManager.AddListener(listener);
            }
        }
    }
}