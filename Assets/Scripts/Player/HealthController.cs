using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public GameObject Player;

    public Slider HealthPoints;
    public int maxHealth;
    public int currentHealth;

    public HealthController healthBar;

    private void Awake()
    {
        currentHealth = maxHealth;
        healthBar.setHealth(maxHealth);
    }

    public void setHealth(int health) {

        HealthPoints.value = health;
    
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);
    }

}
