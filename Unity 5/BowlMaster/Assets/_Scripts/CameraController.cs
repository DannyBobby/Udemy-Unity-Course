using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private Ball ball;
    private Vector3 headPinPosition;
    private Vector3 cameraBallOffset;

	// Use this for initialization
	void Start () {
        ball = FindObjectOfType<Ball>();
        headPinPosition = GameObject.Find("Bowling Pin 1").transform.position;

        cameraBallOffset = transform.position - ball.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (!BallIsNearHeadPin(100f))
        {
            TrackBall();
        }        
	}

    void TrackBall()
    {
        transform.position = ball.transform.position + cameraBallOffset;
    }
            
    bool BallIsNearHeadPin(float distance)
    {
        return ball.transform.position.z >= headPinPosition.z - distance;
    }
}
