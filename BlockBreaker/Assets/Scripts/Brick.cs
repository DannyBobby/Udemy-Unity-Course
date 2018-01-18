using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

    public AudioClip crack;
    public Sprite[] hitSprites;
    public GameObject smoke;

    public static int breakableBrickCount = 0;

    private LevelManager levelManager;
    private int timesHit,
                maxHits;
    private bool isBreakableBrick;
    
    

    // Use this for initialization
    void Start () {
        levelManager = FindObjectOfType<LevelManager>();

        isBreakableBrick = (this.tag == "Breakable");
        // Keep track of breakable bricks
        if (isBreakableBrick)
        {
            breakableBrickCount++;
            print("Brick Count: " + breakableBrickCount);
        }

        timesHit = 0;
        maxHits = (hitSprites.Length + 1);
    }    

	void OnCollisionEnter2D(Collision2D collision)
    {
        if (isBreakableBrick)
        {
            HandleHits();
        }
    }

    void HandleHits()
    {
        timesHit++;
        // We use this method in order to keep the audio persisting even after the brick has been destroyed.
        AudioSource.PlayClipAtPoint(crack, transform.position); 
        if (timesHit >= maxHits)
        {            
            breakableBrickCount--;
            levelManager.BrickDestroyed();
            PuffSmoke();
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
    } 

    void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        if(hitSprites[spriteIndex])
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }        
    }
    
    void PuffSmoke()
    {
        GameObject puff = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;
        puff.particleSystem.startColor = this.GetComponent<SpriteRenderer>().color;
    }
}
