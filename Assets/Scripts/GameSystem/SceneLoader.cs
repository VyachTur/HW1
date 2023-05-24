using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void RestartCurrentScene() => 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}
