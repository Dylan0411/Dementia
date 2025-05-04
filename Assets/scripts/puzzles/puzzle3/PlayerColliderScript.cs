using UnityEngine;

public class PlayerColliderScript : MonoBehaviour
{
    bool CollisionActive = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("puzzle3ValidTile"))
        {
            Debug.Log("Child collider collided with: " + other.gameObject.name);
            CollisionActive = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("puzzle3ValidTile"))
        {
            Debug.Log("Child collider exited with: " + other.gameObject.name);
            CollisionActive = false;
        }
    }

    public bool IsColliding()
    {
        return CollisionActive;
    }
}
