using UnityEngine;

public class mazeCompleter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "mazeCompletionZone") //allow jumping when touching a "floor" object
        {
            Debug.Log("Maze Completed");

            PlayerPrefs.SetInt("puzzle6Status", 1); //mark as complete
        }
    }
}
