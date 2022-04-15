using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int maxHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("startingHealth"))
        {
            startingHealth = PlayerPrefs.GetInt("startingHealth");
        }
        currentHealth = startingHealth;
        healthSlider.value = currentHealth;
    }

    private void Update()
    {
        if (LevelManager.isGameOver && LevelManager.isWon)
        {
            PlayerPrefs.SetInt("startingHealth", currentHealth);
            PlayerPrefs.Save();
        }
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
        Mathf.Clamp(currentHealth, 0, maxHealth);
        healthSlider.value = currentHealth;
    }

    void PlayerDies()
    {
        Debug.Log("Player Died");
        FindObjectOfType<LevelManager>().LevelLost();
    }
}
