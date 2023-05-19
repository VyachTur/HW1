using System.Collections.Generic;
using GameManagers.GameSystem.InterfaceListeners;
using UnityEngine;

namespace GameSystem
{
    public class GameSystem : MonoBehaviour
    {
        private List<IGameListener> _listeners = new();

        public void AddListener(IGameListener listener) =>
            _listeners.Add(listener);
        
        
    }
}
