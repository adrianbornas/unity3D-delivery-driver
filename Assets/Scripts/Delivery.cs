using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    private bool hasPackage = false;

    [SerializeField] float destroyDelay = 0.5f;

    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Ouch!");
    }
    void OnTriggerEnter2D(Collider2D other) {
        if ("Package" == other.tag && !hasPackage) {
            Debug.Log("Package picked up");
            hasPackage = true;

            Destroy(other.gameObject, destroyDelay);
        }

        if ("Customer" == other.tag && hasPackage) {
            Debug.Log("Delivered package");
            hasPackage = false;
        }
    }
}
