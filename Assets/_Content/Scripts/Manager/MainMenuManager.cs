using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tinker
{
    public class MainMenuManager : MonoBehaviour
    {
        public void StartGame()
        {
            SceneManager.LoadScene("Bedroom");
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}
