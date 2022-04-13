using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    public int enemyCount = 10;
    int enemiesSpawned = 0;
    bool isActive = false;
    public Transform player;
    Bounds bounds;
    GameObject[] doors;
    bool spawningRepeatedly = false;
    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player").transform;
        bounds = GetComponent<MeshCollider>().bounds;
        SpawnEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive && enemiesSpawned < enemyCount)
        {
            SpawnEnemies();
        }
        if (!isActive && PlayerInRoom())
        {
            isActive = true;
        }
        if (isActive && !spawningRepeatedly)
        {
            spawningRepeatedly = true;
            SpawnEnemiesRepeating();
        }
    }

    void SpawnEnemies()
    {
        Vector3 enemyPosition;
        // buggy for now, so spawn iin the middle LOL
        float xmid = (bounds.min.x + bounds.max.x) / 2;
        float zmid = (bounds.min.z + bounds.max.z) / 2;
        enemyPosition.x = Random.Range(bounds.min.x, bounds.max.x);
        enemyPosition.y = 1.7f;
        enemyPosition.z = Random.Range(bounds.min.z, bounds.max.z);
        Collider[] colliders = Physics.OverlapSphere(enemyPosition, 0.01f);
        Debug.Log(colliders);
        foreach(Collider col in colliders)
        {
            Debug.Log(col);
        }
        if (colliders.Length == 0)
        {
            GameObject spawnedEnemy = Instantiate(enemyPrefab, enemyPosition, transform.rotation) 
            as GameObject;

            spawnedEnemy.transform.parent = gameObject.transform;
        
            enemiesSpawned++;
        }
        
    }

    void SpawnEnemiesRepeating()
    {
        SpawnEnemies();
        if (enemiesSpawned < enemyCount)
        {
            Invoke("SpawnEnemiesRepeating", Random.Range(0.5f, 2.5f));
        }
    }

    bool PlayerInRoom()
    {
        return (player.position.x >= bounds.min.x && player.position.x <= bounds.max.x && player.position.z >= bounds.min.z && player.position.z <= bounds.max.z);
    }
}
