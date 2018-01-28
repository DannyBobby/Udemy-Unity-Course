using UnityEngine;

public class PinSetter: MonoBehaviour {

    [SerializeField] private GameObject pinSetPrefab;

    // Use this for initialization
    void Start ()
    {      
        if (!pinSetPrefab)
        {
            pinSetPrefab = FindObjectOfType<BowlingPinRack>().gameObject;
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
    }    
}
