using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Button : MonoBehaviour {

    public GameObject defenderPrefab;
    public static Button currentlySelectedButton;

    private Text costText;
    
	// Use this for initialization
	void Start () {
        GetComponentInChildren<SpriteRenderer>().color = Color.black;

        if (GetComponentInChildren<Text>())
        {
            GetComponentInChildren<Text>().text = defenderPrefab.GetComponent<Defender>().GetStarCost().ToString(); ;
        }
        else
        {
            Debug.LogWarning(name + " has no Cost GameObject associated with it.");
        }
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
