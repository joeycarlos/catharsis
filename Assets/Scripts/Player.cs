using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth;
    public float attacksPerSecond;

    public GameObject projectile;
    public GameObject catharsis;
    public GameObject pickupEffect;

    private int currentHealth;
    private Vector3 startHoldMousePosition;
    private Vector3 startHoldPlayerPosition;

    private float attackTimeInterval;
    private float timeSinceAttack;

    private int experienceValue;

    void Start() {
        currentHealth = maxHealth;
        GameplayUI.Instance.UpdateHealthUI(currentHealth);
        timeSinceAttack = 0;
        attackTimeInterval = 1.0f / attacksPerSecond;
        experienceValue = 0;
    }

    // Update is called once per frame
    void Update() {
        ReadMovementInput();
        ReadCatharsisInput();

        timeSinceAttack += Time.deltaTime;
        if (timeSinceAttack > attackTimeInterval) {
            Attack();
            timeSinceAttack = 0;
        }
    }

    Vector3 ReadMovementInput() {
        Vector3 temp = new Vector3(0, 0, 0);

        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            Vector3 mousePos = Input.mousePosition;
            startHoldMousePosition = Camera.main.ScreenToWorldPoint(mousePos);
            startHoldMousePosition.z = 0;
            startHoldPlayerPosition = this.transform.position;

        } else if (Input.GetKey(KeyCode.Mouse0)) {
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            mousePos.z = 0;
            Vector3 offsetVector = mousePos - startHoldMousePosition;
            this.transform.position = startHoldPlayerPosition + offsetVector;

        }

        return Vector3.zero;
    }

    void ReadCatharsisInput() {
        if (Input.GetKeyDown(KeyCode.F)) {
            Instantiate(catharsis, new Vector3(0, -11.0f , 0), Quaternion.identity);
        }
    }

    void Attack() {
        Instantiate(projectile, gameObject.GetComponent<Transform>().position, Quaternion.identity);
    }

    public void TakeDamage(int damage) {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, maxHealth);
        if (currentHealth <= 0) {
            // Game Over
        }
        GameplayUI.Instance.UpdateHealthUI(currentHealth);
    }

    public void GainExperience(int experienceGain) {
        experienceValue += experienceGain;
        GameplayUI.Instance.UpdateExpUI(experienceValue);
        Instantiate(pickupEffect, gameObject.GetComponent<Transform>().position, Quaternion.identity, this.transform);
    }
}
