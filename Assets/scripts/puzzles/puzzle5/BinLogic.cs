using System.Collections.Generic;
using UnityEngine;

public class BinLogic : MonoBehaviour
{
    public GameObject explosionParticles; // Reference to the explosion prefab
    [SerializeField] List<int> validIDs;
    public bool puzzleCompleteFlag = false;
    public bool resetPuzzleFlag = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("canPickup"))
        {
            puzzleConcept1_Item item = other.gameObject.GetComponent<puzzleConcept1_Item>();
            if (item != null)
            {
                if (validIDs.Contains(item.idNumber))
                {
                    bool flag = validIDs.Remove(item.idNumber);
                    Debug.Log(flag ? "Removed item successfully" : "Item unable to be removed or item not found in list");

                    // Instantiate explosion effect before destroying the object
                    Instantiate(explosionParticles, other.transform.position, other.transform.rotation);

                    Destroy(other.gameObject);

                    if (validIDs.Count == 0)
                    {
                        puzzleCompleteFlag = true;
                        Debug.Log("Puzzle Complete");
                        PlayerPrefs.SetInt("puzzle5Status", 1); // Mark as complete
                    }
                }
                else
                {
                    resetPuzzleFlag = true;
                }
            }
            else
            {
                Debug.Log("PuzzleConcept1_Item is null");
            }
        }
    }
}