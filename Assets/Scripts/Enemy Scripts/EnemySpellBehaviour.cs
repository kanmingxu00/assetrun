using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpellBehaviour : MonoBehaviour
{
    PlayerHealth playerHealth;
    public int spellDamage = 5;
    GameObject player;

    void Start()
    {

        player = GameObject.FindWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        //spellDamage = transform.parent.gameObject.GetComponent<EnemyBehaviour>().damageAmount;
        transform.LookAt(player.transform);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealth.TakeDamage(spellDamage);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Projectile"))
        {
            // Do nothing
        }
        else 
        {
            Destroy(gameObject);
        }
        
    }
}
