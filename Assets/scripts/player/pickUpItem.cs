using UnityEngine;

public class PickupItem : MonoBehaviour
{





    LayerMask ignoreLayer;
    public GameObject interactableCrosshair;
    public GameObject defaultCrosshair;

    public Transform playerHand;

    public GameObject dropItemText;
    public GameObject pickUpItemText;

    GameObject collectedItem;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ignoreLayer = LayerMask.GetMask("letRaycastThrough");

        interactableCrosshair.SetActive(false);
        defaultCrosshair.SetActive(true);
        dropItemText.SetActive(false);
        pickUpItemText.SetActive(false);

        collectedItem = null;
    }




    // Update is called once per frame
    void Update()
    {

        if (collectedItem != null) //if player is holding an item then...
        {
            if (Input.GetKeyDown(KeyCode.F)) //drop item
            {
                //renable the items physics
                Rigidbody itemRigidbody = collectedItem.GetComponent<Rigidbody>();
                itemRigidbody.isKinematic = false;

                //re-enable the items collider
                Collider itemCollider = collectedItem.GetComponent<Collider>();
                itemCollider.enabled = true;

                //drop item and remove it as a child of the hand
                collectedItem.transform.parent = null;
                collectedItem = null;

                //display no text
                dropItemText.SetActive(false);
            }
        }


        Ray ray;
        RaycastHit hit;

        ray = Camera.main.ScreenPointToRay(Input.mousePosition); // fire ray from camera constantly

        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red); //TEMP - DELETE THIS

        if (Physics.Raycast(ray, out hit, 2.5f , ~ignoreLayer)) //shoot ray (allow it to shoot through layer -> any invisible colliders)
        {
            if (hit.collider.gameObject.tag == "canPickup")//if the item is collectable the crosshair changes for the player
            {
                interactableCrosshair.SetActive(true);
                defaultCrosshair.SetActive(false);
                pickUpItemText.SetActive(true);
                dropItemText.SetActive(false);

                if (collectedItem == null) //ensures player doesnt pick up multiple items
                {
                    if (Input.GetKeyDown(KeyCode.F)) //pickup item
                    {
                        //note which item the player is holding
                        collectedItem = hit.collider.gameObject;

                        //disable the items collider
                        Collider itemCollider = collectedItem.GetComponent<Collider>();
                        itemCollider.enabled = false;

                        //move item into hand
                        collectedItem.transform.position = playerHand.position;

                        //reset rotation of the object to match the hand
                        collectedItem.transform.rotation = playerHand.rotation;

                        //make it a child of the hand
                        collectedItem.transform.parent = playerHand;

                        //display correct text
                        dropItemText.SetActive(true);
                        pickUpItemText.SetActive(false);

                        //disable the items physics
                        Rigidbody itemRigidbody = collectedItem.GetComponent<Rigidbody>();
                        itemRigidbody.isKinematic = true;
                    }
                }
            }
            else //change crosshair back if ray is fired into a different tag AND display the correct text
            {
                interactableCrosshair.SetActive(false);
                defaultCrosshair.SetActive(true);
                pickUpItemText.SetActive(false);
                if (collectedItem != null)
                {
                    dropItemText.SetActive(true);
                }
            }
        }
        else //change crosshair back if ray is fired into the air AND display the correct text
        {
            interactableCrosshair.SetActive(false);
            defaultCrosshair.SetActive(true);
            pickUpItemText.SetActive(false);
            if (collectedItem != null)
            {
                dropItemText.SetActive(true);
            }
        }
    }
}
