using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 100f;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float slowSpeed = 1f;
    [SerializeField] float boostSpeed = 20f;

    float boostTime = 0;
    bool boosted = false;
    float slowTime = 0;
    bool slowed = false;

    void Update()
    {
        float speed = GetSpeed();

        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }
    void OnCollisionEnter2D(Collision2D other) {
        if ("Obstacle" == other.gameObject.tag) {
            Debug.Log("Obstacle collision!");
            slowed = true;
            boostTime = 0;
        }
    }
    void OnTriggerEnter2D(Collider2D other) {
        if ("Boost" == other.tag) {
            Debug.Log("Boost reached!");
            boosted = true;
        }
    }

    private float GetSpeed() {
        float speed = moveSpeed;
        if (boosted && boostTime < 0.5) {
            speed = boostSpeed;
            boostTime += Time.deltaTime;
        } else {
            boosted = false;
            boostTime = 0;
        }

        if (slowed && slowTime < 0.5) {
            speed = slowSpeed;
            slowTime += Time.deltaTime;
        } else {
            slowed = false;
            slowTime = 0;
        }

        return speed;
    }
}
