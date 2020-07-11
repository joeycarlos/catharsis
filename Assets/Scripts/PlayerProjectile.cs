using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public float moveSpeed;
    public int attackDamage;

    public GameObject hitEffect;

    private Vector3 moveVector;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // moveVector = new Vector3(0, moveSpeed, 0) * Time.deltaTime;
        this.transform.position += moveVector * Time.deltaTime;
    }

    public void initProjectile(Vector3 moveDirection, float newMoveSpeed) {
        moveSpeed = newMoveSpeed;
        moveVector = moveDirection.normalized * moveSpeed;
    }

    private void OnBecameInvisible() {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.GetComponent<Enemy>() != null) {
            Enemy iEnemy = collision.gameObject.GetComponent<Enemy>();
            iEnemy.TakeDamage(attackDamage);
            Instantiate(hitEffect, gameObject.GetComponent<Transform>().position, Quaternion.Euler(90, 0, 0));
            Destroy(gameObject);
        }  
    }

}
