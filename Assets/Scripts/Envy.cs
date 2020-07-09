using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Envy : Enemy
{
    public float moveSpeed;

    new void Start() {
        base.Start();
    }

    void Update() {
        Move();
    }

    void Move() {
        Vector3 moveVector = new Vector3(0, -moveSpeed, 0) * Time.deltaTime;
        this.transform.position += moveVector;
    }
}
