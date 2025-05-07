using UnityEngine;
using UnityEngine.UIElements;

public class brokenPieceMatcher : MonoBehaviour
{
    public int idNumber;

    public bool match;

    GameObject selectedObject;
    GameObject ghostTeaPot;
    public GameObject vfx;

    public AudioSource teapotDing;


    private void Start()
    {
        match = false;
        selectedObject = null;

        ghostTeaPot = GameObject.FindWithTag("ghostTeaPot");
        
    }
   
    void OnCollisionEnter(Collision collision) //if the fragment enters the correct spot..
    {
        if (collision.gameObject.CompareTag("teapotSpout") && idNumber == 1) //if the tag matches the correct id number of this script
        {
            selectedObject = collision.gameObject; //store the fragment
            match = true; //mark it as a match
        }
        if (collision.gameObject.CompareTag("teapotHandle1") && idNumber == 2) //if the tag matches the correct id number of this script)
        {
            selectedObject = collision.gameObject; //store the fragment
            match = true; //mark it as a match
        }
        if (collision.gameObject.CompareTag("teapotHandle2") && idNumber == 3) //if the tag matches the correct id number of this script)
        {
            selectedObject = collision.gameObject; //store the fragment
            match = true; //mark it as a match
        }
        if(collision.gameObject.CompareTag("teapotLid1") && idNumber == 4) //if the tag matches the correct id number of this script)
        {
            selectedObject = collision.gameObject; //store the fragment
            match = true; //mark it as a match
        }
        if (collision.gameObject.CompareTag("teapotLid2") && idNumber == 5) //if the tag matches the correct id number of this script)
        {
            selectedObject = collision.gameObject; //store the fragment
            match = true; //mark it as a match
        }
        if (collision.gameObject.CompareTag("teapotBase") && idNumber == 6) //if the tag matches the correct id number of this script)
        {
            selectedObject = collision.gameObject; //store the fragment
            match = true; //mark it as a match
        }
        if (collision.gameObject.CompareTag("teapotMainBody") && idNumber == 7) //if the tag matches the correct id number of this script)
        {
            selectedObject = collision.gameObject; //store the fragment
            match = true; //mark it as a match
        }
    }
    void OnCollisionExit(Collision collision) //if the fragment exits the correct spot..
    {
        if (collision.gameObject.CompareTag("teapotSpout") && idNumber == 1) //if the tag matches the correct id number of this script
        {
            selectedObject = null; //STOP storing the fragment
            match = false; //UNmark it as a match
        }
        if (collision.gameObject.CompareTag("teapotHandle1") && idNumber == 2) //if the tag matches the correct id number of this script)
        {
            selectedObject = null; //STOP storing the fragment
            match = false; //UNmark it as a match
        }
        if (collision.gameObject.CompareTag("teapotHandle2") && idNumber == 3) //if the tag matches the correct id number of this script)
        {
            selectedObject = null; //STOP storing the fragment
            match = false; //UNmark it as a match
        }
        if (collision.gameObject.CompareTag("teapotLid1") && idNumber == 4) //if the tag matches the correct id number of this script)
        {
            selectedObject = null; //STOP storing the fragment
            match = false; //UNmark it as a match
        }
        if (collision.gameObject.CompareTag("teapotLid2") && idNumber == 5) //if the tag matches the correct id number of this script)
        {
            selectedObject = null; //STOP storing the fragment
            match = false; //UNmark it as a match
        }
        if (collision.gameObject.CompareTag("teapotBase") && idNumber == 6) //if the tag matches the correct id number of this script)
        {
            selectedObject = null; //STOP storing the fragment
            match = false; //UNmark it as a match
        }
        if (collision.gameObject.CompareTag("teapotMainBody") && idNumber == 7) //if the tag matches the correct id number of this script)
        {
            selectedObject = null; //STOP storing the fragment
            match = false; //UNmark it as a match
        }
    }

    private void Update()
    {
        if (match == true && brokenItem.isFollowingMouse == false) //if its a match and the players stopped moving it..
        {
            selectedObject.tag = "Untagged"; //this stops the player being able to pick it back up

            selectedObject.transform.position = transform.position; //snap the fragment into the correct position
            selectedObject.transform.rotation = transform.rotation; //snap the fragment into the correct rotation

            selectedObject.transform.SetParent(ghostTeaPot.transform); //make it a child of the ghost teapot (so that it rotates with the teapot)

            brokenItem.correctPieces++; //mark it as correctly in place (when this reaches 7 the puzzle is marked as complete)

            gameObject.SetActive(false); //hide the ghost fragment
            
            vfx.SetActive(false); //hide particle effects of the fragment

            teapotDing.Play();

        }
    }
}