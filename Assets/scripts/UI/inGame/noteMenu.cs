using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class noteMenu : MonoBehaviour
{

    public GameObject hudCanvas;
    public GameObject notesCanvas;

    public GameObject player;

    public GameObject note1Button;
    public GameObject note2Button;
    public GameObject note3Button;
    public GameObject note4Button;

    public Text noteText;

    public static bool inNotesMenu;

    public GameObject notification;
    public GameObject notificationPopUpPos;
    public GameObject notificationDefaultPos;

    float notificationMovementSpeed = 20f; //feel free to change :)

    bool noteNotification;

    bool note1Activated;
    bool note2Activated;
    bool note3Activated;
    bool note4Activated;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hudCanvas.SetActive(true);
        notesCanvas.SetActive(false);

        noteText.text = "";
        inNotesMenu = false;

        notification.transform.position = notificationDefaultPos.transform.position;

        noteNotification = false;

        note1Activated = false;
        note2Activated = false;
        note3Activated = false;
        note4Activated = false;

        note1Button.SetActive(false);
        note2Button.SetActive(false);
        note3Button.SetActive(false);
        note4Button.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        //notes menu button
        if (Input.GetKeyUp(KeyCode.Tab)) //if tab key pressed then pause game and show notes menu
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

        //display the correct notes, default is 0 (no note) <<<<<<<<<<<<<<<<<<<<<<<add more notes if needed
        int note1Status = PlayerPrefs.GetInt("note1Status", 0);
        int note2Status = PlayerPrefs.GetInt("note2Status", 0);
        int note3Status = PlayerPrefs.GetInt("note3Status", 0);
        int note4Status = PlayerPrefs.GetInt("note4Status", 0);

        if (note1Status == 1 && note1Activated == false)
        {
            note1Button.SetActive(true);//show button in notes menu
            //display a notification about the new note (ONLY ONCE)
            noteNotification = true;
            note1Activated = true;
        }
        //
        if (note2Status == 1 && note2Activated == false)
        {
            note2Button.SetActive(true);//show button in notes menu
            //display a notification about the new note (ONLY ONCE)
            noteNotification = true;
            note2Activated = true;
        }
        //
        if (note3Status == 1 && note3Activated == false)
        {
            note3Button.SetActive(true);//show button in notes menu
            //display a notification about the new note (ONLY ONCE)
            noteNotification = true;
            note3Activated = true;
        }
        //
        if (note4Status == 1 && note4Activated == false)
        {
            note4Button.SetActive(true);//show button in notes menu
            //display a notification about the new note (ONLY ONCE)
            noteNotification = true;
            note4Activated = true;
        }
    }




    private void FixedUpdate()
    {
        //new note notification
        if (noteNotification == true)
        {
            if (notification.transform.position != notificationPopUpPos.transform.position)
            {
                notification.transform.position = Vector3.MoveTowards(notification.transform.position, notificationPopUpPos.transform.position, notificationMovementSpeed);
            }
            else
            {
                Invoke("hideNotification", 3f);//wait 3 seconds before hiding the notification
            }
        }
        else
        {
            if (notification.transform.position != notificationDefaultPos.transform.position)
            {
                notification.transform.position = Vector3.MoveTowards(notification.transform.position, notificationDefaultPos.transform.position, notificationMovementSpeed);
            }
        }
    }



    void hideNotification()
    {
        noteNotification = false;
    }

    //exit button
    public void exitButton()
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

    //note buttons<<<<<<<<<<<<<<<<<<<<<<<add more notes if needed
    public void noteOneButton()
    {
        noteText.text = "note 1 text blaaa aaaa aaaa blaa aa aaa aaaa aaaa bla aaaa aaaaa aa blaaa aaaa aaaa blaa aa aaa aaaa aaaa bla aaaa aaaaa aa";
    }
    public void noteTwoButton()
    {
        noteText.text = "note 2 text blaaa aaaa aaaa blaa aa aaa aaaa aaaa bla aaaa aaaaa aa blaaa aaaa aaaa blaa aa aaa aaaa aaaa bla aaaa aaaaa aa";
    }
    public void noteThreeButton()
    {
        noteText.text = "note 3 text blaaa aaaa aaaa blaa aa aaa aaaa aaaa bla aaaa aaaaa aa blaaa aaaa aaaa blaa aa aaa aaaa aaaa bla aaaa aaaaa aa";
    }
    public void noteFourButton()
    {
        noteText.text = "note 4 text blaaa aaaa aaaa blaa aa aaa aaaa aaaa bla aaaa aaaaa aa blaaa aaaa aaaa blaa aa aaa aaaa aaaa bla aaaa aaaaa aa";
    }


}
