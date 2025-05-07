using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections; // Required for IEnumerator

public class noteMenu : MonoBehaviour
{
    public GameObject hudCanvas;
    public GameObject notesCanvas;

    public GameObject player;

    public GameObject note1Button;
    public GameObject note2Button;
    public GameObject note3Button;
    public GameObject note4Button;
    public GameObject note5Button;
    public GameObject note6Button;

    public Text noteText;

    public static bool inNotesMenu;

    public GameObject noteNotificationPopUp;
    public GameObject progressNotificationPopUp;
        //
    public GameObject noteNotificationPopUpPos;
    public GameObject noteNotificationDefaultPos;
    public GameObject progressNotificationPopUpPos;
    public GameObject progressNotificationDefaultPos;

    float notificationMovementSpeed = 20f; //feel free to change :)

    bool noteNotification;
    bool progressNotification;

    bool puzzle1Activated;
    bool puzzle1And5Activated;
    bool note2Activated;
    bool note3Activated;
    bool puzzle5Activated;
    bool note4Activated;
    bool note6Activated;

    public GameObject noteNotificationCanvas;

    public GameObject note1Tick;
    public GameObject note2Tick;
    public GameObject note3Tick;
    public GameObject note4Tick;
    public GameObject note5Tick;
    public GameObject note6Tick;

    public GameObject endOfGameCanvas;
    bool faded;
    public Image targetImage;
    public float fadeDuration = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        faded = false;

        FadeOut();

        noteNotificationCanvas.SetActive(true);

        hudCanvas.SetActive(true);
        notesCanvas.SetActive(false);

        noteText.text = "";
        inNotesMenu = false;

        noteNotificationPopUp.transform.position = noteNotificationDefaultPos.transform.position;
        progressNotificationPopUp.transform.position = progressNotificationDefaultPos.transform.position;

        noteNotification = false;
        progressNotification = false;

        puzzle1Activated = false;
        puzzle1And5Activated = false;
        note2Activated = false;
        note3Activated = false;
        puzzle5Activated = false;
        note4Activated = false;
        note6Activated = false;

        note1Button.SetActive(false);
        note2Button.SetActive(false);
        note3Button.SetActive(false);
        note4Button.SetActive(false);
        note5Button.SetActive(false);
        note6Button.SetActive(false);

        //for note 0 at start of game
        Invoke("showStartNotification", 3f);//wait 3 seconds before displaying the notification << change in future if needed

        //DELETE THIS IF USING SAVE DATA IN FUTURE
        PlayerPrefs.SetInt("puzzle1Status", 0);
        PlayerPrefs.SetInt("puzzle2Status", 0);
        PlayerPrefs.SetInt("puzzle3Status", 0);
        PlayerPrefs.SetInt("puzzle4Status", 0);
        PlayerPrefs.SetInt("puzzle5Status", 0);
        PlayerPrefs.SetInt("puzzle6Status", 0);

        note1Tick.SetActive(false);
        note2Tick.SetActive(false);
        note3Tick.SetActive(false);
        note4Tick.SetActive(false);
        note5Tick.SetActive(false);
        note6Tick.SetActive(false);

        endOfGameCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //display the correct notes, default is 0 (no note) -> can add more in future if needed
        int puzzle1Status = PlayerPrefs.GetInt("puzzle1Status", 0);
        int puzzle2Status = PlayerPrefs.GetInt("puzzle2Status", 0);
        int puzzle3Status = PlayerPrefs.GetInt("puzzle3Status", 0);
        int puzzle4Status = PlayerPrefs.GetInt("puzzle4Status", 0);
        int puzzle5Status = PlayerPrefs.GetInt("puzzle5Status", 0);
        int puzzle6Status = PlayerPrefs.GetInt("puzzle6Status", 0);

        //notes menu button
        if (Input.GetKeyUp(KeyCode.Tab) && puzzle6Status != 1) //if tab key pressed then pause game and show notes menu
        {
            if (Time.timeScale == 1f)//if game not already paused...
            {
                player.GetComponent<playerLook>().enabled = false;//disable player look controls
                player.GetComponent<PickupItem>().enabled = false;//disable player raycast controls for picking up items
                Cursor.lockState = CursorLockMode.None;//let the player move the cursor
                hudCanvas.SetActive(false); //hide hud
                notesCanvas.SetActive(true); //show notes menu
                Cursor.visible = true; //show cursor
                Time.timeScale = 0f; //pause time
                inNotesMenu = true;//signal to the pause menu that notes are open
            }
        }



        //when a variable == 1, it means the puzzle is complete

        //display correct tick boxes, notes in note menus, and note notifications
        if (puzzle1Status == 1 && puzzle1Activated == false)
        {
            note1Tick.SetActive(true);
            progressNotification = true;

            puzzle1Activated = true;
        }
        if (puzzle5Status == 1 && puzzle5Activated == false)
        {
            note5Tick.SetActive(true);
            progressNotification = true;

            puzzle5Activated = true;
        }
        if (puzzle1Status == 1 && puzzle5Status == 1 && puzzle1And5Activated == false)
        {
            note2Button.SetActive(true);//show button in notes menu
                                        //display a notification about the new note (ONLY ONCE)
            noteNotification = true;
            puzzle1And5Activated = true;
        }
        //
        if (puzzle2Status == 1 && note2Activated == false)
        {
            note2Tick.SetActive(true);
            progressNotification = true;
            //
            note3Button.SetActive(true);//show button in notes menu
            //display a notification about the new note (ONLY ONCE)
            noteNotification = true;
            note2Activated = true;
        }
        if (puzzle3Status == 1 && note3Activated == false)
        {
            note3Tick.SetActive(true);
            progressNotification = true;
            //
            note4Button.SetActive(true);//show button in notes menu
            //display a notification about the new note (ONLY ONCE)
            noteNotification = true;
            note3Activated = true;
        }
        if (puzzle4Status == 1 && note4Activated == false)
        {
            note4Tick.SetActive(true);
            progressNotification = true;
            //
            note6Button.SetActive(true);//show button in notes menu
            //display a notification about the new note (ONLY ONCE)
            noteNotification = true;
            note4Activated = true;
        }
        if (puzzle6Status == 1 && note6Activated == false)
        {
            note6Tick.SetActive(true);
            progressNotification = true;

            note6Activated = true;
        }


        //check if all puzzles are complete
        if (puzzle1Status + puzzle2Status + puzzle3Status + puzzle4Status + puzzle5Status + puzzle6Status == 6)
        {
            //enable end of game script
            Debug.Log("All puzzles complete!");



            //then wait for 3 seconds via an invoke
            Invoke("beginEndOfGame", 2f);

        }

        //if the game is paused, hide the notification canvas
        if (Time.timeScale == 0)
        {
            noteNotificationCanvas.SetActive(false); //hide notification canvas
        }
        else
        {
            noteNotificationCanvas.SetActive(true); //show notification canvas
        }
    }

    void beginEndOfGame()
    {
        hudCanvas.SetActive(false); //hide hud

        //fade screen to black (make sure black screen is above hud elements)
        if (faded == false)
        {
            fadeDuration = 3f;
            FadeIn();
            faded = true;
        }

        //then wait for 3 seconds via an invoke
        Invoke("endOfGame", 3f);

    }

    void endOfGame()
    {
        //pause game
        player.GetComponent<playerLook>().enabled = false;//disable player look controls
        player.GetComponent<PickupItem>().enabled = false;//disable player raycast controls for picking up items
        //Time.timeScale = 0f; //pause time

        //display some sort of message
        endOfGameCanvas.SetActive(true); //show end of game screen

        //then wait for 20 seconds via an invoke
        Invoke("loadMainMenu", 10f);

    }

    void loadMainMenu() //call this via an Invoke
    {
        //load main menu scene
        SceneManager.LoadScene("mainMenu");
    }



    //for fading camera
    public void FadeIn()
    {
        StartCoroutine(FadeImage(0f, 1f));
    }

    public void FadeOut()
    {
        StartCoroutine(FadeImage(1f, 0f));
    }

    private IEnumerator FadeImage(float startAlpha, float endAlpha)
    {
        float elapsedTime = 0f;
        Color color = targetImage.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / fadeDuration);
            targetImage.color = color;
            yield return null;
        }

        color.a = endAlpha; // Ensure the final alpha value is exact
        targetImage.color = color;
    }













    private void FixedUpdate()
    {
        //new note notification
        if (noteNotification == true)
        {
            if (noteNotificationPopUp.transform.position != noteNotificationPopUpPos.transform.position) //if notification isnt in destination..
            {
                noteNotificationPopUp.transform.position = Vector3.MoveTowards(noteNotificationPopUp.transform.position, noteNotificationPopUpPos.transform.position, notificationMovementSpeed); //move it onto the screen
            }
            else
            {
                Invoke("hideNoteNotification", 3f);//wait 3 seconds before hiding the notification
            }
        }
        else
        {
            if (noteNotificationPopUp.transform.position != noteNotificationDefaultPos.transform.position) //if notification isnt in destination..
            {
                noteNotificationPopUp.transform.position = Vector3.MoveTowards(noteNotificationPopUp.transform.position, noteNotificationDefaultPos.transform.position, notificationMovementSpeed); //move it out the screen
            }
        }
        //puzzle complete notification
        if (progressNotification == true)
        {
            if (progressNotificationPopUp.transform.position != progressNotificationPopUpPos.transform.position) //if notification isnt in destination..
            {
                progressNotificationPopUp.transform.position = Vector3.MoveTowards(progressNotificationPopUp.transform.position, progressNotificationPopUpPos.transform.position, notificationMovementSpeed); //move it onto the screen
            }
            else
            {
                Invoke("hideProgressNotification", 3f);//wait 3 seconds before hiding the notification
            }
        }
        else
        {
            if (progressNotificationPopUp.transform.position != progressNotificationDefaultPos.transform.position) //if notification isnt in destination..
            {
                progressNotificationPopUp.transform.position = Vector3.MoveTowards(progressNotificationPopUp.transform.position, progressNotificationDefaultPos.transform.position, notificationMovementSpeed); //move it out the screen
            }
        }
    }

    void hideProgressNotification() //call this via an Invoke
    {
        progressNotification = false; //hide notification
    }
    void hideNoteNotification() //call this via an Invoke
    {
        noteNotification = false; //hide notification
    }



    //exit button
    public void exitButton() //virtual
    {
        Time.timeScale = 1f; //unpause time
        hudCanvas.SetActive(true); //show hud
        notesCanvas.SetActive(false); //hide notes menu
        Cursor.visible = false; //hides cursor
        player.GetComponent<playerLook>().enabled = true;//re-enable player look controls
        player.GetComponent<PickupItem>().enabled = true;//re-enable player raycast controls for picking up items
        Cursor.lockState = CursorLockMode.Locked; //re-Locks cursor to middle of the screen
        inNotesMenu = false;//signal to the pause menu that notes are closed
    }

    //note buttons (can add more if needed)
    public void noteOneButton() //virtual
    {
        noteText.text = "note 1 - objective: take misplaced items back to original homes. text blaaa aaaa aaaa blaa aa aaa aaaa aaaa bla aaaa aaaaa aa blaaa aaaa aaaa blaa aa aaa aaaa aaaa bla aaaa aaaaa aa";
    }
    public void noteTwoButton() //virtual
    {
        noteText.text = "note 2 - objective: repair the broken teapot. text blaaa aaaa aaaa blaa aa aaa aaaa aaaa bla aaaa aaaaa aa blaaa aaaa aaaa blaa aa aaa aaaa aaaa bla aaaa aaaaa aa";
    }
    public void noteThreeButton() //virtual
    {
        noteText.text = "note 3 - objective: complete dylans grid puzzle. (automatically skipped as its incomplete). text blaaa aaaa aaaa blaa aa aaa aaaa aaaa bla aaaa aaaaa aa blaaa aaaa aaaa blaa aa aaa aaaa aaaa bla aaaa aaaaa aa";
    }
    public void noteFourButton() //virtual
    { 
        noteText.text = "note 4 - objective: find photo to trigger memory(memory prompts player to find a relevant item, eg a wedding ring and bring it back to the photo). text blaaa aaaa aaaa blaa aa aaa aaaa aaaa bla aaaa aaaaa aa blaaa aaaa aaaa blaa aa aaa aaaa aaaa bla aaaa aaaaa aa";
    }
    public void noteFiveButton() //virtual
    {
        noteText.text = "note 5 - objective: clean the house by taking any rubbish to the bin. text blaaa aaaa aaaa blaa aa aaa aaaa aaaa bla aaaa aaaaa aa blaaa aaaa aaaa blaa aa aaa aaaa aaaa bla aaaa aaaaa aa";
    }
    public void noteSixButton() //virtual
    {
        noteText.text = "note 6 - objective: complete dylans marble maze puzzle. (automatically skipped as its incomplete). text blaaa aaaa aaaa blaa aa aaa aaaa aaaa bla aaaa aaaaa aa blaaa aaaa aaaa blaa aa aaa aaaa aaaa bla aaaa aaaaa aa";
    }


    //for note 0 at start of game
    void showStartNotification() //call this via an Invoke
    {
        noteNotification = true;
        note1Button.SetActive(true);//show button in notes menu
        note5Button.SetActive(true);//show button in notes menu

    }
}
