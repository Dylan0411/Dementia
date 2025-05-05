using UnityEngine;
using UnityEngine.Android;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public GameObject pauseMenuCanvas;
    public GameObject settingsMenuCanvas;
    public GameObject controlsMenuCanvas;


    public GameObject player;

    bool isPaused;

    public GameObject hudElements;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() //hide menus when game launches and enable the player look script
    {
        resumeButton();//resume game

        pauseMenuCanvas.SetActive(false);
        settingsMenuCanvas.SetActive(false);
        controlsMenuCanvas.SetActive(false);

        player.GetComponent<playerLook>().enabled = true;
        player.GetComponent<PickupItem>().enabled = true;

    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && isPaused == false) //if esc key pressed then pause game
        {
            isPaused = true;

            player.GetComponent<playerLook>().enabled = false;//disable player look controls
            player.GetComponent<PickupItem>().enabled = false;//disable player raycast controls for picking up items
            Cursor.lockState = CursorLockMode.None;//let the player move the cursor
            pauseMenuCanvas.SetActive(true); //show pause menu
            Cursor.visible = true; //show cursor
            Time.timeScale = 0f; //pause time
        }

        if (isPaused == true)
        {
            hudElements.SetActive(false);
        }
        if (isPaused == false)
        {
            hudElements.SetActive(true);
        }
    }

    //pause menu buttons
    public void resumeButton() //virtual
    {
        pauseMenuCanvas.SetActive(false);//hide pause menu

        isPaused = false;

        if (noteMenu.inNotesMenu == false)//if the player wasnt in the notes menu when pausing
        {
            Time.timeScale = 1f; //unpause time
            Cursor.visible = false; //hides cursor
            player.GetComponent<playerLook>().enabled = true;//re-enable player look controls
            player.GetComponent<PickupItem>().enabled = true;//re-enable player raycast controls for picking up items
            Cursor.lockState = CursorLockMode.Locked; //re-Locks cursor to middle of the screen
        }

    }
    public void settingsButton() //virtual
    {
        //hide the pause menu and show the settings menu 
        pauseMenuCanvas.SetActive(false);
        settingsMenuCanvas.SetActive(true);
    }
    public void controlsButton() //virtual
    {
        //hide the pause menu and show the settings menu 
        pauseMenuCanvas.SetActive(false);
        controlsMenuCanvas.SetActive(true);
    }
    public void exitToMenuButton() //virtual
    {
        SceneManager.LoadScene("mainMenu");
    }
    public void quitButton() //virtual
    {
        Application.Quit();
    }

    //settings menu buttons
    public void settingsBackButton() //virtual
    {
        //hide the settings menu and show the pause menu 
        pauseMenuCanvas.SetActive(true);
        settingsMenuCanvas.SetActive(false);
    }

    //controls menu buttons
    public void controlsBackButton() //virtual
    {
        //hide the controls menu and show the pause menu 
        pauseMenuCanvas.SetActive(true);
        controlsMenuCanvas.SetActive(false);
    }
}
