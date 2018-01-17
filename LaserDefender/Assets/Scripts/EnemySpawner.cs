using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnDelay;
    
    // Use this for initialization
    void Start () {
        SpawnSequentially();
    }    

    // Update is called once per frame
    void Update () {
        if (AllMembersDead())
        {
            Debug.Log("Empty Formation");
            SpawnSequentially();
        }
	}

    void SpawnAllAtOnce()
    {
        foreach (Transform child in transform)
        {
            GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = child; //Makes the instantiated enemy a child of the position transform (the child of the transform of this EnemyFormation object)
            enemy.tag = "Enemy";
        }
    }

    void SpawnSequentially()
    {
        Transform nextFreePos = NextFreePosition();
        if(nextFreePos)
        {
            GameObject enemy = Instantiate(enemyPrefab, nextFreePos.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = nextFreePos; //Makes the instantiated enemy a child of the position transform (the child of the transform of this EnemyFormation object)
            enemy.tag = "Enemy";
        }    
        
        if(NextFreePosition())
        {
            Invoke("SpawnSequentially", spawnDelay);
        }
    }
        
    bool AllMembersDead()
    {
        foreach(Transform childPositionGameObject in transform)
        {
            if (childPositionGameObject.childCount > 0)
            {
                return false;
            }
        }
        return true;
    }

    Transform NextFreePosition()
    {
        foreach (Transform childPositionGameObject in transform)
        {
            if (childPositionGameObject.childCount == 0)
            {
                return childPositionGameObject.transform;
            }
        }
        return null;        
    }
}
