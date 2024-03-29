using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int goldCount = 1;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.GetComponent<PlayerMovement>()) return;
        other.GetComponent<PlayerMovement>().IncrementGold(goldCount);
        Destroy(gameObject);
    }
}
