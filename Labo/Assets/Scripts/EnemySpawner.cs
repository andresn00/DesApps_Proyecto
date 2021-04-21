using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //Config
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float enemyYOffset = 0.96f;
    [SerializeField] int numberOfEnemies = 20;
    [SerializeField] float timeToSpawnEachEnemy = 5;
    float nextSpawn = 0;
    int enemiesSpawned = 0;

    [SerializeField] float spawnPerimeter = 5f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        if (enemiesSpawned >= numberOfEnemies)
        {
            enemiesSpawned = 0;
            timeToSpawnEachEnemy -= 0.3f;
            if (timeToSpawnEachEnemy <= 2)
            {
                timeToSpawnEachEnemy = 2f;
            }
            nextSpawn += timeToSpawnEachEnemy;
            
        }
        if (Time.time >= nextSpawn)
        {
            Vector3 enemyPos = Random.insideUnitSphere.normalized * spawnPerimeter;
            enemyPos.y = enemyYOffset;
            Instantiate(enemyPrefab, enemyPos, Quaternion.identity);
            enemiesSpawned++;
            nextSpawn = Time.time + timeToSpawnEachEnemy;
        }
    }
}
