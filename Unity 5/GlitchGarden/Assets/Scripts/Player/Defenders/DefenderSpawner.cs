using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

    [SerializeField] private Camera myCamera;    

    private GameObject defendersParent;
    private StarDisplay starDisplay;

    void Start()
    {       
        defendersParent = GameObject.Find("Defenders");
        starDisplay = FindObjectOfType<StarDisplay>();

        if (!defendersParent)
        {
            defendersParent = new GameObject("Defenders");
        }
    }

    void OnMouseDown()
    {
        Vector2 mousePositionPixels = Input.mousePosition;        

        if (Button.currentlySelectedButton)
        {
            // Get the defender prefab associated with this button and the cost of the defender
            GameObject defenderPrefab = Button.currentlySelectedButton.defenderPrefab;
            int starCost = defenderPrefab.GetComponent<Defender>().GetStarCost();
            
            // Try to buy the defender. If successful, spawn the defender.
            if (starDisplay.UseStars(starCost) == StarDisplay.TransactionStatus.SUCCESS)
            {
                SpawnDefender(defenderPrefab, mousePositionPixels);           
            }
            else
            {
                Debug.Log("Insufficient stars to spawn");
            }
        }        
    }

    void SpawnDefender(GameObject defenderPrefab, Vector3 mousePosition)        
    {
        Vector2 spawnPositionWorldUnits = SnapToGrid(GetWorldUnitCoordinates(mousePosition));

        GameObject newSpawn = Instantiate(defenderPrefab, spawnPositionWorldUnits, Quaternion.identity) as GameObject;
        newSpawn.transform.parent = defendersParent.transform;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.Round(rawWorldPos.x);
        float newY = Mathf.Round(rawWorldPos.y);

        return new Vector2(newX, newY);
    }

    private Vector2 GetWorldUnitCoordinates(Vector2 mousePos)
    {
        return myCamera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10f));
    }    
}
