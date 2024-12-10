using JetBrains.Annotations;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public GameObject pauseMenuCanvas;
    public GameObject settingsMenuCanvas;

    public GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() //hide menus when game launches and enable the player look script
    {
        resumeButton();//resume game

        pauseMenuCanvas.SetActive(false);
        settingsMenuCanvas.SetActive(false);
        player.GetComponent<playerLook>().enabled = true;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape)) //if esc key pressed then pause game
        {
            player.GetComponent<playerLook>().enabled = false;//disable player look controls
            Cursor.lockState = CursorLockMode.None;//let the player move the cursor
            pauseMenuCanvas.SetActive(true); //show pause menu
            Cursor.visible = true; //show cursor
            Time.timeScale = 0f; //pause time
        }
    }

    //pause menu buttons
    public void resumeButton()
    {
        Time.timeScale = 1f; //unpause time
        pauseMenuCanvas.SetActive(false);//hide pause menu
        Cursor.visible = false; //hides cursor
        player.GetComponent<playerLook>().enabled = true;//re-enable player look controls
        Cursor.lockState = CursorLockMode.Locked; //re-Locks cursor to middle of the screen

    }
    public void settingsButton() //hide the pause menu and show the settings menu
    {
        pauseMenuCanvas.SetActive(false);
        settingsMenuCanvas.SetActive(true);
    }
    public void exitToMenuButton()
    {
        SceneManager.LoadScene("mainMenu");
    }
    public void quitButton()
    {
        Application.Quit();
    }


    //settings menu buttons
    public void settingsBackButton() //hide the settings menu and show the pause menu
    {
        pauseMenuCanvas.SetActive(true);
        settingsMenuCanvas.SetActive(false);
    }
}
