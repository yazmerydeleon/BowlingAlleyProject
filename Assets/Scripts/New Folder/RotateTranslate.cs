using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTranslate : MonoBehaviour
{
    [SerializeField] private GameObject pivotObject;
    [SerializeField] private float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(pivotObject.transform.position, new Vector3(0, 1, 0), rotationSpeed * Time.deltaTime);
        //transform.Rotate(new Vector3(0, 0, rotationSpeed) * Time.deltaTime);
    }
}
