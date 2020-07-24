using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Envy : Enemy
{
    public float idleVerticalMoveSpeed;
    public float idleHorizontalVibrateSpeed;
    public float idleVibrateAmplitude;

    private float originalXPosition;
    private float elapsedTime;

    new void Start() {
        base.Start();

        originalXPosition = this.transform.position.x;
        elapsedTime = 0;
    }

    void Update() {
        Move();
        elapsedTime += Time.deltaTime;
    }

    void Move() {
        Vector3 moveVector = this.transform.position;
        float newX = Mathf.Sin(elapsedTime * idleHorizontalVibrateSpeed) * idleVibrateAmplitude + originalXPosition;

        transform.position = new Vector3(newX, this.transform.position.y - (idleVerticalMoveSpeed * Time.deltaTime), this.transform.position.z);
    }
}
