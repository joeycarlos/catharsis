using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth;

    public GameObject deathEffect;
    public GameObject pickup;

    protected int currentHealth;
    protected int level;

    public void Start() {
        level = 1;
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage) {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, maxHealth);
        if (currentHealth <= 0) {
            Instantiate(deathEffect, gameObject.GetComponent<Transform>().position, Quaternion.identity);
            Instantiate(pickup, gameObject.GetComponent<Transform>().position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "BottomBoundary") {
            Destroy(gameObject);
        }
    }
}
