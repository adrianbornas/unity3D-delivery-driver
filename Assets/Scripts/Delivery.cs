using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Ouch!");
    }
    void OnTriggerEnter2D(Collider2D other) {
        if ("Package" == other.tag) {
            Debug.Log("Package picked up");
        }

        if ("Customer" == other.tag) {
            Debug.Log("Delivered package");
        }
    }
}
