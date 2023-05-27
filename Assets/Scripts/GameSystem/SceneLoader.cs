using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameSystem
{
    public sealed class SceneLoader : MonoBehaviour
    {
        public void RestartSceneFromSeconds(float second = 0f) =>
            Invoke(nameof(RestartCurrentScene), second);
        
        private void RestartCurrentScene() => 
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
