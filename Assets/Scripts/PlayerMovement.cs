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
    
    //bool to check if resource already given
    private bool goldGiven;
    private bool keyGiven;
    private bool waterGiven;

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
        goldGiven = false;
        keyGiven = false;
        waterGiven = false;
        
        uiDialogueBox.SetActive(false);
        DisplayOnDialogueBox("Alright then. Let's get everyone everything they need and light up the place as I go along with it", 6f);
    }

    // Update is called once per frame
    void Update()
    {
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
        if (!goldGiven)
        {
            if (goldCount-goldNeeded >= 0)
            {
                goldCount -= goldNeeded;
                uiInventory.UpdateGoldCount(goldCount);
                DisplayOnDialogueBox("Friend: Thank you for the Gold!", 3f);
                goldGiven = true;
                AttemptToDisplayEndCondition();
            }
            else 
            {
                DisplayOnDialogueBox("Not enough Gold", 3.0f);
            }
        }
        else
        {
            DisplayOnDialogueBox("Friend: Hey You've already given me Gold. Thanks but I do not need more of it.", 3f);
        }
        
    }
    
    //Function to subtract keys when requested
    public void FriedRequestedKey(int keyNeeded)
    {
        if (!keyGiven)
        {
            if (keysCount - keyNeeded >= 0)
            {
                keysCount -= keyNeeded;
                uiInventory.UpdateKeyCount(waterCount);
                DisplayOnDialogueBox("Friend: Thanks for the Key!", 3f);
                keyGiven = true;
                AttemptToDisplayEndCondition();
            }
            else if (keyNeeded < keysCount)
            {
                DisplayOnDialogueBox("Not enough Keys", 3.0f);
            }
        }
        else
        {
            DisplayOnDialogueBox("Friend: Hey You've already given me a Key. Thanks but I do not need more of it.", 3f);
        }
    }
    
    //Function to subtract water when requested
    public void FriedRequestedWater(int waterNeeded)
    {
        if (!waterGiven)
        {
            if (waterCount - waterNeeded >= 0)
            {
                waterCount -= waterNeeded;
                uiInventory.UpdateWaterCount(waterCount);
                DisplayOnDialogueBox("Friend: Hey! Thanks for the Water", 3f);
                waterGiven = true;
                AttemptToDisplayEndCondition();
            }
            else if (waterNeeded < waterCount)
            {
                DisplayOnDialogueBox("Not enough Water", 3.0f);
            }
        }
        else
        {
            DisplayOnDialogueBox("Friend: Hey You've already given me Water. Thanks but I do not need more of it.", 3f);
        }
        
    }
    
    //Generic function to display something on the Dialogue Box
    public void DisplayOnDialogueBox(String dialogueText, float displayTime)
    {
        StartCoroutine(DisplayTextForTime(dialogueText, displayTime));
    }

    //End Condition
    private void AttemptToDisplayEndCondition()
    {
        bool endCondition = (goldGiven && keyGiven && waterGiven);

        if (endCondition)
        {
            DisplayOnDialogueBox("Thank you for playing this little protoype. That's all!! Have a great rest of your day :)", 20f);
        }
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
