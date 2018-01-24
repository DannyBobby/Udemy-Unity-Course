using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject gun;

    private Animator animator;
    private GameObject myLane;
    private GameObject projectileParent;

    void Start()
    {
        animator = GetComponent<Animator>();
        myLane = GameObject.Find("Lane " + transform.position.y.ToString());
        projectileParent = GameObject.Find("Projectiles");

        if (!projectileParent)
        {
            projectileParent = new GameObject("Projectiles");
        }        
    }

    void Update()
    {
        if (IsAttackerAheadInLane())
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }

    private bool IsAttackerAheadInLane()
    {
        // Since attackers are the only things "childed" under this lane,
        // we can simply ask, "are there any children of this lane?"
        if (myLane.transform.childCount > 0)
        {
            // If there are children of this lane, is the attacker 
            // in front of this defender?
            foreach (Transform attacker in myLane.transform)
            {
                // If the attacker is in front this defender, return true!
                if(attacker.transform.position.x > transform.position.x)
                {
                    return true;
                }                
            }
            return false;
        }
        else
        {
            return false;
        }        
    }

    private void Fire()
    {        
        GameObject newProjectile = Instantiate(projectile) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
        newProjectile.transform.position = gun.transform.position;
    }
}
