using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{

    public void playButton()
    {
        SceneManager.LoadScene("gameplay");
    }
    public void settingsButton()
    {
        SceneManager.LoadScene("settingsMenu");
    }
    public void quitButton()
    {
        Application.Quit();
    }
}
