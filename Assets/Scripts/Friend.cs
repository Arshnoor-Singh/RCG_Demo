using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Friend : MonoBehaviour
{
    public int itemNeeded = 4;
    private bool playerInRange;
    private bool dialogueFinished = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //Function to execute a dialogue. This function will set the bool for dialogue to true

            if (Input.GetKey(KeyCode.E) && dialogueFinished == true)
            {
                
            }
        }
    }

    private void ShowDialogue()
    {
        
    }
}
