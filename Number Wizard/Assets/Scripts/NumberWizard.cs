using UnityEngine;
using System.Collections;

public class NumberWizard : MonoBehaviour {

    int max, min, guess;

    // Use this for initialization
    void Start ()
    {
        StartGame();
    }

    void StartGame () {
        max = 10;
        min = 1;
        guess = 5;

        print("=========================");
        print("Welcome to Number Wizard");
        print("Pick a number in your head, but don't tell me.");
        print("The highest number you can pick is " + max.ToString() + ". ");
        print("The lowest number you can pick is " + min.ToString() + ". ");

        // because of the truncation of our integer math, we will never reach
        // the maximum number unless we add one to that value now.
        max += 1;
        AskPlayer();        
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //print("up arrow key was pressed");
            min = guess;
            NextGuess();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //print("down arrow key was pressed");
            max = guess;
            NextGuess();            
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            print("I won!");
            StartGame();
        }        
    }

    void NextGuess ()
    {
        guess = (max + min) / 2;
        AskPlayer();
    }

    void AskPlayer()
    {
        print("Is the number higher or lower than " + guess.ToString() + "?");
        print("Up arrow = \"higher\", down arrow = \"lower\", return key = \"equal\"");
    }
}
