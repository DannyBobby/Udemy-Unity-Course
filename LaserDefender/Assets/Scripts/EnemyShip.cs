﻿using UnityEngine;
using System.Collections;

public class EnemyShip : MonoBehaviour
{
    [SerializeField] private float healthPoints;
    [SerializeField] private GameObject weaponSystem;
    [SerializeField] private float rateOfFire;
    [SerializeField] private int scorePoints;
    [SerializeField] private AudioClip laserSFX;
    [SerializeField] private AudioClip explosionSFX;
    
    private float fireTimeElapsed = 0.0f;

    public float GetHealth()
    {
        return healthPoints;
    }   

    void Update()
    {
        fireTimeElapsed += (Time.deltaTime * Random.value);   
        if (fireTimeElapsed >= rateOfFire)
        {
            FireWeapon();
            fireTimeElapsed = 0.0f;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "PlayerProjectile")
        {
            Projectile projectile = collider.gameObject.GetComponent<Projectile>();
            healthPoints -= projectile.GetDamage();
            projectile.Hit();

            if (healthPoints <= 0)
            {
                DeathRattle();
            }
        }
    }

    void FireWeapon()
    {
        GameObject beam = Instantiate(weaponSystem,
                                      transform.position,
                                      Quaternion.identity) as GameObject;

        beam.rigidbody2D.velocity = new Vector3(0,
                                                -weaponSystem.GetComponent<Projectile>().GetSpeed(),
                                                0);

        AudioSource.PlayClipAtPoint(laserSFX, transform.position);
    }

    void DeathRattle()
    {
        FindObjectOfType<ScoreKeeper>().UpdateScore(scorePoints);
        AudioSource.PlayClipAtPoint(explosionSFX, transform.position);
        Destroy(gameObject);
    }
}
