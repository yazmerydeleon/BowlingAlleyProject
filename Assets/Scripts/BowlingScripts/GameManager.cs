using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Pin[] Pins;

    [SerializeField] private PlayController playController;

    [SerializeField] private Vector3 initialCamPosition;

    [SerializeField] private float resetTime;

    [SerializeField] private TMP_Text frameTotalScore;
    [SerializeField] private TMP_Text frameNumber;
    [SerializeField] private TMP_Text frame1stThrowcore;
    [SerializeField] private TMP_Text frame2ndThrowcore;

    private int totalScore = 0;
    private int currentFrame = 1;
    private int currentScore;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("GameManager");
        resetTime = 4.0f;
        initialCamPosition = Camera.main.transform.position;
        currentFrame = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (playController.wasBallThrown)
        {
            playController.wasBallThrown = false;
            Invoke("CountFallenPins", resetTime);
            Invoke("ResetCamera", resetTime);
            Invoke("ResetPins", resetTime + 1.0f);

        }
    }
    public void CountFallenPins() 
    {
        currentScore = 0;
        foreach (var pin in Pins)
        {
            if (pin.pinfell)
            {
                currentScore += 1;
                totalScore += 1;
            }
        }

        NextFrame();
        UpdateUI();

        Debug.Log("currentScore: " + currentScore);
        Debug.Log("totalScore: " + totalScore);
    }

    

    private void ResetCamera()
    {
        Camera.main.transform.position = initialCamPosition;
    }

    private void ResetPins()
    {
        foreach (var pin in Pins)
        {
            pin.transform.rotation = pin.initialPinRotation;
            pin.transform.position = pin.initialPinPosition;
            pin.GetComponent<Rigidbody>().isKinematic = true;
            pin.pinfell = false;
        }
        foreach (var pin in Pins)
        {
            pin.GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    private void NextFrame()
    {
        if (currentFrame < 2)
        {
            currentFrame += 1;
        }
        else
        {
            currentFrame = 1;
        }
    }

    private void UpdateUI()
    {
        frameTotalScore.text = totalScore.ToString();
        frameNumber.text = currentFrame.ToString();

        if(currentFrame == 1)
        {
            frame1stThrowcore.text = currentScore.ToString();
        }
        else
        {
            frame2ndThrowcore.text = currentScore.ToString();   
        }
    }
}
