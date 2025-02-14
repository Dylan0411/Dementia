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
        //show correct hud elements
        interactWithTableText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray;
        RaycastHit hit;

        ray = Camera.main.ScreenPointToRay(Input.mousePosition); //fire ray from camera constantly

        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red); //TEMP - DELETE THIS

        if (Physics.Raycast(ray, out hit, 2.5f)) //shoot ray
        {

            if (hit.collider.gameObject.tag == "puzzle4Table") //if the player is looking at the puzzle 4 table...
            {
                //show correct hud elements
                interactWithTableText.SetActive(true);

                if (Input.GetKeyDown(KeyCode.F)) //use table
                { 
                    //show correct hud elements
                    interactWithTableText.SetActive(false);
                    interactableCrosshair.SetActive(false);
                    //
                    table.SetActive(false); //removes the initial hitbox to trigger the start of the puzzle
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
    }
}