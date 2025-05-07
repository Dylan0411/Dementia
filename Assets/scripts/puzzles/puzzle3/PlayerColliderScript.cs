using Unity.VisualScripting;
using UnityEngine;

public class PlayerColliderScript : MonoBehaviour
{
    bool CollisionActive = false;
    GameObject self;
    void Start()
    {
        self = this.GameObject();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("puzzle3ValidTile"))// || other.CompareTag("gridCompletionZone"))
        {
            Debug.Log(self.gameObject.name + " collider collided with: " + other.gameObject.name);
            CollisionActive = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("puzzle3ValidTile"))// || other.CompareTag("gridCompletionZone"))
        {
            Debug.Log(self.gameObject.name + " collider exited with: " + other.gameObject.name);
            CollisionActive = false;
        }
    }

    public bool IsColliding()
    {
        return CollisionActive;
    }
}
