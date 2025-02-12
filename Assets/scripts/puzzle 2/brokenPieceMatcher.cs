using UnityEngine;
using UnityEngine.UIElements;

public class brokenPieceMatcher : MonoBehaviour
{

    public int idNumber;

    public bool match;

    GameObject selectedObject;
    GameObject ghostTeaPot;
    public GameObject vfx;

    private void Start()
    {
        match = false;
        selectedObject = null;

        ghostTeaPot = GameObject.FindWithTag("ghostTeaPot");
    }

    void OnCollisionStay(Collision collision)
    {

        if (collision.gameObject.CompareTag("teapotSpout"))
        {
            if (idNumber == 1)
            {
                selectedObject = collision.gameObject;

                Debug.Log("matched spout");
                match = true;
            }
        }
        else if (collision.gameObject.CompareTag("teapotHandle1"))
        {
            if (idNumber == 2)
            {
                selectedObject = collision.gameObject;

                Debug.Log("matched handle 1");
                match = true;

            }
        }
        else if (collision.gameObject.CompareTag("teapotHandle2"))
        {
            if (idNumber == 3)
            {
                selectedObject = collision.gameObject;

                Debug.Log("matched handle 2");
                match = true;

            }
        }
        else if (collision.gameObject.CompareTag("teapotLid1"))
        {
            if (idNumber == 4)
            {
                selectedObject = collision.gameObject;

                Debug.Log("matched lid 1");
                match = true;

            }
        }
        else if (collision.gameObject.CompareTag("teapotLid2"))
        {
            if (idNumber == 5)
            {
                selectedObject = collision.gameObject;

                Debug.Log("matched lid 2");
                match = true;
            }

        }
        else if (collision.gameObject.CompareTag("teapotBase"))
        {
            if (idNumber == 6)
            {
                selectedObject = collision.gameObject;

                Debug.Log("matched base");
                match = true;

            }
        }
        else if (collision.gameObject.CompareTag("teapotMainBody"))
        {
            if (idNumber == 7)
            {
                selectedObject = collision.gameObject;
                Debug.Log("matched main body");
                match = true;

            }
        }
        else
        {
            selectedObject = null;
            match = false;
        }
    }

    private void Update()
    {
        if (match == true && brokenItem.isFollowingMouse == false)
        {

            selectedObject.tag = "Untagged";
            selectedObject.transform.position = transform.position;
            selectedObject.transform.rotation = transform.rotation;

            selectedObject.transform.SetParent(ghostTeaPot.transform);

            brokenItem.correctPieces++;

            gameObject.SetActive(false);
            vfx.SetActive(false);
        }
    }
}
