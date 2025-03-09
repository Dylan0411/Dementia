using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class PickupItem : MonoBehaviour
{
    public Transform playerHand;

    public GameObject dropItemText;
    public GameObject pickUpItemText;
    public GameObject placeItemText;

    public static GameObject collectedItem;
    GameObject itemDestination;

    bool canDrop;

    int itemsReturned;
    public int totalNumberOfItems;

    public Text hudItemIdText;

    public GameObject destination1;
    public GameObject destination2;
    public GameObject destination3;
    public GameObject destination4;
    public GameObject destination5;
    public GameObject destination6;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hudItemIdText.text = "";

        dropItemText.SetActive(false);
        pickUpItemText.SetActive(false);
        placeItemText.SetActive(false);

        collectedItem = null;
        itemDestination = null;
        canDrop = false;

        itemsReturned = 0;
        totalNumberOfItems = 6;//CHANGE THIS IN THE FUTURE TO MATCH THE ACTUAL VALUE<<<<<<<<<<<<<<<<<<<<<<<

        PlayerPrefs.SetInt("note1Status", 0);//<<<<<<<<<<<<<<<<<<<<DELETE THIS IF USING SAVE DATA IN FUTURE
        PlayerPrefs.SetInt("note4Status", 0);//<<<<<<<<<<<<<<<<<<<<DELETE THIS IF USING SAVE DATA IN FUTURE

        destination1.SetActive(false);
        destination2.SetActive(false);
        destination3.SetActive(false);
        destination4.SetActive(false);
        destination5.SetActive(false);
        destination6.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (collectedItem != null && canDrop == true) //if player is holding an item then...
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

        ray = Camera.main.ScreenPointToRay(Input.mousePosition); //fire ray from camera constantly

        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red); //TEMP - DELETE THIS

        if (Physics.Raycast(ray, out hit, 2.5f)) //shoot ray
        {
            if (hit.collider.gameObject.tag == "itemDestination")//if the item is collectable the crosshair changes for the player
            {
                if (collectedItem != null) //ensures player doesnt pick up multiple items
                {
                    canDrop = false;//this stops the player dropping the item when they want to place it

                    puzzleConcept1_Item itemId = collectedItem.GetComponent<puzzleConcept1_Item>();//access the id number of the item
                    puzzleConcept1_Destination destinationId = hit.collider.gameObject.GetComponent<puzzleConcept1_Destination>(); //access the id number of the destination
                    if (itemId.idNumber == destinationId.idNumber) //if the id numbers match then...
                    {
                        //show correct text (hud elements)
                        placeItemText.SetActive(true);
                        dropItemText.SetActive(false);

                        if (Input.GetKeyDown(KeyCode.F)) //place item
                        {
                            //note the destination object
                            itemDestination = hit.collider.gameObject;

                            //drop item and remove it as a child of the hand
                            collectedItem.transform.parent = null;

                            //display no text
                            dropItemText.SetActive(false);

                            //move item to destination
                            collectedItem.transform.position = itemDestination.transform.position;

                            //reset rotation of the object to match the destination
                            collectedItem.transform.rotation = itemDestination.transform.rotation;

                            //re-enable the items collider
                            Collider itemCollider = collectedItem.GetComponent<Collider>();
                            itemCollider.enabled = true;

                            //stop the player from being able to move the item
                            collectedItem.tag = "Untagged";

                            //cleanup the reference to the item as were now done with it
                            collectedItem = null;

                            //hide the destination object
                            itemDestination.SetActive(false);

                            if (itemId.idNumber == 100) //if its the wedding ring from puzzle 4 (item id 100)
                            {
                                PlayerPrefs.SetInt("note4Status", 1); //give note (puzzle complete)
                            }
                            else
                            {
                                //note down the number of items the player has returned to their correct positions
                                itemsReturned++;
                            }

                            //show correct text (hud elements)
                            placeItemText.SetActive(false);
                        }
                    }
                    else
                    {
                        canDrop = true; //allow the play to drop the item
                        //show correct text (hud elements)
                        placeItemText.SetActive(false);
                        dropItemText.SetActive(true);
                    }
                }
            }
            else if (hit.collider.gameObject.tag == "canPickup")//if the item is collectable the crosshair changes for the player
            {
                //show correct text (hud elements)
                pickUpItemText.SetActive(true);
                dropItemText.SetActive(false);

                //display the correct item name on the hud
                puzzleConcept1_Item itemId = hit.collider.gameObject.GetComponent<puzzleConcept1_Item>();//access the id number of the item
                if (itemId.idNumber == 1)
                {
                    hudItemIdText.text = "shampoo";
                }
                else if (itemId.idNumber == 2)
                {
                    hudItemIdText.text = "spatula";
                }
                else if (itemId.idNumber == 3)
                {
                    hudItemIdText.text = "tv remote";
                }
                else if (itemId.idNumber == 4)
                {
                    hudItemIdText.text = "book";
                }
                else if (itemId.idNumber == 5)
                {
                    hudItemIdText.text = "hairbrush";
                }
                else if (itemId.idNumber == 6)
                {
                    hudItemIdText.text = "headphones";
                }
                //
                else if (itemId.idNumber == 100)
                {
                    hudItemIdText.text = "Wedding Ring";
                }
                //Puzzle 5 items, names obviously temporary, just cant think of any right now.
                else if (itemId.idNumber == 501)
                {
                    hudItemIdText.text = "Item 1";
                }
                else if (itemId.idNumber == 502)
                {
                    hudItemIdText.text = "Item 2";
                }
                else if (itemId.idNumber == 503)
                {
                    hudItemIdText.text = "Item 3";
                }
                //
                else
                {
                    hudItemIdText.text = "";
                }

                //actual pickup mechanic
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

                        //display the correct destinations
                        if (itemId.idNumber == 1) //if the id numbers match then...
                        {
                            destination1.SetActive(true);
                            destination2.SetActive(false);
                            destination3.SetActive(false);
                            destination4.SetActive(false);
                            destination5.SetActive(false);
                            destination6.SetActive(false);
                        }
                        if (itemId.idNumber == 2) //if the id numbers match then...
                        {
                            destination1.SetActive(false);
                            destination2.SetActive(true);
                            destination3.SetActive(false);
                            destination4.SetActive(false);
                            destination5.SetActive(false);
                            destination6.SetActive(false);
                        }
                        if (itemId.idNumber == 3) //if the id numbers match then...
                        {
                            destination1.SetActive(false);
                            destination2.SetActive(false);
                            destination3.SetActive(true);
                            destination4.SetActive(false);
                            destination5.SetActive(false);
                            destination6.SetActive(false);
                        }
                        if (itemId.idNumber == 4) //if the id numbers match then...
                        {
                            destination1.SetActive(false);
                            destination2.SetActive(false);
                            destination3.SetActive(false);
                            destination4.SetActive(true);
                            destination5.SetActive(false);
                            destination6.SetActive(false);
                        }
                        if (itemId.idNumber == 5) //if the id numbers match then...
                        {
                            destination1.SetActive(false);
                            destination2.SetActive(false);
                            destination3.SetActive(false);
                            destination4.SetActive(false);
                            destination5.SetActive(true);
                            destination6.SetActive(false);
                        }
                        if (itemId.idNumber == 6) //if the id numbers match then...
                        {
                            destination1.SetActive(false);
                            destination2.SetActive(false);
                            destination3.SetActive(false);
                            destination4.SetActive(false);
                            destination5.SetActive(false);
                            destination6.SetActive(true);
                        }
                    }
                }










            }
            else //change crosshair back if ray is fired into a different tag AND display the correct text
            {
                //show correct text (hud elements)
                pickUpItemText.SetActive(false);
                placeItemText.SetActive(false);
                if (collectedItem != null)
                {
                    dropItemText.SetActive(true);
                    canDrop = true;//allow the player to drop the item in their hand
                }
            }
        }
        else //change crosshair back if ray is fired into the air AND display the correct text
        {
            //show correct text (hud elements)
            pickUpItemText.SetActive(false);
            placeItemText.SetActive(false);
            if (collectedItem != null)
            {
                dropItemText.SetActive(true);
                canDrop = true;//allow the player to drop the item in their hand
            }
        }

        if (itemsReturned == totalNumberOfItems)//when the player completes puzzle concept 1
        {
            PlayerPrefs.SetInt("note1Status", 1); //give note (puzzle complete)
        }

        //display the correct destinations(reset)
        if (collectedItem == null)
        {
            destination1.SetActive(false);
            destination2.SetActive(false);
            destination3.SetActive(false);
            destination4.SetActive(false);
            destination5.SetActive(false);
            destination6.SetActive(false);
        }
    }
}