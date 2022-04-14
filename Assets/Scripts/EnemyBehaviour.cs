using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyBehaviour : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 10f;
    public float chaseRange = 30f;
    public float attackRange = 3f;
    int damageAmount = 20;
    public Animator anim;
    public AudioClip enemySFX;
    public AudioClip enemyDeathSFX;
    public GameObject enemyVFX;
    EnemyHealth enemyHealth;
    int health;
    public NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = attackRange;
        enemyHealth = GetComponent<EnemyHealth>();
        health = enemyHealth.currentHealth;
        anim = GetComponent<Animator>();
        anim.SetInteger("animState", 0);
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        if (enemySFX)
        {
            AudioSource.PlayClipAtPoint(enemySFX, transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        health = enemyHealth.currentHealth;

        if (health <=0)
        {
            die();
        }
        
        float step = moveSpeed * Time.deltaTime;

        float playerDistance = Vector3.Distance(transform.position, player.position);
        if (playerDistance < chaseRange && playerDistance > attackRange)
        {
            anim.SetInteger("animState", 2);
            
            FaceTarget(player.position);
            agent.SetDestination(player.position);
            // if (!anim.applyRootMotion)
            // {
            //     Vector3 target = player.position;
            //     target.y = transform.position.y;
            //     transform.position = Vector3.MoveTowards(transform.position, target, step);
            // }
        }
        else if (playerDistance <= attackRange)
        {
            anim.SetInteger("animState", 3);
            FaceTarget(player.position);
        }
        else
        {
            anim.SetInteger("animState", 0);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            //collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damageAmount);
            hitPlayer(collision.gameObject);


        }
    }

    void hitPlayer(GameObject player)
    {
        player.gameObject.GetComponent<PlayerHealth>().TakeDamage(damageAmount);
    }

    void FaceTarget(Vector3 target)
    {
        Vector3 directionToTarget = (target - transform.position).normalized;
        directionToTarget.y = 0;
        Quaternion lookRotation = Quaternion.LookRotation(directionToTarget);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 10 * Time.deltaTime);
    }

    void die()
    {
        LevelManager.score += 1;
        Database.money += 1;
        anim.SetInteger("animState", 4);
        var particles = Instantiate(enemyVFX, transform.position, transform.rotation);
        Destroy(particles, 2);
        if (enemyDeathSFX)
        {
            
            AudioSource.PlayClipAtPoint(enemyDeathSFX, transform.position);
        }
        Destroy(gameObject);
    }
}
