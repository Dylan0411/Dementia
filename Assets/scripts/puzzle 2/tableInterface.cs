using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class tableInterface : MonoBehaviour
{

    LayerMask ignoreLayer;
    public GameObject interactWithTableText;
    public static bool usingTable;

    public GameObject mainPlayerCamera;
    public GameObject tableCamera;

    public GameObject player;

    public GameObject interactableCrosshair;

    public GameObject playerTablePos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ignoreLayer = LayerMask.GetMask("letRaycastThrough");

        interactWithTableText.SetActive(false);

        usingTable = false;

        mainPlayerCamera.SetActive(true);
        tableCamera.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (usingTable == false) //if the player is walking around
        {
            Ray ray;
            RaycastHit hit;

            ray = Camera.main.ScreenPointToRay(Input.mousePosition); // fire ray from camera constantly

            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red); //TEMP - DELETE THIS

            if (Physics.Raycast(ray, out hit, 2.5f, ~ignoreLayer)) //shoot ray (allow it to shoot through layer -> any invisible colliders)
            {

                if (hit.collider.gameObject.tag == "brokenItemArea")//if the item is the table the crosshair changes for the player
                {
                    //show correct hud elements
                    interactWithTableText.SetActive(true);

                    if (Input.GetKeyDown(KeyCode.F) && usingTable == false) //use table
                    {
                        player.transform.position = playerTablePos.transform.position;//move player to the front of the table to avoid spatial disorientation

                        //cursor controller
                        Cursor.lockState = CursorLockMode.None;//let the player move the cursor
                        Cursor.visible = true; //show cursor
                        
                        //show correct hud elements
                        interactWithTableText.SetActive(false);
                        interactableCrosshair.SetActive(false);

                        //switch cameras
                        tableCamera.SetActive(true);
                        mainPlayerCamera.SetActive(false);
                        player.SetActive(false);

                        usingTable = true; //mark the table as being used (stops the player being able to walk around etc)
                    }
                }
                else //change crosshair back if ray is fired into a different tag AND display the correct text
                {
                    interactWithTableText.SetActive(false);
                }
            }
            else //change crosshair back if ray is fired into the air AND display the correct text
            {
                interactWithTableText.SetActive(false);
            }
        }
    }
}

