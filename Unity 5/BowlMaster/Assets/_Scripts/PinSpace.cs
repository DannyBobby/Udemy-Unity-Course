using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinSpace : MonoBehaviour {

    private void OnTriggerExit(Collider other)
    {
        Pin pin = other.GetComponentInParent<Pin>();
        if (pin)
        {
            Debug.Log("Destroy pin " + pin.name + "!");
            Destroy(pin.gameObject);
        }
    }
}
