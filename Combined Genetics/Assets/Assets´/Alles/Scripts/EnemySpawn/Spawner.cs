using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyToSpawn;

    public int spawnAmount = 5;
    private int spawnedAmount;

    [Header("Radius")]
    [SerializeField] private float minRange = -5f;
    [SerializeField] private float maxRange = 5f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) Spawn();
    }

    void SpawnFuncion()
    {
        spawnedAmount++;

        Vector3 spawnPosition = new Vector3(Random.Range(minRange, maxRange + 1) ,0 , Random.Range(minRange, maxRange + 1));
        Instantiate(enemyToSpawn, spawnPosition, Quaternion.identity);
    }

    //the spawn function that you call;
    public void Spawn()
    {
        if(spawnedAmount < spawnAmount) InvokeRepeating("Spawn", 0f, 0f);
    }

    //clarification on the radius
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;

        Gizmos.DrawWireSphere(transform.position, maxRange);
    }
}
