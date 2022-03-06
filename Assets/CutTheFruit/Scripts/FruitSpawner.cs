using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public GameObject[] Fruits;
    public Transform[] SpawnPoints;

    public float MinDelay=0.1f;
    public float MaxDelay=1f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFruits());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnFruits()
    {
        while (true)
        {
            float delay = Random.Range(MinDelay, MaxDelay);
            yield return new WaitForSeconds(delay);

            int spawnIndex = Random.Range(0, SpawnPoints.Length);
            Instantiate(Fruits[Random.Range(0, Fruits.Length)], SpawnPoints[spawnIndex]);
        }
    }
    public void StopSpawning()
    {
        StopCoroutine(SpawnFruits());
    }
    
}
