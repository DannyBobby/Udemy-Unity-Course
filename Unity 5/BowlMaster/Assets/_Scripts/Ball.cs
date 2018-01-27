using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    [SerializeField] private Vector3 launchVelocity;

    private Rigidbody rigidBody;
    private AudioSource audioSource;
    private Vector3 ballStartPos;

    public bool inPlay = false;

    // Use this for initialization
    void Start ()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.useGravity = false;
        ballStartPos = transform.position;
    }

    public void Launch(Vector3 velocity)
    {
        audioSource = GetComponent<AudioSource>();
        rigidBody.useGravity = true;
        rigidBody.velocity = velocity;
        audioSource.Play();
        inPlay = true;
    }

    public void Reset()
    {
        Debug.Log("Resetting ball");
        inPlay = false;
        rigidBody.useGravity = false;
        rigidBody.velocity = new Vector3(0f, 0f, 0f);
        rigidBody.angularVelocity = new Vector3(0f, 0f, 0f);
        transform.position = ballStartPos;        
    }
}
