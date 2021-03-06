using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public string gunName;
    public int damage = 10;
    public float range = 100f;
    public float fireRate = 15f;
    public float impactForce = 30f;

    public int maxAmmo = 10;
    private int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public AudioClip gunShotSFX;
    public Text ammoUI;
    public static bool isShopping = false;
    public Animator animator;

    private float nextTimeToFire = 0f;

    void Start()
    {
        if (PlayerPrefs.HasKey(gunName + "_damage"))
        {
            damage = PlayerPrefs.GetInt(gunName + "_damage");
        }

        if (PlayerPrefs.HasKey(gunName + "_rate"))
        {
            fireRate = PlayerPrefs.GetFloat(gunName + "_rate");
        }

        if (PlayerPrefs.HasKey(gunName + "_ammo"))
        {
            maxAmmo = PlayerPrefs.GetInt(gunName + "_ammo");
        }

        if (PlayerPrefs.HasKey(gunName + "_reload"))
        {
            reloadTime = PlayerPrefs.GetFloat(gunName + "_reload");
        }

        currentAmmo = maxAmmo;
        UpdateUI();
    }

    private void OnEnable()
    {
        isReloading = false;
        animator.SetBool("Reloading", false);
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0 && !isShopping)
        {
            if (isReloading)
            {
                return;
            }

            if (currentAmmo <= 0 || Input.GetKeyDown(KeyCode.R))
            {
                StartCoroutine(Reload());
                return;
            }

            if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1f / fireRate;
                Shoot();
            }

            if (LevelManager.isGameOver && LevelManager.isWon)
            {
                PlayerPrefs.SetInt(gunName + "_damage", damage);
                PlayerPrefs.SetFloat(gunName + "_rate", fireRate);
                PlayerPrefs.SetFloat(gunName + "_reload", reloadTime);
                PlayerPrefs.SetInt(gunName + "_ammo", maxAmmo);
                PlayerPrefs.Save();
            }

            UpdateUI();
        }
    }

    void UpdateUI()
    {
        ammoUI.text = currentAmmo.ToString() + " / " + maxAmmo.ToString();
    }

    IEnumerator Reload()
    {
        isReloading = true;
        animator.SetBool("Reloading", true);

        yield return new WaitForSeconds(reloadTime - .25f);
        currentAmmo = maxAmmo;
        animator.SetBool("Reloading", false);
        yield return new WaitForSeconds(.25f);
        isReloading = false;
    }

    void Shoot()
    {
        muzzleFlash.Play();
        AudioSource.PlayClipAtPoint(gunShotSFX, transform.position);
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            //GameObject impactObject = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            //Destroy(impactObject, 2f);
        }
        currentAmmo--;

    }
}
