using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RoomSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    public int repeatingSpawnCount = 5;
    public int initialSpawnCount = 10;
    int enemiesSpawned = 0;
    bool isActive = false;
    public Transform player;
    Bounds bounds;
    GameObject[] doors;
    bool spawningRepeatedly = false;
    public float onMeshThreshold = 3f;
    int totalSpawnCount;
    // Start is called before the first frame update
    void Start()
    {
        totalSpawnCount = repeatingSpawnCount + initialSpawnCount;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (GetComponent<MeshCollider>())
        {
            bounds = GetComponent<MeshCollider>().bounds;
        }
        else if (GetComponent<Collider>())
        {
            bounds = GetComponent<Collider>().bounds;
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive && enemiesSpawned < initialSpawnCount)
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
        // float xmid = (bounds.min.x + bounds.max.x) / 2;
        // float zmid = (bounds.min.z + bounds.max.z) / 2;
        enemyPosition.x = Random.Range(bounds.min.x, bounds.max.x);
        enemyPosition.y = 1.7f;
        enemyPosition.z = Random.Range(bounds.min.z, bounds.max.z);
        Collider[] colliders = Physics.OverlapSphere(enemyPosition + new Vector3(0, 1.0f, 0), 0.9f);
        Debug.Log(colliders);
        foreach(Collider col in colliders)
        {
            Debug.Log(col);
        }
        if (colliders.Length == 0 && OnNavMesh(enemyPosition))
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
        if (enemiesSpawned < totalSpawnCount)
        {
            Invoke("SpawnEnemiesRepeating", Random.Range(0.5f, 2.5f));
        }
    }

    bool OnNavMesh(Vector3 position)
    {
        NavMeshHit hit;
        if (NavMesh.SamplePosition(position, out hit, onMeshThreshold, NavMesh.AllAreas))
        {
            Debug.Log("in it");
            Debug.Log(hit.position);
            Debug.Log(position);
            // Check if the positions are vertically aligned
            if (Mathf.Approximately(position.x, hit.position.x)
                && Mathf.Approximately(position.z, hit.position.z))
            {
            // Lastly, check if object is below navmesh
                return true;
            }
        }
        return false;
    }

    bool PlayerInRoom()
    {
        return (player.position.x >= bounds.min.x && player.position.x <= bounds.max.x && player.position.z >= bounds.min.z && player.position.z <= bounds.max.z);
    }
}
