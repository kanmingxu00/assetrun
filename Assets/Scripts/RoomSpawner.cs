using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        SpawnEnemies();
        Debug.Log("in room");
    }

    void SpawnEnemies()
    {
        GameObject spawnedEnemy = Instantiate(enemyPrefab, transform.position, transform.rotation) 
            as GameObject;

        spawnedEnemy.transform.parent = gameObject.transform;
    }
}
