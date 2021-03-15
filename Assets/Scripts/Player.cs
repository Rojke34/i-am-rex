using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public int health = 100;

    public int currentHealth;

    public GameObject deathEffect;

    public HealthBar healthBar;

    public GameObject hbObject;

    void Start() {
        currentHealth = health;

        healthBar.SetMaxHealth(health);
    }

    public void PlayerTakeDamage(int damage) {
        health -= damage;

        healthBar.SetHealth(health);

        FindObjectOfType<AudioManager>().Play("Aaaaaaaaa");

        if (health <= 0) {
            Die();
        }
    }

    void Die() {
        hbObject.SetActive(false);

        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        gameObject.SetActive(false);

        FindObjectOfType<LevelLoader>().LoadNextScene();
    }
}
