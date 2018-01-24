using UnityEngine;
using System.Collections;

public class AttackerSpawner : MonoBehaviour {

    [SerializeField] private GameObject[] attackerPrefabs;
    [SerializeField] private GameObject[] spawnLocations;

    private float[] instantiationIntervals;
    private float[] lastInstantiationTime;

    // Use this for initialization
    void Start()
    {
        lastInstantiationTime = new float[attackerPrefabs.Length];
        instantiationIntervals = new float[attackerPrefabs.Length];

        for (int i = 0; i < attackerPrefabs.Length; i++)
        {
            lastInstantiationTime[i] = 0f;
            instantiationIntervals[i] = attackerPrefabs[i].GetComponent<Attacker>().seenEverySeconds;
        }        
    }

    // Update is called once per frame
    void Update () {
        for (int i = 0; i < attackerPrefabs.Length; i++)
        {
            if (Time.realtimeSinceStartup > lastInstantiationTime[i] + instantiationIntervals[i])
            {
                SpawnAttacker(i);
            }
        }
    }

    void SpawnAttacker(int attackerPrefabArrayIndex)
    {
        int randomSpawnLocation = Random.Range(0, spawnLocations.Length);

        GameObject newSpawn = Instantiate(attackerPrefabs[attackerPrefabArrayIndex], 
                                          spawnLocations[randomSpawnLocation].transform.position, 
                                          Quaternion.identity) as GameObject;

        newSpawn.transform.parent = spawnLocations[randomSpawnLocation].transform;

        lastInstantiationTime[attackerPrefabArrayIndex] = Time.realtimeSinceStartup;
    }
}
