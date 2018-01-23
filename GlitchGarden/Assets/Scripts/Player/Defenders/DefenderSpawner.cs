using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

    [SerializeField] private Camera myCamera;

    private Vector2 spawnPositionWorldUnits;
    private Vector2 mousePositionPixels;
    private GameObject defendersParent;

    void Start()
    {
        defendersParent = GameObject.Find("Defenders");

        if (!defendersParent)
        {
            defendersParent = new GameObject("Defenders");
        }
    }

    void OnMouseDown()
    {
        mousePositionPixels = Input.mousePosition;
        spawnPositionWorldUnits = SnapToGrid(GetWorldUnitCoordinates(mousePositionPixels));

        if (Button.currentlySelectedButton)
        {
            GameObject newSpawn = Instantiate(Button.currentlySelectedButton.defenderPrefab, spawnPositionWorldUnits, Quaternion.identity) as GameObject;            
            newSpawn.transform.parent = defendersParent.transform;
        }
        
    }

    private Vector2 GetWorldUnitCoordinates(Vector2 mousePos)
    {
        return myCamera.ScreenToWorldPoint(new Vector3(mousePositionPixels.x, mousePositionPixels.y, 10f));
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.Round(rawWorldPos.x);
        float newY = Mathf.Round(rawWorldPos.y);

        return new Vector2(newX, newY);
    }
}
