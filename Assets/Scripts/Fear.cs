using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fear : Enemy
{
    public float moveSpeed;
    public float horizontalMoveSpeed;

    public float pauseTime;
    private float timeSincePause;

    public float timeToSwitchDirection;
    private float timeSinceSwitchDirection;

    private bool moveRight;
    private State state;

    new void Start() {
        base.Start();
        timeSinceSwitchDirection = 0;
        timeSincePause = 0;

        moveRight = true;
        state = State.Move;
    }

    void Update() {

        if (state == State.Move) {

            timeSinceSwitchDirection += Time.deltaTime;
            if (timeSinceSwitchDirection >= timeToSwitchDirection) {
                moveRight = !moveRight;
                timeSinceSwitchDirection = 0;
                state = State.Stop;
            }

            Move();

        } else {

            timeSincePause += Time.deltaTime;

            if (timeSincePause > pauseTime) {
                timeSincePause = 0;
                state = State.Move;
            }
        }

    }

    void Move() {

        float xMovement = horizontalMoveSpeed;
        if (!moveRight) {
            xMovement *= -1.0f;
        }

        Vector3 moveVector = new Vector3(xMovement, -moveSpeed, 0) * Time.deltaTime;
        this.transform.position += moveVector;
    }

    enum State {
        Move,
        Stop
    }
}
