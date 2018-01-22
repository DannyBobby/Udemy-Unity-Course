using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    [SerializeField] private int health;   

    void Update()
    {
        if (health <= 0)
        {
            Die();
        }
    }   

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        Debug.Log(gameObject.name + " took " + damageAmount.ToString() + " points of damage.");
    }

    void Die()
    {        
        Destroy(gameObject);
    }
}
