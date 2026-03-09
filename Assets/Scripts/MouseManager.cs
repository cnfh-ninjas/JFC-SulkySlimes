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
    public Vector3 originalSlimePosition;

    void Start()
    {
        originalSlimePosition = slimeTransform.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print("Click!");
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 mouseDifference = clickStartLocation - Input.mousePosition;
            launchVector = new Vector3(
                mouseDifference.x * 1f,
                mouseDifference.y * 1.2f,
                mouseDifference.z * 1.5f
            );
            slimeTransform.position = originalSlimePosition - launchVector / 400;
            launchVector.Normalize();
        }
        if (Input.GetMouseButtonUp(0))
        {
            print("Release"); 
            slimeRigidbody.isKinematic = false;
            slimeRigidbody.AddForce(Vector3.forward * launchForce, ForceMode.Impulse);
            slimeRigidbody.AddForce(Vector3.up * launchForce / 2, ForceMode.Impulse);
        }
        if (Input.GetKeyDown("space"))
        {
            slimeTransform.position = originalSlimePosition;
            slimeRigidbody.isKinematic = true;
        }
    }
}