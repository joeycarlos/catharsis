using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anger : Enemy
{
    public float moveSpeed;
    public float acceleration;

    new void Start() {
        base.Start();
    }

    void Update() {
        Move();
    }

    void Move() {
        // moveSpeed += acceleration * Time.deltaTime;
        Vector3 moveVector = new Vector3(0, -moveSpeed, 0) * Time.deltaTime;
        this.transform.position += moveVector;
    }
}
