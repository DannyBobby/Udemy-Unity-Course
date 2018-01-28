using UnityEngine;

public class LaneBox : MonoBehaviour {

    [SerializeField] private GameManager gm;

    // Use this for initialization
    void Start()
    {
        if (!gm)
        {
            gm = FindObjectOfType<GameManager>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Ball ball = other.GetComponent<Ball>();

        if (ball)
        {
            gm.EvaluateGameState();
        }
    }
}
