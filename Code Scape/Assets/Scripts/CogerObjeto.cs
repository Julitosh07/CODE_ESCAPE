using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject handPoint;
    private GameObject pickedObject = null;

    void Update()
    {
        if (pickedObject != null)
        {
            if (Input.GetKey("r"))
            {
                Rigidbody rb = pickedObject.GetComponent<Rigidbody>();

                rb.useGravity = true;
                rb.isKinematic = false;
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;

                pickedObject.transform.SetParent(null);

                pickedObject = null;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Objeto"))
        {
            if (Input.GetKey("e") && pickedObject == null)
            {
                Rigidbody rb = other.GetComponent<Rigidbody>();

                rb.useGravity = false;
                rb.isKinematic = true;

                other.transform.position = handPoint.transform.position;
                other.transform.SetParent(handPoint.transform);

                pickedObject = other.gameObject;
            }
        }
    }
}