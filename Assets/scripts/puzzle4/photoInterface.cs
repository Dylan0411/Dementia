using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class photoInterface : MonoBehaviour
{

    public GameObject interactWithTableText;

    public GameObject interactableCrosshair;

    public GameObject table;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        interactWithTableText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray;
        RaycastHit hit;

        ray = Camera.main.ScreenPointToRay(Input.mousePosition); // fire ray from camera constantly

        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red); //TEMP - DELETE THIS

        if (Physics.Raycast(ray, out hit, 2.5f)) //shoot ray (allow it to shoot through layer -> any invisible colliders)
        {

            if (hit.collider.gameObject.tag == "puzzle4Table")//if the item is the table the crosshair changes for the player
            {
                Debug.Log("kaa kaaaaaa");
                //show correct hud elements
                interactWithTableText.SetActive(true);

                if (Input.GetKeyDown(KeyCode.F)) //use table
                {

                    //show correct hud elements
                    interactWithTableText.SetActive(false);
                    interactableCrosshair.SetActive(false);

                    table.SetActive(false);
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