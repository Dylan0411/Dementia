using UnityEngine;

public class gridCompleter : MonoBehaviour
{

    public GameObject player;
    public GameObject tableCamera;
    public GameObject mainPlayerCamera;
    public GameObject interactableGrid;
    public GameObject fakeGrid;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) || PlayerPrefs.GetInt("puzzle3Status") == 1)
        {
            //Switch cameras back to the player's view
            tableCamera.SetActive(false);
            mainPlayerCamera.SetActive(true);

            //Re-enable player controls
            player.SetActive(true);

            //Mark the table as not being used
            puzzle3Starter.usingTable = false;

            //show the correct maze
            fakeGrid.SetActive(true);
            interactableGrid.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "AAA") //if this is attached to the black cylinder then should it check for collisions with the pink square?
        {
            Debug.Log("Grid Completed");

            PlayerPrefs.SetInt("puzzle3Status", 1); //mark as complete
        }
    }
}

