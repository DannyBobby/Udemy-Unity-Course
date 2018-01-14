using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed;
    public bool shipYPosUnlocked;

    private float playerXMin = 0.0f;
    private float playerXMax = 0.0f;
    private float playerYMin = 0.0f;
    private float playerYMax = 0.0f; 

    // Use this for initialization
    void Start ()
    {
        DefinePlayerBoundaries();        
    }
	
	// Update is called once per frame
	void Update ()
    {
        MoveShip();       
    }

    void DefinePlayerBoundaries()
    {
        float distPlayerToCam = transform.position.z - Camera.main.transform.position.z;
        Vector3 bottomLeftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distPlayerToCam));
        Vector3 bottomRightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distPlayerToCam));
        Vector3 leftTopmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, distPlayerToCam));
        Vector3 leftBottommost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distPlayerToCam));

        Sprite playerSprite = gameObject.GetComponent<SpriteRenderer>().sprite;
        float playerSpriteWidthWorldUnits = playerSprite.rect.width / playerSprite.pixelsPerUnit;
        float playerSpriteHeightWorldUnits = playerSprite.rect.height / playerSprite.pixelsPerUnit;

        playerXMin = bottomLeftmost.x + (playerSpriteWidthWorldUnits / 2);
        playerXMax = bottomRightmost.x - (playerSpriteWidthWorldUnits / 2);
        playerYMin = leftBottommost.y + (playerSpriteHeightWorldUnits / 2);
        playerYMax = leftTopmost.y - (playerSpriteHeightWorldUnits / 2);               
    }

    void MoveShip()
    {
        // When calculating the change in X or Y position, we use the time between frames 
        // as a coefficient for the calculation. The higher the delay between frames, the  
        // higher the change in position.
        float speedThisFrame = speed * Time.deltaTime;
        float shipXDelta = 0.0f;
        float shipYDelta = 0.0f;        
        float newXPosition = 0.0f;
        float newYPosition = 0.0f;

        if (Input.GetKey(KeyCode.D))
        {
            shipXDelta += speedThisFrame;
        }
        if (Input.GetKey(KeyCode.A))
        {
            shipXDelta -= speedThisFrame;
        }
        
        // restrict the player to the gamespace.        
        newXPosition = Mathf.Clamp((shipXDelta + transform.position.x), playerXMin, playerXMax);

        // Movement along Y-Axis is usually locked unless this
        // conditional evaluates to TRUE.
        if (shipYPosUnlocked)
        {
            if (Input.GetKey(KeyCode.W))
            {
                shipYDelta += speedThisFrame;
            }
            if (Input.GetKey(KeyCode.S))
            {
                shipYDelta -= speedThisFrame;
            }
            // restrict the player to the gamespace.        
            newYPosition = Mathf.Clamp((shipYDelta + transform.position.y), playerYMin, playerYMax);
        }  
        else
        {
            // if the player's Y-Axis is restricted, lock the
            // Y-position at -4.0 world units from the origin.
            newYPosition = -4.0f;
        }

        // set the new position of the player
        gameObject.transform.position = new Vector3(newXPosition, newYPosition);
    }
}
