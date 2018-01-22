using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour {

    [Range(0f, 1.5f)] [SerializeField]
    private float currentSpeed;

	// Use this for initialization
	void Start ()
    {
        Rigidbody2D myRigidbody = gameObject.AddComponent<Rigidbody2D>();
        myRigidbody.isKinematic = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Attacker " + gameObject.name + " trigger enter " + collider.name);
    }

    public void SetSpeed(float speed)
    {
        currentSpeed = speed;
    }

    void StrikeCurrentTarget(float damage)
    {
        Debug.Log(name + " dealt " + damage.ToString() + " to target!");
    }
 }
