using UnityEngine;
using System.Collections;

public class StarTrophy : MonoBehaviour {

    private GameObject starDisplay;

    void Start()
    {
        starDisplay = GameObject.Find("StarDisplay") as GameObject;
    }

	void AddStars(int numberOfStars)
    {
        starDisplay.GetComponent<StarDisplay>().IncreaseStarCount(numberOfStars);

        //Debug.Log("Add " + numberOfStars.ToString() + " to the bank!");
        //Debug.Log("Current star count: " + starDisplay.GetComponent<StarDisplay>().GetStarCount());
    }
}
