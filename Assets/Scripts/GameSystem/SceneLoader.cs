using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameSystem
{
    public class SceneLoader : MonoBehaviour
    {
        public void RestartCurrentScene() => 
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
