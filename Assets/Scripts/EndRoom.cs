using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndRoom : MonoBehaviour
{
    public Transform player;
    Bounds bounds;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        bounds = GetComponent<BoxCollider>().bounds;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("not in");
        if (PlayerInRoom())
        {
            Debug.Log("in");
            CheckCleared();
        }
    }

    void CheckCleared()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            Debug.Log("cleared");
            FindObjectOfType<LevelManager>().LevelBeat();
        }
    }
    bool PlayerInRoom()
    {
        return (player.position.x >= bounds.min.x && player.position.x <= bounds.max.x && player.position.z >= bounds.min.z && player.position.z <= bounds.max.z);
    }
}
