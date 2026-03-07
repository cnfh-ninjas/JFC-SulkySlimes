using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    [Header("Mouse Info")]
    public Vector3 clickStartLocation;

    [Header("Physics")]
    public Vector3 launchVector;
    public float launchForce;

    [Header("Slime")]
    public Transform slimeTransform;
    public Rigidbody slimeRigidbody;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print("Click!");
            slimeRigidbody.isKinematic = false;
            slimeRigidbody.AddForce(Vector3.forward * launchForce, ForceMode.Impulse);
            slimeRigidbody.AddForce(Vector3.up * launchForce / 2, ForceMode.Impulse);
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 mouseDifference = clickStartLocation - Input.mousePosition;
            launchVector = new Vector3(
                mouseDifference.x * 1f,
                mouseDifference.y * 1.2f,
                mouseDifference.z * 1.5f
            );
            launchVector.Normalize();
        }
        if (Input.GetMouseButtonUp(0))
        {
            print("Release");
        }
        if (Input.GetKeyDown("space"))
        {
            slimeTransform.position = clickStartLocation;
            slimeRigidbody.isKinematic = true;
        }
    }
}