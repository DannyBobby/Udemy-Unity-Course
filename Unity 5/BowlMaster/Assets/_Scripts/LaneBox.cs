using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneBox : MonoBehaviour {

    [SerializeField] private PinManager pinManager;

    // Use this for initialization
    void Start()
    {
        if (!pinManager)
        {
            pinManager = FindObjectOfType<PinManager>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Ball>())
        {
            pinManager.ballEnteredBox = true;
        }
    }
}
