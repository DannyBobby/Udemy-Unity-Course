using UnityEngine;
using System.Collections;

public class EnemyFormation : MonoBehaviour {

    public float width = 10f;
    public float height = 5f;
    public float horizSpeed;
    public bool hasVerticalMovement;
    public float vertSpeed;
    public int vertFrames;

    private float formationXMin = 0.0f;
    private float formationXMax = 0.0f;
    private float formationYMin = 0.0f;
    private float formationYMax = 0.0f;
    private bool formationDirectionLeft = true;
    private bool changedDirection = false;
    private int vertStep = 0;
    

    void Start () {
        // Flip a coin to see in which direction the formation moves horizontally.
        if ((Random.value - 0.5f) > 0) { formationDirectionLeft = true; }
        else { formationDirectionLeft = false; }

        // If this formation is not supposed to move vertically, 
        // zero out those values to prevent such movement.
        if (!hasVerticalMovement)
        {
            vertSpeed = 0.0f;
            vertFrames = 0;
        }

        DefineFormationBoundaries();
    }
	
	// Update is called once per frame
	void Update () {
        MoveFormation();
	}

    void DefineFormationBoundaries()
    {
        float distformationToCam = transform.position.z - Camera.main.transform.position.z;
        Vector3 bottomLeftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distformationToCam));
        Vector3 bottomRightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distformationToCam));
        Vector3 leftTopmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, distformationToCam));
        Vector3 leftBottommost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distformationToCam));

        formationXMin = bottomLeftmost.x + (width / 2.0f);
        formationXMax = bottomRightmost.x - (width / 2.0f);
        formationYMin = leftBottommost.y + (height / 2.0f);
        formationYMax = leftTopmost.y - (height / 2.0f);
    }

    // This method is designed so that the formation may only move
    // EITHER horizontally OR vertically, but NOT diagonally.
    void MoveFormation()
    {
        // If we've changed direction horizontally, then 
        // it's time to move the formation vertically.
        // However, we don't move vertically all-at-once in
        // one frame. Spread it out over a set of frames to 
        // make the movement smooth and not jerky-looking.
        if (changedDirection && (vertStep < vertFrames))
        {
            float newYPosition = GetNewYPosition(vertSpeed/vertFrames);
            gameObject.transform.position = new Vector3(transform.position.x, newYPosition);
            vertStep++;
        }
        // If we've finished moving vertically according to the 
        // vertFrames threshold value, reset these helper 
        // variables.
        else if (changedDirection && (vertStep >= vertFrames))
        {
            changedDirection = false;
            vertStep = 0;
        }

        // If we haven't just changed direction horizontally and we 
        // aren't executing a vertical movement, move the formation
        // horizontally.
        if (!changedDirection)
        {
            float newXPosition = GetNewXPosition(horizSpeed);
            // set the new position of the formation
            gameObject.transform.position = new Vector3(newXPosition, transform.position.y);
        }
    }

    float GetNewXPosition(float speed)
    {
        // When calculating the change in X position, we use the time between frames as
        // a coefficient for the calculation. The higher the delay between frames, the  
        // higher the change in position.
        float speedThisFrame = speed * Time.deltaTime;

        // If we've hit the edge of the screen, change direction!
        if (transform.position.x <= formationXMin || transform.position.x >= formationXMax)
        { formationDirectionLeft = !formationDirectionLeft; changedDirection = true; }
                
        if (formationDirectionLeft) // If we're moving to the left, decrease the value for the X-Axis
        { return Mathf.Clamp((transform.position.x - speedThisFrame), formationXMin, formationXMax); }
        else // If we're moving to the right, increase the value for the X-Axis
        { return Mathf.Clamp((transform.position.x + speedThisFrame), formationXMin, formationXMax); }
    }

    float GetNewYPosition(float vertSpeed)
    {
        return Mathf.Clamp((transform.position.y - vertSpeed), formationYMin, formationYMax);
    }
}
