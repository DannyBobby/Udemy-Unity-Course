using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

    public bool autoPlayTest;

    private int screenWidthWorldUnits = 16;
    private Ball ball;    
    
	// Use this for initialization
	void Start () {
        if(autoPlayTest)
        {
            ball = FindObjectOfType<Ball>();
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (!autoPlayTest)
        {
            MoveWithMouse();
        }
        else
        {
            MoveAutomatically();
        }
	}

    void MoveWithMouse()
    {
        // Get the relative mouse "X" position in game world units
        float mouseXPosInBlocks = (Input.mousePosition.x / Screen.width) * screenWidthWorldUnits;

        // Constrain the mouseXPosInBlocks to the game-space
        mouseXPosInBlocks = Mathf.Clamp(mouseXPosInBlocks,
                                        0.5f,
                                        15.5f);

        // Build a vector for the new position of the paddle.
        Vector3 paddlePos = new Vector3(mouseXPosInBlocks,
                                        this.transform.position.y,
                                        0.0f);

        this.transform.position = paddlePos;
    }

    void MoveAutomatically()
    {
        // Get the relative mouse "X" position in game world units
        float ballXPosInBlocks = ball.transform.position.x;

        // Constrain the mouseXPosInBlocks to the game-space
        ballXPosInBlocks = Mathf.Clamp(ballXPosInBlocks,
                                        0.5f,
                                        15.5f);

        // Build a vector for the new position of the paddle.
        Vector3 paddlePos = new Vector3(ballXPosInBlocks,
                                        this.transform.position.y,
                                        0.0f);

        this.transform.position = paddlePos;
    }
}
