using UnityEngine;

public class PlayerColliderScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("puzzle3ValidTile"))
        {
            Debug.Log("Child collider collided with: " + other.gameObject.name);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("puzzle3ValidTile"))
        {
            Debug.Log("Child collider exited with: " + other.gameObject.name);
        }
    }

}
