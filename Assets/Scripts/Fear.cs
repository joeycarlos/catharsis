using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fear : Enemy
{
    public float moveSpeed;
    public float horizontalMoveSpeed;
    public float screenAmplitude;

    private bool moveRight;

    new void Start() {
        base.Start();

        moveRight = true;
    }

    void Update() {
        Move();
    }

    void Move() {
        if ( Mathf.Abs(transform.position.x) >= screenAmplitude) {
            moveRight = !moveRight;
        }

        float xMovement = horizontalMoveSpeed;
        if (!moveRight) {
            xMovement *= -1.0f;
        }

        Vector3 moveVector = new Vector3(xMovement, -moveSpeed, 0) * Time.deltaTime;
        this.transform.position += moveVector;
    }
}
