using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    [SerializeField] private float speed;
    [SerializeField] private float damage;

    public float GetDamage()
    {
        return damage;
    }   
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log("Projectile " + gameObject.name + " trigger enter " + collider.name);
    }        
}
