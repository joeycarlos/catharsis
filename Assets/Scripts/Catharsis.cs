using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catharsis : MonoBehaviour
{
    public float moveSpeed;
    public int attackDamage;
    public float lifetime;

    // Start is called before the first frame update
    void Start() {
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update() {
        Move();
    }

    void Move() {
        Vector3 moveVector = new Vector3(0, moveSpeed * Time.deltaTime, 0);
        transform.position += moveVector;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.GetComponent<Enemy>() != null) {
            Enemy iEnemy = collision.gameObject.GetComponent<Enemy>();
            iEnemy.TakeDamage(attackDamage);
        }
    }
}
