using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GameManager : MonoBehaviour {

    [SerializeField] private Animator pinSetterAnimator;
    [SerializeField] private PinCounter pinCounter;
    [SerializeField] private Ball ball;
    [SerializeField] private ScoreDisplay scoreDisplay;
    private List<int> rolls;
    private List<int> scoreFrames;

	// Use this for initialization
	void Start ()
    {
        pinSetterAnimator = FindObjectOfType<PinSetter>().GetComponentInParent<Animator>();
        pinCounter = FindObjectOfType<PinCounter>();
        ball = FindObjectOfType<Ball>();
        scoreDisplay = FindObjectOfType<ScoreDisplay>();

        rolls = new List<int>();
    }

    // Update is called once per frame
    void Update ()
    {		
        if(pinSetterAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Idle"))
        {
            pinCounter.UpdatePinDisplay();
            ball.isPlayable = true;
        }
        else
        {
            pinCounter.FreezePinDisplay();
            ball.isPlayable = false;
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

        rolls.Add(pinCounter.GetCountPinsFallen());
        scoreFrames = ScoreMaster.ScoreFrames(rolls);

        try
        {
            scoreDisplay.FillRolls(rolls);
            scoreDisplay.FillFrames(ScoreMaster.ScoreCumulative(rolls));
        }
        catch { Debug.LogWarning("scoreDisplay.FillRollCard failed."); }

        ActionMaster.Action nextAction = ActionMaster.NextAction(rolls);

        switch (nextAction)
        {
            case ActionMaster.Action.Tidy:
                pinSetterAnimator.SetTrigger("tgr_Tidy");
                pinCounter.FinalizePinCount();
                ball.Reset();
                break;
            case ActionMaster.Action.Reset:
                pinSetterAnimator.SetTrigger("tgr_Reset");
                pinCounter.ResetPinCount();
                ball.Reset();
                break;
            case ActionMaster.Action.EndTurn:
                pinSetterAnimator.SetTrigger("tgr_Reset");
                pinCounter.ResetPinCount();
                ball.Reset();
                break;
            case ActionMaster.Action.EndGame:
                throw new UnityException("Don't know how to handle ending game yet.");
        }
    }

}
