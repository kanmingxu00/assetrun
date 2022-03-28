using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootProjectile : MonoBehaviour
{
    public float projectileSpeed = 10.0f;
    public GameObject weapon1;
    public GameObject weapon2;
    public GameObject weapon3;
    public GameObject weapon4;
    public GameObject currentWeapon;
    // Start is called before the first frame update

    void Start()
    {
        currentWeapon = weapon1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }

        SwitchWeapon();
    }

    void SwitchWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeapon = weapon1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeapon = weapon2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentWeapon = weapon3;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            currentWeapon = weapon4;
        }
    }

    void Shoot()
    {
        GameObject projectile = Instantiate(currentWeapon, transform.position + transform.forward, transform.rotation);

        var _rb = projectile.GetComponent<Rigidbody>();
        _rb.AddForce(transform.forward * projectileSpeed, ForceMode.VelocityChange);
    }
}
