using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(29, 173, 0, 255);
    [SerializeField] Color32 noPackageColor = new Color32(117, 240, 247, 255);
    bool hasPackage;
    [SerializeField] float delayPackageDestruction = 1f;

    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("ow");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package picked up");
            spriteRenderer.color = hasPackageColor;
            Destroy(collision.gameObject, delayPackageDestruction);
            hasPackage = true;

        }
        if (collision.tag == "Customer" && hasPackage)
        {
            Debug.Log("Package dropped off");
            spriteRenderer.color = noPackageColor;
            hasPackage = false;
        }

    }
}
