using UnityEngine;

public class mazeCompleter : MonoBehaviour
{
    public GameObject player;
    public GameObject tableCamera;
    public GameObject mainPlayerCamera;
    public GameObject interactableMaze;
    public GameObject fakeMaze;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) || PlayerPrefs.GetInt("puzzle6Status") == 1)
        {
            //Switch cameras back to the player's view
            tableCamera.SetActive(false);
            mainPlayerCamera.SetActive(true);

            //Re-enable player controls
            player.SetActive(true);

            //Mark the table as not being used
            puzzle6Starter.usingTable = false;

            //show the correct maze
            fakeMaze.SetActive(true);
            interactableMaze.SetActive(false);
        }
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
