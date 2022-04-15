using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public int meleeDamage = 10;
    float meleeRange;
    GameObject player;
    PlayerHealth playerHealth;
    void Start()
    {
        meleeRange = GetComponent<EnemyBehaviour>().attackRange;
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Attack()
    {
        Debug.Log("attacking");
        RaycastHit hit;
        if (Physics.Raycast(transform.position + new Vector3(0, 1f, 0), transform.forward, out hit, meleeRange + 1f))
        {
            if (hit.collider.CompareTag("Player"))
            {
                playerHealth.TakeDamage(meleeDamage);
            }
            
        }
    }

}
