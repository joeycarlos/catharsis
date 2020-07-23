using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Envy : Enemy
{
    public float idleVerticalMoveSpeed;
    public float idleHorizontalVibrateSpeed;
    public float idleVibrateAmplitude;

    private float originalXPosition;

    new void Start() {
        base.Start();

        originalXPosition = this.transform.position.x;
    }

    void Update() {
        Move();
    }

    void Move() {
        Vector3 moveVector = this.transform.position;
        float newX = Mathf.Sin(Time.time * idleHorizontalVibrateSpeed) * idleVibrateAmplitude + originalXPosition;

        transform.position = new Vector3(newX, this.transform.position.y - (idleVerticalMoveSpeed * Time.deltaTime), this.transform.position.z);
    }
}
