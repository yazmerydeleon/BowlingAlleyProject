using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayController : MonoBehaviour
{     
    [SerializeField] private float leftBound;
    [SerializeField] private float rightBound;
    [SerializeField] private float speed;
    [SerializeField] private GameObject[] bowlingBallPrefabs;
    [SerializeField] private Transform throwDirection;
    [SerializeField] private float force;
    [SerializeField] private float xAxisTorque = 1;

    public bool wasBallThrown;

    private float x;
    private float y;
    private float z;

    // Start is called before the first frame update
    void Start()
    {
        wasBallThrown = false;
    }

    // Update is called once per frame
    void Update()
    {

        x = speed * Input.GetAxis("Horizontal");

        y = 0;

        if(transform.position.x <= leftBound && x > 0 || transform.position.x >= rightBound && x < 0)
        {
            if(wasBallThrown == false)
            {
                transform.Translate(x, y, z);
            }
        }

        if (Input.GetKeyDown("space") && wasBallThrown != true)
        {
            int index = Random.Range(0, bowlingBallPrefabs.Length);
            Debug.Log(index);

            GameObject ballClone = Instantiate(bowlingBallPrefabs[index], transform);

            ballClone.GetComponent<Rigidbody>().AddForce(throwDirection.forward * -1 * force, ForceMode.Impulse);
            ballClone.GetComponent<Rigidbody>().AddTorque(new Vector3(xAxisTorque, 0, 0));

            wasBallThrown = true;

        }


//#if UNITY_ANDROID
//        if(Input.touchCount > 0)
//        {
//            Touch touch = Input.GetTouch(0);

//            if(touch.position.x > Screen.width / 2)
//            {
//                if (wasBallThrown == false)
//                {
//                    transform.Translate(transform.right * Time.deltaTime);
//                }
//            }
//            else if(touch.position.x < Screen.width / 2)
//            {
//                if(wasBallThrown == false)
//                {
//                    transform.Translate(transform.right * -1 * Time.deltaTime);
//                }                
//            }

//        }

//#endif
  }
    public void ThrowBall()
    {
        int index = Random.Range(0, bowlingBallPrefabs.Length);
        Debug.Log(index);

        GameObject ballClone = Instantiate(bowlingBallPrefabs[index], transform);

        ballClone.GetComponent<Rigidbody>().AddForce(throwDirection.forward * -1 * force, ForceMode.Impulse);
        ballClone.GetComponent<Rigidbody>().AddTorque(new Vector3(xAxisTorque, 0, 0));

        wasBallThrown = true;
    }

}
