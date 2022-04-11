using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
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
            PlayerDies();
        }
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        Mathf.Clamp(currentHealth, 0, startingHealth);
        healthSlider.value = currentHealth;
    }

    void PlayerDies()
    {
        Debug.Log("Player Died");
        FindObjectOfType<LevelManager>().LevelLost();
    }
}
