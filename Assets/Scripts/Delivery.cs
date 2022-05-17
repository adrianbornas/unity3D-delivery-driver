using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    private bool hasPackage = false;

    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Ouch!");
    }
    void OnTriggerEnter2D(Collider2D other) {
        if ("Package" == other.tag) {
            Debug.Log("Package picked up");
            hasPackage = true;
        }

        if ("Customer" == other.tag && hasPackage) {
            Debug.Log("Delivered package");
            hasPackage = false;
        }
    }
}
