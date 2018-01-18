using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FinalScoreDisplay : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Text finalScore = GetComponent<Text>();
        finalScore.text = ScoreKeeper.score.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
