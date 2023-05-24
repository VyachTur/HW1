using GameSystem.InterfaceListeners;
using UnityEngine;

namespace GameSystem
{
    [RequireComponent(typeof(GameManager))]
    public sealed class GameManagerInstaller : MonoBehaviour
    {
        private void Awake()
        {
            var gameSystem = GetComponent<GameManager>();
            var listeners = GetComponentsInChildren<IGameListener>();

            foreach (var listener in listeners)
            {
                gameSystem.AddListener(listener);
            }
        }
    }
}
