using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 10f;
    public float minDistance = 10f;
    public int damageAmount = 20;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetInteger("animState", 0);
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float step = moveSpeed * Time.deltaTime;

        if (Vector3.Distance(transform.position, player.position) > minDistance)
        {
            anim.SetInteger("animState", 1);
            transform.LookAt(player);
            if (!anim.applyRootMotion)
            {
                Vector3 target = player.position;
                target.y = transform.position.y;
                transform.position = Vector3.MoveTowards(transform.position, target, step);
            }
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

    private void OnTriggerEnter(Collider other)
    {
        //if (other.CompareTag("Player"))
        //{

        //     hitPlayer(other.gameObject);


        //}
        if (other.CompareTag("Projectile"))
        {

            die();
        }
    }

    void hitPlayer(GameObject player)
    {
        player.gameObject.GetComponent<PlayerHealth>().TakeDamage(damageAmount);
    }

    void die()
    {
        Destroy(gameObject);
    }
}
