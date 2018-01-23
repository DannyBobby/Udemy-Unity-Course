using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

    [SerializeField]
    private GameObject projectile,
                       gun,
                       projectileParent;

    void Start()
    {
        projectileParent = GameObject.Find("Projectiles");
    }

    private void Fire()
    {        
        GameObject newProjectile = Instantiate(projectile) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
        newProjectile.transform.position = gun.transform.position;
    }
}
