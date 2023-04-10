using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBall : MonoBehaviour
{
    private Vector3 lastPosition;
    private int framesWithoutMoving;

     // Start is called before the first frame update
    void Start()
    {
        //initializes lastposition as current position
        lastPosition = transform.position;

      //  Destroy(gameObject,4);
        
    }

    // Update is called once per frame
    void Update()
    {
        IsBallStopped();
    }

    //Compares last position and current position to see if ball has stopped for at least 10 frames
    public bool IsBallStopped()
    {
        bool didBallMove = (transform.position - lastPosition).magnitude > 0.0001f;

        lastPosition= transform.position;

        if(didBallMove ) 
        {
            framesWithoutMoving = 0;
        }
        else
        {
            framesWithoutMoving += 1;
        }

        return framesWithoutMoving >= 10;
    }

}
