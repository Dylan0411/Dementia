using UnityEngine;

public class randomItemLocations : MonoBehaviour
{
    public GameObject potentialLocation1;
    public GameObject potentialLocation2;
    public GameObject potentialLocation3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //generate random number between 1 and 3 (this dictates which location the object will be placed)
        int randomLocation = Random.Range(1, 4);

        //applies the location and rotation
        if (randomLocation == 1)
        {
            //set the position of the object to the position of potentialLocation1
            transform.position = potentialLocation1.transform.position;
            transform.rotation = potentialLocation1.transform.rotation;
        }
        if (randomLocation == 2)
        {
            //set the position of the object to the position of potentialLocation2
            transform.position = potentialLocation2.transform.position;
            transform.rotation = potentialLocation2.transform.rotation;
        }
        if (randomLocation == 3)
        {
            //set the position of the object to the position of potentialLocation3
            transform.position = potentialLocation3.transform.position;
            transform.rotation = potentialLocation3.transform.rotation;
        }

    }
}
