using Unity.VisualScripting;
using UnityEngine;

public class crosshairController : MonoBehaviour
{
    public GameObject interactableCrosshair;
    public GameObject defaultCrosshair;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactableCrosshair.SetActive(false);
        defaultCrosshair.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        int note1Status = PlayerPrefs.GetInt("puzzle1Status", 0);
        int note3Status = PlayerPrefs.GetInt("puzzle3Status", 0);
        int note5Status = PlayerPrefs.GetInt("puzzle5Status", 0);


        Ray ray;
        RaycastHit hit;

        ray = Camera.main.ScreenPointToRay(Input.mousePosition); // fire ray from camera constantly

        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red); //TEMP - DELETE THIS

        if (Time.timeScale > 0) //if game isnt paused
        {
            if (Physics.Raycast(ray, out hit, 2.5f)) //shoot ray (allow it to shoot through layer -> any invisible colliders)
            {

                if (note1Status == 1 && note5Status == 1 && hit.collider.gameObject.tag == "brokenItemArea")//if the item is collectable the crosshair changes for the player (AND puzzle 1 is complete)
                {
                    interactableCrosshair.SetActive(true);
                    defaultCrosshair.SetActive(false);
                }
                else if (hit.collider.gameObject.tag == "itemDestination")//if the item is collectable the crosshair changes for the player
                {
                    interactableCrosshair.SetActive(true);
                    defaultCrosshair.SetActive(false);
                }
                else if (hit.collider.gameObject.tag == "canPickup")//if the item is collectable the crosshair changes for the player
                {
                    interactableCrosshair.SetActive(true);
                    defaultCrosshair.SetActive(false);
                }
                else if (note3Status == 1 && hit.collider.gameObject.tag == "puzzle4Picture")//if the item is collectable the crosshair changes for the player (AND puzzle 3 is complete)
                {
                    interactableCrosshair.SetActive(true);
                    defaultCrosshair.SetActive(false);
                }
                else if (hit.collider.gameObject.tag == "lightSwitch1")
                {
                    interactableCrosshair.SetActive(true);
                    defaultCrosshair.SetActive(false);
                }
                else if (hit.collider.gameObject.tag == "lightSwitch2")
                {
                    interactableCrosshair.SetActive(true);
                    defaultCrosshair.SetActive(false);
                }
                else if (hit.collider.gameObject.tag == "lightSwitch3")
                {
                    interactableCrosshair.SetActive(true);
                    defaultCrosshair.SetActive(false);
                }
                else if (hit.collider.gameObject.tag == "lightSwitch4")
                {
                    interactableCrosshair.SetActive(true);
                    defaultCrosshair.SetActive(false);
                }
                else if (hit.collider.gameObject.tag == "lightSwitch5")
                {
                    interactableCrosshair.SetActive(true);
                    defaultCrosshair.SetActive(false);
                }
                else if (hit.collider.gameObject.tag == "water1")
                {
                    interactableCrosshair.SetActive(true);
                    defaultCrosshair.SetActive(false);
                }
                else if (hit.collider.gameObject.tag == "water2")
                {
                    interactableCrosshair.SetActive(true);
                    defaultCrosshair.SetActive(false);
                }
                else if (hit.collider.gameObject.tag == "water3")
                {
                    interactableCrosshair.SetActive(true);
                    defaultCrosshair.SetActive(false);
                }
                else //change crosshair back if ray is fired into a different tag AND display the correct text
                {
                    interactableCrosshair.SetActive(false);
                    defaultCrosshair.SetActive(true);
                }
            }
            else //change crosshair back if ray is fired into the air AND display the correct text
            {
                interactableCrosshair.SetActive(false);
                defaultCrosshair.SetActive(true);
            }
        }
    }
}
