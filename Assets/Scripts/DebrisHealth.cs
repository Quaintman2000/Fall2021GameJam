using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DebrisHealth : MonoBehaviour
{
    // Stores what type of debris this object is.
    public enum DebrisType { Paper, Plastic, Food, Unknown};
    public DebrisType debrisType = DebrisType.Unknown;

    // Custom Unity events.
    public UnityEvent OnDamaged;
    public UnityEvent OnDeath;

    // Stores how much damage certain types of damage would do.
    public float laserDamage;
    public float rocketDamage;
    public float fireDamage;

    // Stores the health bar stuff.
    public HealthBar healthBar;
    public float health;
    public float maxHealth;

    // Stores how many point's it will give on death.
    [Tooltip("How many points the debris will give on Death.")]
    public int points;

    // Start is called before the first frame update
    void Start()
    {
        // On start, set the health = to the max health and make sure the health bar matches.
        health = maxHealth;
        healthBar.health = health;
        healthBar.maxHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        // Make sure the health bar matches our health
        healthBar.health = health;
        healthBar.maxHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        // Make sure the damage > 0. If not, set it = 0.
        damage = Mathf.Clamp(damage, 0, Mathf.Infinity);

        health -= damage;
        OnDamaged.Invoke();

        if(health <= 0)
        {
            GameManager.instance.debrisList.Remove(this.gameObject);
            GameManager.instance.points += points;
            OnDeath.Invoke();
        }
    }
}
