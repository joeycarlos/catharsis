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

    public float dualAttackOffsetValue;

    public int numProjectilesLevel;

    private int currentHealth;
    private Vector3 startHoldMousePosition;
    private Vector3 startHoldPlayerPosition;

    private float attackTimeInterval;
    private float timeSinceAttack;
    private Vector3 dualAttackOffset;

    private int experienceValue;

    void Start() {
        currentHealth = maxHealth;
        GameplayUI.Instance.UpdateHealthUI(currentHealth);
        timeSinceAttack = 0;
        attackTimeInterval = 1.0f / attacksPerSecond;
        dualAttackOffset = new Vector3(dualAttackOffsetValue, 0, 0);
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
            Vector3 targetVector = startHoldPlayerPosition + offsetVector;
            targetVector.x = Mathf.Clamp(targetVector.x, -5.0f, 5.0f);
            targetVector.y = Mathf.Clamp(targetVector.y, -9.5f, 9.5f);
            this.transform.position = targetVector;

        }

        return Vector3.zero;
    }

    void ReadCatharsisInput() {
        if (Input.GetKeyDown(KeyCode.F)) {
            Instantiate(catharsis, new Vector3(0, -11.0f , 0), Quaternion.identity);
        }
    }

    void Attack() {
        switch (numProjectilesLevel) {
            case 0:
                SpawnProjectile(transform.position, Vector3.up, 10);
                break;
            case 1:
                SpawnProjectile(transform.position - dualAttackOffset * 0.5f, Vector3.up, 10);
                SpawnProjectile(transform.position + dualAttackOffset * 0.5f, Vector3.up, 10);
                break;
            case 2:
                SpawnProjectile(transform.position, Vector3.up, 10);

                SpawnProjectile(transform.position, Quaternion.AngleAxis(86, Vector3.forward) * Vector3.right, 10);
                SpawnProjectile(transform.position, Quaternion.AngleAxis(94, Vector3.forward) * Vector3.right, 10);
                break;
            case 3:
                SpawnProjectile(transform.position - dualAttackOffset * 0.5f, Quaternion.AngleAxis(91, Vector3.forward) * Vector3.right, 10);
                SpawnProjectile(transform.position + dualAttackOffset * 0.5f, Quaternion.AngleAxis(89, Vector3.forward) * Vector3.right, 10);

                SpawnProjectile(transform.position - dualAttackOffset * 2, Quaternion.AngleAxis(92, Vector3.forward) * Vector3.right, 10);
                SpawnProjectile(transform.position + dualAttackOffset * 2, Quaternion.AngleAxis(88, Vector3.forward) * Vector3.right, 10);
                break;
            case 4:
                SpawnProjectile(transform.position, Vector3.up, 10);

                SpawnProjectile(transform.position - dualAttackOffset, Quaternion.AngleAxis(91, Vector3.forward) * Vector3.right, 10);
                SpawnProjectile(transform.position + dualAttackOffset, Quaternion.AngleAxis(89, Vector3.forward) * Vector3.right, 10);

                SpawnProjectile(transform.position - dualAttackOffset * 2, Quaternion.AngleAxis(92, Vector3.forward) * Vector3.right, 10);
                SpawnProjectile(transform.position + dualAttackOffset * 2, Quaternion.AngleAxis(88, Vector3.forward) * Vector3.right, 10);
                break;
            case 5:
                SpawnProjectile(transform.position - dualAttackOffset * 0.5f, Vector3.up, 10);
                SpawnProjectile(transform.position + dualAttackOffset * 0.5f, Vector3.up, 10);

                SpawnProjectile(transform.position - dualAttackOffset * 2, Quaternion.AngleAxis(91, Vector3.forward) * Vector3.right, 10);
                SpawnProjectile(transform.position + dualAttackOffset * 2, Quaternion.AngleAxis(89, Vector3.forward) * Vector3.right, 10);

                SpawnProjectile(transform.position - dualAttackOffset * 3, Quaternion.AngleAxis(92, Vector3.forward) * Vector3.right, 10);
                SpawnProjectile(transform.position + dualAttackOffset * 3, Quaternion.AngleAxis(88, Vector3.forward) * Vector3.right, 10);
                break;
        }
        
    }

    void SpawnProjectile(Vector3 position, Vector3 direction, float speed) {
        GameObject iProjectile = Instantiate(projectile, position, Quaternion.identity);
        iProjectile.GetComponent<PlayerProjectile>().initProjectile(direction, speed);
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
