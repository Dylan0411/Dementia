using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class puzzle3Starter : MonoBehaviour
{

    public GameObject interactWithTableText;
    public static bool usingTable;

    public GameObject mainPlayerCamera;
    public GameObject tableCamera;

    public GameObject player;

    public GameObject interactableCrosshair;

    public GameObject playerTablePos;

    public GameObject gridHud;

    public GameObject table;

    public GameObject grid;
    public GameObject fakeGrid;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactWithTableText.SetActive(false);

        usingTable = false;

        mainPlayerCamera.SetActive(true);
        tableCamera.SetActive(false);

        gridHud.SetActive(false);

        grid.SetActive(false);

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
                if (hit.collider.gameObject.tag == "puzzle3Area") //if the player is looking at the table with the broken item..
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
                        gridHud.SetActive(true);

                        //Switch cameras
                        tableCamera.SetActive(true);
                        mainPlayerCamera.SetActive(false);

                        //Disable player controls to prevent movement
                        player.SetActive(false);

                        //Mark table as being used
                        usingTable = true;

                        //Show fragments
                        grid.SetActive(true);
                        fakeGrid.SetActive(false);
                    }

                    else
                    {
                        gridHud.SetActive(false);
                        fakeGrid.SetActive(true);
                        grid.SetActive(false);
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

            int note3 = PlayerPrefs.GetInt("puzzle3Status"); //if the player has completed the grid puzzle..
            if (note3 == 1)
            {
                //show correct hud elements
                gridHud.SetActive(false);
                interactWithTableText.SetActive(false);
                grid.SetActive(false);
                fakeGrid.SetActive(false);

                table.tag = "Untagged"; //change tag of table (stops the player from accessing the puzzle again) 
                this.enabled = false; //disable this script
            }
        }
    }
}






