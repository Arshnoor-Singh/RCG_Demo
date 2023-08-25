using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Friend : MonoBehaviour
{
    public enum itemType
    {
        gold,
        keys,
        water
    };

    public itemType itemNeeded;
    public int amountNeeded = 4;
    private bool playerInRange;
    private bool dialogueFinished = false;
    private bool conditionsMet;

    private PlayerMovement characterReference;
    
    private void Update()
    {
        if (conditionsMet)
        {
            if (Input.GetKey(KeyCode.E))
            {
                switch (itemNeeded)
                {
                    case itemType.gold:
                        characterReference.FriedRequestedGold(amountNeeded);
                        break;
                    
                    case itemType.keys:
                        characterReference.FriedRequestedKey(amountNeeded);
                        break;
                    
                    case itemType.water:
                        characterReference.FriedRequestedWater(amountNeeded);
                        break;
                }

                conditionsMet = false;
            }
            else Debug.Log("Input detection condition failed");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //player script reference
        characterReference = other.GetComponent<PlayerMovement>();
        if(!characterReference)return;
        
        playerInRange = true;
        
        if (characterReference.CompareTag("Player"))
        {
            if (!dialogueFinished)
            {
                StartCoroutine(DisplayDialogue(3f));
            }
            else
            {
                conditionsMet = playerInRange && dialogueFinished;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        playerInRange = false;
        conditionsMet = false;
    }

    IEnumerator DisplayDialogue(float time = 1f)
    {
        characterReference.DisplayOnDialogueBox($"Friend: Hey! Good morning. I'm gonna get to work soon. Can you get me {amountNeeded} gold for the way?", time);
        yield return new WaitForSeconds(time);
        dialogueFinished = true;
        conditionsMet = dialogueFinished && playerInRange;
    }
}
