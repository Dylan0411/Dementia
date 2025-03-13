using Unity.VisualScripting;
using UnityEngine;

public class puzzleUnlocker : MonoBehaviour
{

    public GameObject player;
    bool puzzle5Complete;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //enable misplaced items scritps
        player.GetComponent<PickupItem>().enabled = true;
        //disable scripts used later
        Invoke("disableScripts", 0.1f);

        puzzle5Complete = false;

    }

    // Update is called once per frame
    void Update()
    {
        //get the state of each puzzles progress
        int note1Status = PlayerPrefs.GetInt("puzzle1Status", 0);
        int note2Status = PlayerPrefs.GetInt("puzzle2Status", 0);
        int note3Status = PlayerPrefs.GetInt("puzzle3Status", 0);
        int note4Status = PlayerPrefs.GetInt("puzzle4Status", 0);
        int note5Status = PlayerPrefs.GetInt("puzzle5Status", 0);
        int note6Status = PlayerPrefs.GetInt("puzzle6Status", 0);

        if (note5Status == 1)
        {
            //do nothing (trash task should just be constant?)
            puzzle5Complete = true;
        }
        //
        if (note1Status == 1)
        {
            //added a delay so that the script can finish everything before being cut
            if (puzzle5Complete == true)
            {
                Invoke("note1Handler", 1f);
            }
        }
        if (note2Status == 1)
        {
            //added a delay so that the script can finish everything before being cut
            Invoke("note2Handler", 1f);
        }
        if (note3Status == 1)
        {
            //added a delay so that the script can finish everything before being cut
            Invoke("note3Handler", 1f);
        }
        if (note4Status == 1)
        {
            //added a delay so that the script can finish everything before being cut
            Invoke("note4Handler", 1f);
        }
        if (note6Status == 1)
        {
            //added a delay so that the script can finish everything before being cut
            Invoke("note6Handler", 1f);
        }
    }


    void note1Handler()
    {
        //enable teapot scripts
        player.GetComponent<tableInterface>().enabled = true;
    }
    void note2Handler()
    {
        //disable teapot scripts
        player.GetComponent<tableInterface>().enabled = false;

        //enable dylans grid puzzle script
        PlayerPrefs.SetInt("puzzle3Status", 1); //<<<<<<< TEMPORARY - MOVE THIS TO GRID PUZZLE SCRIPT WHEN PUZZLE IS COMPLETE
    }
    void note3Handler()
    {
        //disable dylans grid puzzle script


        //enable picture frame script
        player.GetComponent<photoInterface>().enabled = true;
    }
    void note4Handler()
    {
        //disable picture frame script
        player.GetComponent<photoInterface>().enabled = false;

        //enable dylans marble maze script
        PlayerPrefs.SetInt("puzzle6Status", 1); //<<<<<<< TEMPORARY - MOVE THIS TO MARBLE MAZE SCRIPT WHEN PUZZLE IS COMPLETE
    }
    void note6Handler()
    {
        //disable dylans marble maze script

    }
    //
    void disableScripts()
    {
        //Disable scripts that are not needed at the start of the game
        player.GetComponent<tableInterface>().enabled = false;
        player.GetComponent<photoInterface>().enabled = false;
    }
}
