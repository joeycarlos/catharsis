using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sadness : Enemy
{
    public float moveSpeed;
    public float attacksPerSecond;

    public GameObject projectile;

    private float attackTimeInterval;
    private float timeSinceAttack;

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();

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
}
