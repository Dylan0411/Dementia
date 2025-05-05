using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class puzzle6Starter : MonoBehaviour
{

    public GameObject interactWithTableText;
    public static bool usingTable;

    public GameObject mainPlayerCamera;
    public GameObject tableCamera;

    public GameObject player;

    public GameObject interactableCrosshair;

    public GameObject playerTablePos;

    public GameObject mazeHud;

    public GameObject table;

    public GameObject maze;
    public GameObject fakeMaze;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactWithTableText.SetActive(false);

        usingTable = false;

        mainPlayerCamera.SetActive(true);
        tableCamera.SetActive(false);

        mazeHud.SetActive(false);

        maze.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (usingTable == false) //if the player is walking around
        {
            Ray ray;
            RaycastHit hit;

            ray = Camera.main.ScreenPointToRay(Input.mousePosition); //fire ray from camera constantly

            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red); //TEMP - DELETE THIS

            if (Physics.Raycast(ray, out hit, 2.5f)) //shoot ray
            {
                if (hit.collider.gameObject.tag == "puzzle6Area") //if the player is looking at the table with the broken item..
                {
                    //show correct hud elements
                    interactWithTableText.SetActive(true);

                    if (Input.GetKeyDown(KeyCode.F) && usingTable == false) //use table
                    {
                        //Move player to the front of the table
                        player.transform.position = playerTablePos.transform.position;

                        //Update HUD elements
                        interactWithTableText.SetActive(false);
                        interactableCrosshair.SetActive(false);
                        mazeHud.SetActive(true);

                        //Switch cameras
                        tableCamera.SetActive(true);
                        mainPlayerCamera.SetActive(false);

                        //Disable player controls to prevent movement
                        player.SetActive(false);

                        //Mark table as being used
                        usingTable = true;

                        //Show fragments
                        maze.SetActive(true);
                        fakeMaze.SetActive(false);
                    }

                    else
                    {
                        mazeHud.SetActive(false);
                        fakeMaze.SetActive(true);
                        maze.SetActive(false);
                    }
                }
                else //show correct hud elements
                {
                    interactWithTableText.SetActive(false);
                }
            }
            else //show correct hud elements
            {
                interactWithTableText.SetActive(false);
            }

            int note6 = PlayerPrefs.GetInt("puzzle6Status"); //if the player has completed the maze puzzle..
            if (note6 == 1)
            {
                //show correct hud elements
                mazeHud.SetActive(false);
                interactWithTableText.SetActive(false);
                maze.SetActive(false);
                fakeMaze.SetActive(false);

                table.tag = "Untagged"; //change tag of table (stops the player from accessing the puzzle again) 
                this.enabled = false; //disable this script
            }
        }
    }
}


