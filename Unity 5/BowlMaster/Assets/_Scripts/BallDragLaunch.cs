﻿using UnityEngine;

[RequireComponent (typeof(Ball))]
public class BallDragLaunch : MonoBehaviour {

    [SerializeField] private bool isMobileBuild = false;
    private float mobileSpeedScale = 0.5f;

    private Ball ball;
    private Vector3 beginPos;
    private float beginTime;
    private Vector3 endPos;
    private float endTime;


	void Start () {
        ball = GetComponent<Ball>();	
	}

    public void DragStart()
    {        
        beginPos = Input.mousePosition;
        beginTime = Time.time;
    }

    public void DragEnd()
    {
        endPos = Input.mousePosition;
        endTime = Time.time;
                
        float durationOfDrag = endTime - beginTime;

        float speedX = ((endPos.x - beginPos.x) / durationOfDrag);
        float speedZ = ((endPos.y - beginPos.y) / durationOfDrag);

        if (isMobileBuild)
        {
            speedX *= mobileSpeedScale;
            speedZ *= mobileSpeedScale;
        }

        Vector3 velocity = new Vector3(speedX, 0f, speedZ);
        //Debug.Log("Velocity vector: " + velocity.ToString());

        if (!ball.inPlay && ball.isPlayable)
        {
            ball.Launch(velocity);
        }
    }

    public void MoveStart(float xNudge)
    {
        if (!ball.inPlay && ball.isPlayable)
        {
            float ballWidth = ball.transform.localScale.y;
            float laneBoxWidth = FindObjectOfType<LaneBox>().GetComponentInParent<Transform>().localScale.x;
            float xMin = -(laneBoxWidth/2 - ballWidth/2);
            float xMax = (laneBoxWidth/2 - ballWidth/2);

            ball.transform.position = new Vector3(Mathf.Clamp(ball.transform.position.x + xNudge, xMin, xMax), 
                                                  ball.transform.position.y, 
                                                  ball.transform.position.z);
        }        
    }
}
