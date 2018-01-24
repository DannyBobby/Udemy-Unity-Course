using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Attacker))]
public class Fox : MonoBehaviour {

    [SerializeField] private Animator animator;
    [SerializeField] private Attacker attacker;
    



    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject obj = collider.gameObject;

        if (obj.GetComponent<Defender>())
        {
            if(obj.GetComponent<Gravestone>())
            {
                //Debug.Log(name + " jumping over " + collider.name);
                animator.SetTrigger("triggerJump");            
            }
            else 
            {
                //Debug.Log(name + " attacking " + collider.name);
                attacker.SetCurrentTarget(obj);
                animator.SetBool("isAttacking", true);            
            }            
        }
        else if (obj.GetComponent<Projectile>())
        {
            // TODO: add behavior for projectiles.
            return;
        }        
    }    
}
