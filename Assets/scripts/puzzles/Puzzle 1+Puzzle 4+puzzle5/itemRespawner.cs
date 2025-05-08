using UnityEngine;
using System.Collections;

public class itemRespawner : MonoBehaviour
{
    bool beenDropped = false;
    Coroutine respawnRoutine = null; // Track coroutine per instance

    public GameObject respawnLocation;

    void Update()
    {
        if (gameObject.layer == LayerMask.NameToLayer("droppedItem"))
        {
            if (!beenDropped)
            {
                beenDropped = true;
                respawnRoutine = StartCoroutine(RespawnAfterDelay(10f)); // Start delayed respawn
            }
        }
        else
        {
            beenDropped = false;
            if (respawnRoutine != null)
            {
                StopCoroutine(respawnRoutine); // Cancel this item's respawn without affecting others
                respawnRoutine = null;
            }
        }
    }

    IEnumerator RespawnAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        afterSomeTime();
    }

    void afterSomeTime()
    {
        Debug.Log("Respawning item...");
        gameObject.transform.position = respawnLocation.transform.position;
        gameObject.transform.rotation = respawnLocation.transform.rotation;

        beenDropped = false;
        respawnRoutine = null; // Reset coroutine reference
    }
}