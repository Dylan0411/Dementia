using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuAndMenuNavigation : MonoBehaviour
{
    public GameObject mainMenuCanvas;
    public GameObject settingsCanvas;
    public GameObject creditsCanvas;
    public GameObject controlsCanvas;

    public GameObject resetSettingsPopup;

    public void Start()
    {
        mainMenuCanvas.SetActive(true);
        settingsCanvas.SetActive(false);
        controlsCanvas.SetActive(false);
        creditsCanvas.SetActive(false);
        resetSettingsPopup.SetActive(false);
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
    public void creditsButton()
    {
        mainMenuCanvas.SetActive(false);
        creditsCanvas.SetActive(true);
    }
    public void controlsButton()
    {
        mainMenuCanvas.SetActive(false);
        controlsCanvas.SetActive(true);
    }
    public void quitButton()
    {
        Application.Quit();
    }

    //settings menu navigation (settings menu content is in a different script!)
    public void settingsBackButton()
    {
        mainMenuCanvas.SetActive(true);
        settingsCanvas.SetActive(false);
    }

    //credits menu navigation
    public void creditsBackButton()
    {
        mainMenuCanvas.SetActive(true);
        creditsCanvas.SetActive(false);
    }

    //controls menu navigation
    public void controlsBackButton()
    {
        mainMenuCanvas.SetActive(true);
        controlsCanvas.SetActive(false);
    }
}
