using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

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

    //Inventory reference
    [SerializeField] public UI_Inventory uiInventory;

    
    //Input Action Function
    public void MoveDetected(InputAction.CallbackContext context)
    {
        movementVector = context.ReadValue<Vector2>();
    }

    private void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateAnimations();
    }

    private void FixedUpdate()
    {
        UpdateMovement();
    }

    
    //FIX ROTATION WTF
    void UpdateMovement()
    {
        playerRB.velocity = movementVector * moveSpeed;
    }

    void UpdateAnimations()
    {
        animator.SetFloat("Anim_Move_X", movementVector.x);
        animator.SetFloat("Anim_Move_Y", movementVector.y);
    }

    
    public void IncrementGold(int goldAmount)
    {
        goldCount += goldAmount;
        uiInventory.UpdateGoldCount(goldCount);
    }
    
    public void IncrementKeys(int keyAmount)
    {
        keysCount += keyAmount;
        uiInventory.UpdateKeyCount(keysCount);
    }
    
    public void IncrementWater(int waterAmount)
    {
        waterCount += waterAmount;
        uiInventory.UpdateWaterCount(waterCount);
    }
}
