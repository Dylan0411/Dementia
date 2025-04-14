using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuAndMenuNavigation : MonoBehaviour
{
    public GameObject mainMenuCanvas;
    public GameObject settingsCanvas;

    public void Start()
    {
        mainMenuCanvas.SetActive(true);
        settingsCanvas.SetActive(false);
    }

    //main menu navigation
    public void playButton()
    {
        SceneManager.LoadScene("gameplay");
    }
    public void settingsButton()
    {
        mainMenuCanvas.SetActive(false);
        settingsCanvas.SetActive(true);
    }
    public void quitButton()
    {
        Application.Quit();
    }

    //settings menu navigation
    public void settingsBackButton()
    {
        mainMenuCanvas.SetActive(true);
        settingsCanvas.SetActive(false);
    }
}
