using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuAndMenuNavigation : MonoBehaviour
{
    public GameObject mainMenuCanvas;
    public GameObject settingsCanvas;
    public GameObject creditsCanvas;
    public GameObject controlsCanvas;

    public GameObject resetSettingsPopup;

    private AudioSource audioSource;
    public AudioClip buttonClickSound;


    public void Start()
    {
        mainMenuCanvas.SetActive(true);
        settingsCanvas.SetActive(false);
        controlsCanvas.SetActive(false);
        creditsCanvas.SetActive(false);
        resetSettingsPopup.SetActive(false);

        audioSource = GetComponent<AudioSource>();
    }

    void PlayButtonSound() {
        if (buttonClickSound != null && buttonClickSound != null) { audioSource.PlayOneShot(buttonClickSound); }
    }

    //main menu navigation
    public void playButton()
    {
        PlayButtonSound();
        SceneManager.LoadScene("gameplay");
    }
    public void settingsButton()
    {
        PlayButtonSound();
        mainMenuCanvas.SetActive(false);
        settingsCanvas.SetActive(true);
    }
    public void creditsButton()
    {
        PlayButtonSound();
        mainMenuCanvas.SetActive(false);
        creditsCanvas.SetActive(true);
    }
    public void controlsButton()
    {
        PlayButtonSound();
        mainMenuCanvas.SetActive(false);
        controlsCanvas.SetActive(true);
    }
    public void quitButton()
    {
        PlayButtonSound();
        Application.Quit();
    }

    //settings menu navigation (settings menu content is in a different script!)
    public void settingsBackButton()
    {
        PlayButtonSound();
        mainMenuCanvas.SetActive(true);
        settingsCanvas.SetActive(false);
    }

    //credits menu navigation
    public void creditsBackButton()
    {
        PlayButtonSound();
        mainMenuCanvas.SetActive(true);
        creditsCanvas.SetActive(false);
    }

    //controls menu navigation
    public void controlsBackButton()
    {
        PlayButtonSound();
        mainMenuCanvas.SetActive(true);
        controlsCanvas.SetActive(false);
    }
}
