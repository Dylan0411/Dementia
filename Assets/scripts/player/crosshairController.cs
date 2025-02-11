using Unity.VisualScripting;
using UnityEngine;

public class crosshairController : MonoBehaviour
{
    LayerMask ignoreLayer;
    public GameObject interactableCrosshair;
    public GameObject defaultCrosshair;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ignoreLayer = LayerMask.GetMask("letRaycastThrough");

        interactableCrosshair.SetActive(false);
        defaultCrosshair.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray;
        RaycastHit hit;

        ray = Camera.main.ScreenPointToRay(Input.mousePosition); // fire ray from camera constantly

        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red); //TEMP - DELETE THIS

        if (Physics.Raycast(ray, out hit, 2.5f, ~ignoreLayer)) //shoot ray (allow it to shoot through layer -> any invisible colliders)
        {

            if (hit.collider.gameObject.tag == "brokenItemArea")//if the item is collectable the crosshair changes for the player
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
