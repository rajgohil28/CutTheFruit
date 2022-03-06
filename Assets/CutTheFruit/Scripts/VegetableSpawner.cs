using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegetableSpawner : MonoBehaviour
{
    public GameObject[] Vegetables;
    public Transform[] SpawnPoints;

    public float MinDelay = 2f;
    public float MaxDelay = 8f;

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
            Instantiate(Vegetables[Random.Range(0, Vegetables.Length)], SpawnPoints[spawnIndex]);
        }
    }
    public void StopSpawning()
    {
        StopCoroutine(SpawnFruits());
    }
}
