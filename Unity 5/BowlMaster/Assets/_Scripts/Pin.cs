using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

    [SerializeField] private float standingThreshold;
	
	public bool IsStanding()
    {
        Vector3 rotationInEuler = transform.rotation.eulerAngles;

        float tiltInX = Mathf.Abs(Mathf.DeltaAngle(rotationInEuler.x, 0f));
        float tiltInZ = Mathf.Abs(Mathf.DeltaAngle(rotationInEuler.z, 0f));

        return (tiltInX < standingThreshold && tiltInZ < standingThreshold);
    }    
}
