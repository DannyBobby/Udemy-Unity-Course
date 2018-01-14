using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
    public float ballYVelocity;
    public float ballXVelocityCoefficient;

    private Paddle paddle;
    private bool ballLaunched = false;
    private float paddlePreviousXPos;
    private float paddleXPosSpeed;
    private Vector3 paddleToBallVectorOffset;

	// Use this for initialization
	void Start () {
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVectorOffset = this.transform.position - paddle.transform.position;
        paddlePreviousXPos = paddle.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {        
        if (!ballLaunched)
        {
            paddleXPosSpeed = ballXVelocityCoefficient * (paddle.transform.position.x - paddlePreviousXPos);
            paddlePreviousXPos = paddle.transform.position.x;

            this.transform.position = paddle.transform.position + paddleToBallVectorOffset;

            if (Input.GetMouseButtonDown(0))
            {
                this.rigidbody2D.velocity = new Vector2(paddleXPosSpeed, ballYVelocity);
                ballLaunched = true;
            }
        }        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //===============================================================================        
        // ALERT ALERT ALERT ALERT ALERT ALERT ALERT ALERT ALERT ALERT ALERT ALERT ALERT 
        //===============================================================================        
        // We are still getting some "boring loops" when the ball gets near a wall.
        // Maybe there should be a check which adjusts the velocity of the ball in the 
        // event that the "X" position of the ball has not changed recently.         

        Vector2 tweak = new Vector2(Random.Range(0.0f, 0.2f), Random.Range(0.0f, 0.2f));       

        if (ballLaunched)
        {
            this.rigidbody2D.velocity += tweak;
            audio.Play();
        }
    }
}
