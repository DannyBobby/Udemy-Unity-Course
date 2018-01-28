using UnityEngine;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour {

    private Text pinCountDisplayText;
    private int previousCountStanding;
    private int latestCountStanding;

    private void Start()
    {
        pinCountDisplayText = FindObjectOfType<PinCountDisplay>().GetComponentInParent<Text>();
        previousCountStanding = 10;
        latestCountStanding = 10;
    }      

    public void UpdatePinDisplay()
    {
        pinCountDisplayText.color = Color.green;
        UpdateCountCurrentlyStanding();
        pinCountDisplayText.text = latestCountStanding.ToString();
    }

    public void UpdateCountCurrentlyStanding()
    {
        int currentCount = 0;
        Pin[] pinsInScene = FindObjectsOfType<Pin>();        

        // Count 'em up!
        foreach (Pin pin in pinsInScene)
        {
            if (pin.IsStanding())
            {
                currentCount++;
            }
        }

        latestCountStanding = currentCount;
    }

    public void FinalizePinCount()
    {
        // Update our counts
        previousCountStanding = latestCountStanding;        
    }
    
    public void FreezePinDisplay()
    {
        pinCountDisplayText.color = Color.red;
    }

    public int GetCountPinsFallen()
    {
        return previousCountStanding - latestCountStanding;
    }    

    public void ResetPinCount()
    {
        previousCountStanding = 10;
        latestCountStanding = 10;
        UpdatePinDisplay();
    }
}
