using System;
using System.Collections;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 1f;
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D playerRB;
    private Vector2 movementVector;
    
    //current inventory items amounts
    private int goldCount;
    private int keysCount;
    private int waterCount;

    //Inventory Script reference
    [SerializeField] public UI_Inventory uiInventory;
    [SerializeField] public GameObject uiDialogueBox;
    [SerializeField] public TextMeshProUGUI uiDialogueText;
    
    //Input Action Function
    public void MoveDetected(InputAction.CallbackContext context)
    {
        movementVector = context.ReadValue<Vector2>();
    }

    private void Start()
    {
        uiDialogueBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.LogWarning(goldCount);
        UpdateAnimations();
    }
    
    // Fixed Update is called 50 times a second
    private void FixedUpdate()
    {
        UpdateMovement();
    }
    
    void UpdateMovement()
    {
        playerRB.velocity = movementVector * moveSpeed;
    }

    void UpdateAnimations()
    {
        animator.SetFloat("Anim_Move_X", movementVector.x);
        animator.SetFloat("Anim_Move_Y", movementVector.y);
    }

    //Function to increment gold when gold is picked up
    public void IncrementGold(int goldAmount)
    {
        goldCount += goldAmount;
        uiInventory.UpdateGoldCount(goldCount);
    }
    
    //Function to increment keys when keys are picked up
    public void IncrementKeys(int keyAmount)
    {
        keysCount += keyAmount;
        uiInventory.UpdateKeyCount(keysCount);
    }
    
    //Function to increment water when water is picked up
    public void IncrementWater(int waterAmount)
    {
        waterCount += waterAmount;
        uiInventory.UpdateWaterCount(waterCount);
    }

    //Function to subtract gold when requested
    public void FriedRequestedGold(int goldNeeded)
    {
        if (goldCount-goldNeeded > 0)
        {
            goldCount -= goldNeeded;
            uiInventory.UpdateGoldCount(goldCount);
        }
        else 
        {
            DisplayOnDialogueBox("Not enough Gold", 3.0f);
        }
        
    }
    
    //Function to subtract keys when requested
    public void FriedRequestedKey(int keyNeeded)
    {
        if (keyNeeded>= keysCount)
        {
            keysCount = keysCount - keyNeeded;
            uiInventory.UpdateKeyCount(waterCount);
        }
        else if (keyNeeded < keysCount)
        {
            
        }
    }
    
    //Fucntion to subtract water when requested
    public void FriedRequestedWater(int waterNeeded)
    {
        if (waterNeeded>= waterCount)
        {
            waterCount = waterCount - waterNeeded;
            uiInventory.UpdateWaterCount(waterCount);
        }
        else if (waterNeeded < waterCount)
        {
            
        }
    }
    
    //Generic function to display something on the Dialogue Box
    public void DisplayOnDialogueBox(String dialogueText, float displayTime)
    {
        StartCoroutine(DisplayTextForTime(dialogueText, displayTime));
    }

    //Coroutine
    IEnumerator DisplayTextForTime(string dialogueText, float timerAmount = 1f)
    {
        uiDialogueBox.SetActive(true);
        uiDialogueText.text = dialogueText;
        
        yield return new WaitForSeconds(timerAmount);
        
        uiDialogueBox.SetActive(false);
    }
    
    public int returnGoldCount()
    {
        return goldCount;
    }
}
