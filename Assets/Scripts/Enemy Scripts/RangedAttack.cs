using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{

    public GameObject projectile;
    public GameObject projectileSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Attack()
    {
        Debug.Log("attack");
        if (projectile)
        {
            Instantiate(projectile, projectileSpawn.transform.position, projectileSpawn.transform.rotation);
        }
    }
}
