using NUnit.Framework;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BinLogic : MonoBehaviour
{
    [SerializeField] List<int> validIDs;
    public bool puzzleCompleteFlag = false;
    public bool resetPuzzleFlag = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("canPickup"))
        {
            puzzleConcept1_Item item = other.gameObject.GetComponent<puzzleConcept1_Item>();
            if(item != null )
            {
                if(validIDs.Contains(item.idNumber))
                {
                    bool flag = validIDs.Remove(item.idNumber);
                    if(flag)
                    {
                        Debug.Log("Removed item successfully");
                    }
                    else
                    {
                        Debug.Log("Item unable to be removed or item not found in list");
                    }

                    Destroy(other.gameObject);

                    if(validIDs.Count == 0)
                    {
                        puzzleCompleteFlag = true;
                        Debug.Log("Puzzle Complete");
                        PlayerPrefs.SetInt("puzzle5Status", 1);//mark as complete
                    }

                }
                else
                {
                    resetPuzzleFlag = true;
                    //implement logic for resetting puzzle? needs discussion on if we do even do this, im not sure
                }
            }
            else
            {
                Debug.Log("PuzzleConcept1_Item is null");
            }
        }
    }
}
