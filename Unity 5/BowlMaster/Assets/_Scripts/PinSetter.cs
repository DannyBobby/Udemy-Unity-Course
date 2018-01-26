using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PinSetter : MonoBehaviour {

    [SerializeField] private Text pinCountDisplay;
    [SerializeField] private float secondsAllottedForScoring;

    private Ball ball;
    private int lowestCountStanding = 0;
    private bool ballEnteredBox = false;
    private bool tallyScoreRunning = false;
    private float tallyScoreStartTime = 0f;

	// Use this for initialization
	void Start ()
    {
        lowestCountStanding = FindObjectsOfType<Pin>().Length;
        ball = FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(ballEnteredBox && !tallyScoreRunning)
        {
            tallyScoreStartTime = Time.time;
            tallyScoreRunning = true;
        }        

        if(tallyScoreRunning)
        {
            UpdatePinCount();
            if(Time.time - tallyScoreStartTime >= secondsAllottedForScoring)
            {
                tallyScoreRunning = false;
                ballEnteredBox = false;
                PinsHaveSettled();
            }
        }
    }

    private void UpdatePinCount()
    {
        int currentlyStanding = CountCurrentlyStanding();
        if (currentlyStanding < lowestCountStanding)
        {
            lowestCountStanding = currentlyStanding;
            pinCountDisplay.text = lowestCountStanding.ToString();
        }
    }

    private int CountCurrentlyStanding()
    {
        int currentCount = 0;
        Pin[] pinsInScene = FindObjectsOfType<Pin>();

        foreach(Pin pin in pinsInScene)
        {
            if (pin.IsStanding())
            {
                currentCount++;
            }
        }
        return currentCount;
    }

    private void PinsHaveSettled()
    {
        pinCountDisplay.color = Color.green;
        ball.Reset();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Ball>())
        {
            pinCountDisplay.color = Color.red;
            ballEnteredBox = true;
        }        
    }

    private void OnTriggerExit(Collider other)
    {
        Pin pin = other.GetComponentInParent<Pin>();
        if (pin)
        {
            Destroy(pin);
        }
    }
}
