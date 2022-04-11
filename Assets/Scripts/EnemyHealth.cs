using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;

    void Awake()
    {
        healthSlider = GetComponentInChildren<Slider>();
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
        healthSlider.value = currentHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damageAmount;
            healthSlider.value = currentHealth;
            Debug.Log("Took " + damageAmount + " damage");
        }
        if (currentHealth <= 0)
        {
            
        }
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        Mathf.Clamp(currentHealth, 0, startingHealth);
        healthSlider.value = currentHealth;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Projectile"))
        {
            
            TakeDamage(LevelManager.playerProjectileDamage);
            Destroy(collision.gameObject);
        }
    }
}
