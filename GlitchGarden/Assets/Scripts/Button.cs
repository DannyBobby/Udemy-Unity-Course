using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

    public GameObject defenderPrefab;
    public static Button currentlySelectedButton;
    
	// Use this for initialization
	void Start () {
        GetComponentInChildren<SpriteRenderer>().color = Color.black;
	}
	
	// Update is called once per frame
	void Update () {
        Color spriteColor = GetComponentInChildren<SpriteRenderer>().color;

        if (currentlySelectedButton == this)
        {
            GetComponentInChildren<SpriteRenderer>().color = Color.white;
        }
        else if (currentlySelectedButton != this && spriteColor == Color.white)
        {
            GetComponentInChildren<SpriteRenderer>().color = Color.black;
        }
    }

    void OnMouseDown()
    {
        currentlySelectedButton = this;
    }
}
