using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log("Collectable " + gameObject.name + " trigger enter " + collider.name);
    }
}
