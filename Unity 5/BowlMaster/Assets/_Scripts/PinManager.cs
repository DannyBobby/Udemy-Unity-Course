using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PinManager: MonoBehaviour {

    [SerializeField] private Text pinCountDisplay;
    [SerializeField] private float secondsAllottedForScoring;
    [SerializeField] private GameObject pinSetPrefab;

    private Ball ball;
    private int previousCountStanding = 0;
    private int lowestCountStanding = 0;
    private bool tallyScoreRunning = false;
    private float tallyScoreStartTime = 0f;
    private ActionMaster am = new ActionMaster();
    private Animator anim;

    public bool ballEnteredBox = false;

    // Use this for initialization
    void Start ()
    {
        lowestCountStanding = FindObjectsOfType<Pin>().Length;
        previousCountStanding = FindObjectsOfType<Pin>().Length;
        ball = FindObjectOfType<Ball>();
        anim = GetComponent<Animator>();

        if(!pinSetPrefab)
        {
            pinSetPrefab = GameObject.Find("Bowling Pin Rack");
        }
	}
	
	// Update is called once per frame
	void Update ()
    {       
        if(ballEnteredBox && !tallyScoreRunning)
        {
            pinCountDisplay.color = Color.red;
            tallyScoreStartTime = Time.time;
            tallyScoreRunning = true;
        }        

        if(tallyScoreRunning)
        {
            UpdateStandingPinCount();
            if(Time.time - tallyScoreStartTime >= secondsAllottedForScoring)
            {
                int pinFall = previousCountStanding - lowestCountStanding;
                previousCountStanding = lowestCountStanding;

                tallyScoreRunning = false;
                ballEnteredBox = false;
                pinCountDisplay.color = Color.green;
                ball.Reset();
                ActionMaster.Action action = am.Bowl(pinFall);

                switch(action)
                {
                    case ActionMaster.Action.Tidy :
                        anim.SetTrigger("tgr_Tidy");
                        break;
                    case ActionMaster.Action.Reset:
                        anim.SetTrigger("tgr_Reset");
                        break;
                    case ActionMaster.Action.EndTurn:
                        anim.SetTrigger("tgr_Reset");
                        break;
                    case ActionMaster.Action.EndGame:
                        throw new UnityException("Don't know how to handle ending game yet.");                        
                }
            }
        }
    }

    public void RaisePins()
    {
        Pin[] pinsInScene = FindObjectsOfType<Pin>();

        foreach (Pin pin in pinsInScene)
        {
            pin.RaiseIfStanding();
        }
    }

    public void LowerPins()
    {
        Pin[] pinsInScene = FindObjectsOfType<Pin>();

        foreach (Pin pin in pinsInScene)
        {
            pin.Lower();            
        }
    }

    public void RenewPins()
    {
        BowlingPinRack[] racksToBeDeleted = FindObjectsOfType<BowlingPinRack>();
        foreach(BowlingPinRack rack in racksToBeDeleted)
        {
            Destroy(rack.gameObject);
        }
        Instantiate(pinSetPrefab, new Vector3(0f, 0f, 1829f), Quaternion.identity);
        lowestCountStanding = FindObjectsOfType<Pin>().Length;
        previousCountStanding = FindObjectsOfType<Pin>().Length;
        pinCountDisplay.text = lowestCountStanding.ToString();
        pinCountDisplay.color = Color.black;
    }

    private void UpdateStandingPinCount()
    {
        int currentlyStanding = CountCurrentlyStanding();
        if (currentlyStanding < lowestCountStanding)
        {
            lowestCountStanding = currentlyStanding;
            pinCountDisplay.text = lowestCountStanding.ToString();
        }
    }

    private int CountCurrentlyStanding()
    {
        int currentCount = 0;
        Pin[] pinsInScene = FindObjectsOfType<Pin>();

        foreach(Pin pin in pinsInScene)
        {
            if (pin.IsStanding())
            {
                currentCount++;
            }
        }
        return currentCount;
    } 
    
    private int GetCountPinsFallen()
    {
        return lowestCountStanding - CountCurrentlyStanding();
    }
}
