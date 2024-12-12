using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndPanel : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
