using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Attacker))]
public class Lizard : MonoBehaviour {

    [SerializeField] private Animator animator;
    [SerializeField] private Attacker attacker;




    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject obj = collider.gameObject;

        if (obj.GetComponent<Defender>())
        {
            //Debug.Log(name + " attacking " + collider.name);
            attacker.SetCurrentTarget(obj);
            animator.SetBool("isAttacking", true);
        }
        else if (obj.GetComponent<Projectile>())
        {
            // TODO: add behavior for projectiles.
            return;
        }
        else
        {
            return;
        }
    }
}
