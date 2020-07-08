using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public float idleVerticalMoveSpeed;

    public float idleHorizontalVibrateSpeed;
    public float idleVibrateAmplitude;

    public float attractMoveSpeed;
    public float attractAccelerationFactor;
    public float attractSpeedIncreaseTime;

    public float spawnTime;
    public int experienceValue;

    private State state;

    private GameObject player;

    private float currentAttractSpeedTime;
    private float originalXPosition;

    private float elapsedTime;

    // Start is called before the first frame update
    void Start() {
        state = State.Spawning;
        player = GameObject.FindWithTag("Player");
        currentAttractSpeedTime = 0;
        originalXPosition = this.transform.position.x;
    }

    // Update is called once per frame
    void Update() {
        switch (state) {
            case State.Spawning:
                if (elapsedTime < spawnTime) {
                    elapsedTime += Time.deltaTime;
                } else {
                    state = State.Idle;
                }
                break;
            case State.Idle:
                IdleFloat();
            break;

            case State.Attract:
                MoveToPlayer();
                currentAttractSpeedTime += Time.deltaTime;
                if (currentAttractSpeedTime > attractSpeedIncreaseTime) {
                    UpdateAttractSpeed();
                    currentAttractSpeedTime = 0;
                }
            break;
        }
            
    }

    private void IdleFloat() {
        Vector3 moveVector = this.transform.position;
        float newX = Mathf.Sin(Time.time * idleHorizontalVibrateSpeed) * idleVibrateAmplitude + originalXPosition;

        transform.position = new Vector3(newX, this.transform.position.y - (idleVerticalMoveSpeed * Time.deltaTime) , this.transform.position.z);
    }

    private void MoveToPlayer() {
        Vector3 moveVector = Vector3.Normalize(player.transform.position - this.transform.position) * attractMoveSpeed * Time.deltaTime;
        this.transform.position += moveVector;
        
    }

    private void UpdateAttractSpeed() {
        attractMoveSpeed *= attractAccelerationFactor;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "PlayerAura") {
            state = State.Attract;
        } else if (collision.gameObject.tag == "Player") {
            player.GetComponent<Player>().GainExperience(experienceValue);
            // Spawn collect pickup effect
            Destroy(gameObject);
        }
    }

    enum State {
        Spawning,
        Idle,
        Attract
    }
}
