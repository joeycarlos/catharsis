using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float moveSpeed;
    public int attackDamage;

    private Vector3 moveVector;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void FixedUpdate() {
        moveVector = new Vector3(0, -moveSpeed, 0) * Time.deltaTime;
        this.transform.position += moveVector;
    }

    private void OnBecameInvisible() {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.GetComponent<Player>() != null) {
            Player iPlayer = collision.gameObject.GetComponent<Player>();
            iPlayer.TakeDamage(attackDamage);
            Destroy(gameObject);
        } else if (collision.gameObject.tag == "BottomBoundary") {
            Destroy(gameObject);
        }
    }
}
