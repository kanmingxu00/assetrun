using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float xMin = -25;
    public float xMax = 25;
    public float yMin = 8;
    public float yMax = 25;
    public float zMin = -25;
    public float zMax = 25;
    public float spawnTime = 3;
    Vector3 spawnerPosition;
    // Start is called before the first frame update
    void Start()
    {
        spawnerPosition = transform.position;
        InvokeRepeating("SpawnEnemies", spawnTime, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnEnemies()
    {
        Vector3 enemyPosition;
        enemyPosition.x = Random.Range(spawnerPosition.x - xMin, spawnerPosition.x + xMax);
        enemyPosition.y = Random.Range(spawnerPosition.y - yMin, spawnerPosition.y + yMax);
        enemyPosition.z = Random.Range(spawnerPosition.z - zMin, spawnerPosition.z + zMax);

        GameObject spawnedEnemy = Instantiate(enemyPrefab, enemyPosition, transform.rotation) 
            as GameObject;

        spawnedEnemy.transform.parent = gameObject.transform;
    }
}
