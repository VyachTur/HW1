using UnityEditor;
using UnityEngine;

namespace GameSystem
{
    public sealed class QuitGameManager : MonoBehaviour
    {
        public void Quit()
        {
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif
        }
    }
}
