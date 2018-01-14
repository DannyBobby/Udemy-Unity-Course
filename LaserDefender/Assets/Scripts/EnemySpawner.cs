using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyPrefab;
    public EnemyFormation formation;
    
    // Use this for initialization
    void Start () {
        foreach(Transform child in transform)
        {
            GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = child; //Makes the instantiated enemy a child of the position transform (the child of the transform of this EnemyFormation object)
            enemy.tag = "Enemy";
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(formation.width, formation.height));
    }

    // Update is called once per frame
    void Update () {
	
	}

    
}
