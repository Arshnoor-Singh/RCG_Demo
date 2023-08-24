using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public int keyCount = 1;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.GetComponent<PlayerMovement>()) return;
        other.GetComponent<PlayerMovement>().IncrementKeys(keyCount);
        Destroy(gameObject);
    }
}
