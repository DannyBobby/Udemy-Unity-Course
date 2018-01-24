using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Text))]
public class StarDisplay : MonoBehaviour {

    private Text starDisplayText;
    private int starCount = 100;
    public enum TransactionStatus { SUCCESS, FAILURE };

    void Start()
    {
        starDisplayText = GetComponent<Text>();
        UpdateStarDisplay();
    }

    public int GetStarCount()
    {
        return starCount;
    }

    public TransactionStatus UseStars(int amount)
    {
        if (starCount >= amount)
        {
            starCount -= amount;
            UpdateStarDisplay();
            return TransactionStatus.SUCCESS;
        }
        else
        {
            return TransactionStatus.FAILURE;
        }
    }

    public void IncreaseStarCount(int amount)
    {
        starCount += amount;        
        UpdateStarDisplay();
    }    

    public void UpdateStarDisplay()
    {
        starDisplayText.text = "Stars: " + starCount.ToString();
    }
}
