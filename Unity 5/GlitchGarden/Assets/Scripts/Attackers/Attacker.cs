using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour {

    [Tooltip ("Average number of seconds between appearances")]
    public float seenEverySeconds;    

    [SerializeField, Range(0f, 1.5f)] private float currentSpeed;
    [SerializeField] private int attackDamage;
    [SerializeField] private Animator animator;

    private GameObject currentTarget;




    public void SetSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void SetCurrentTarget(GameObject obj)
    {
        currentTarget = obj;
    }




    // Update is called once per frame
    void Update ()
    {
        if (!currentTarget)
        {
            animator.SetBool("isAttacking", false);
        }

        if(!animator.GetCurrentAnimatorStateInfo(0).IsTag("Attacking"))
        {
            transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
        }        
    }

    void StrikeCurrentTarget()
    {
        if (currentTarget)
        {
            Health targetHealth = currentTarget.GetComponent<Health>();

            if (targetHealth)
            {
                targetHealth.TakeDamage(attackDamage);
                //Debug.Log(name + " dealt " + attackDamage.ToString() + " to " + currentTarget.name);
            }
        }        
    }    
 }
