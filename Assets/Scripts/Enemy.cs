using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth;
    public float attacksPerSecond;
    public float moveSpeed;

    public GameObject projectile;
    public GameObject deathEffect;
    public GameObject pickup;

    private int currentHealth;

    private float attackTimeInterval;
    private float timeSinceAttack;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        timeSinceAttack = 0;
        attackTimeInterval = 1.0f / attacksPerSecond;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        timeSinceAttack += Time.deltaTime;
        if (timeSinceAttack > attackTimeInterval) {
            Attack();
            timeSinceAttack = 0;
        }
    }

    void Move() {
        Vector3 moveVector = new Vector3(0, -moveSpeed, 0) * Time.deltaTime;
        this.transform.position += moveVector;
    }

    void Attack() {
        Instantiate(projectile, gameObject.GetComponent<Transform>().position, Quaternion.identity);
    }

    public void TakeDamage(int damage) {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, maxHealth);
        if (currentHealth <= 0) {
            Instantiate(deathEffect, gameObject.GetComponent<Transform>().position, Quaternion.identity);
            Instantiate(pickup, gameObject.GetComponent<Transform>().position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    /*
    private void OnBecameInvisible() {
        Destroy(gameObject);
    }
    */

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "BottomBoundary") {
            Destroy(gameObject);
        }
    }
}
