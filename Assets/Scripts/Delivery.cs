using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    [SerializeField] float destroyDelay = 0.5f;
     
    bool hasPackage = false;
    [SerializeField] Color32 hasPackageColor = new Color32(14, 176, 4, 255);
    [SerializeField] Color32 noPackageColor = new Color32(166, 50, 50, 255);

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = noPackageColor;
    }
    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Ouch!");
    }
    void OnTriggerEnter2D(Collider2D other) {
        if ("Package" == other.tag && !hasPackage) {
            Debug.Log("Package picked up");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;

            Destroy(other.gameObject, destroyDelay);
        }

        if ("Customer" == other.tag && hasPackage) {
            Debug.Log("Delivered package");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
}
