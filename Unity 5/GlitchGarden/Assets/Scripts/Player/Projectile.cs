using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    [SerializeField] private float speed;
    [SerializeField] private int damage; 
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject obj = collider.gameObject;

        if (obj.GetComponent<Attacker>())
        {
            obj.GetComponent<Health>().TakeDamage(damage);
            Destroy(gameObject);
        }      
    }
}
