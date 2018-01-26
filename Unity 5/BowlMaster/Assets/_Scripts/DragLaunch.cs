using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Ball))]
public class DragLaunch : MonoBehaviour {

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

        Vector3 velocity = new Vector3(speedX, 0f, speedZ);
        Debug.Log("Velocity vector: " + velocity.ToString());

        if (!ball.inPlay)
        {
            ball.Launch(velocity);
        }
    }

    public void MoveStart(float xNudge)
    {
        if (!ball.inPlay)
        {
            Debug.Log("Moving Ball!");
            transform.Translate(new Vector3(xNudge, 0f, 0f));
        }        
    }
}
