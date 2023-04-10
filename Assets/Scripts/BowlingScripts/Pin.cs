using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    private Vector3 lastPosition;
    private Quaternion lastRotation;
    private int framesWithoutMoving;

    public bool pinfell;
    public Vector3 initialPinPosition;
    public Quaternion initialPinRotation;

    private void Start()
    {
        initialPinPosition= transform.position;
        initialPinRotation = transform.rotation;

        //initializes lastposition as current position 
        lastPosition = transform.position;

       // pinfell = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Floor")
        {

            pinfell = true;
        }
    }

    private void Update()
    {
        //Debug.Log("pinfell: " + pinfell);
    }

}