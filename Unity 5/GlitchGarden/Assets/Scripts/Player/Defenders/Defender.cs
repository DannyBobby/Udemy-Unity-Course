using UnityEngine;
using System.Collections;

public class Defender : MonoBehaviour {

    [SerializeField] private int starCost;

    public int GetStarCost()
    {
        return starCost;
    }
}
