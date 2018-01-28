using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GameManager : MonoBehaviour {

    [SerializeField] Animator pinSetterAnimator;
    [SerializeField] PinCounter pinCounter;
    [SerializeField] Ball ball;

    private List<int> pinFalls;
    private List<int> scoreFrames;

    private bool gameStateFrozen = false;

	// Use this for initialization
	void Start ()
    {
        pinSetterAnimator = FindObjectOfType<PinSetter>().GetComponentInParent<Animator>();
        pinCounter = FindObjectOfType<PinCounter>();
        ball = FindObjectOfType<Ball>();

        pinFalls = new List<int>();


        /* DEBUGGING SCORE MASTER!!!*/
        //string frameScore = "Frame Score: ";
        //string cumuScore = "Cumulative Score ";

        //int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 2, 3 };
        //foreach (int i in ScoreMaster.ScoreFrames(rolls.ToList()))
        //{
        //    frameScore += i.ToString() + ", ";
        //}
        //foreach (int i in ScoreMaster.ScoreCumulative(rolls.ToList()))
        //{
        //    cumuScore += i.ToString() + ", ";
        //}
        //Debug.Log(frameScore);
        //Debug.Log(cumuScore);

    }

    // Update is called once per frame
    void Update ()
    {		
        if(pinSetterAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Idle"))
        {
            pinCounter.UpdatePinDisplay();
            ball.isPlayable = false;
        }
        else
        {
            pinCounter.FreezePinDisplay();
            ball.isPlayable = true;
        }        
    }      
 
    public void EvaluateGameState()
    {
        IEnumerator coroutine = UpdateGameState();
        StartCoroutine(coroutine);        
    }

    IEnumerator UpdateGameState()
    {
        yield return new WaitForSeconds(3.0f);
        int fallenPins = pinCounter.GetCountPinsFallen();
        pinFalls.Add(fallenPins);

        scoreFrames = ScoreMaster.ScoreFrames(pinFalls);
        ActionMaster.Action nextAction = ActionMaster.NextAction(pinFalls);

        Debug.Log("ActionMaster says: " + nextAction.ToString());
        switch (nextAction)
        {
            case ActionMaster.Action.Tidy:
                Debug.Log("Triggering Tidy!");
                pinSetterAnimator.SetTrigger("tgr_Tidy");
                pinCounter.FinalizePinCount();
                ball.Reset();
                break;
            case ActionMaster.Action.Reset:
                Debug.Log("Triggering Reset!");
                pinSetterAnimator.SetTrigger("tgr_Reset");
                pinCounter.ResetPinCount();
                ball.Reset();
                break;
            case ActionMaster.Action.EndTurn:
                Debug.Log("Triggering Reset!");
                pinSetterAnimator.SetTrigger("tgr_Reset");
                pinCounter.ResetPinCount();
                ball.Reset();
                break;
            case ActionMaster.Action.EndGame:
                throw new UnityException("Don't know how to handle ending game yet.");
        }
    }

}
