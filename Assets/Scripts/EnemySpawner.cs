using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float horizontalSpawnAreaMagnitude;

    public float minSpawnRate;
    public float maxSpawnRate;
    public Transform spawnObject;
    private float timeSinceSpawn;

    // Start is called before the first frame update
    void Start()
    {
        timeSinceSpawn = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceSpawn -= Time.deltaTime;

        if (timeSinceSpawn <= 0) {
            // GameObject enemy = Instantiate(spawnObject) as GameObject;
            Vector3 spawnPosition = new Vector3(Random.Range(-horizontalSpawnAreaMagnitude, horizontalSpawnAreaMagnitude), transform.position.y, 0);
            Transform enemy = Instantiate(spawnObject, spawnPosition, Quaternion.identity) as Transform;
            timeSinceSpawn = Random.Range(minSpawnRate, maxSpawnRate);
        }
    }
}
