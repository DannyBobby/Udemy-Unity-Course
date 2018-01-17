using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    [SerializeField] private float damage;
    [SerializeField] private float speed;

    public float GetDamage()
    {
        return damage;
    }

    public float GetSpeed()
    {
        return speed;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }
}
