using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Scene01");
    }

    public void ContinueGame()
    {
        Debug.Log("Continue Game clicked");
    }

    public void OpenOption()
    {
        Debug.Log("Options clicked");
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
