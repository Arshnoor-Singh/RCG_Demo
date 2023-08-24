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
    

    //Input Action Function
    public void MoveDetected(InputAction.CallbackContext context)
    {
        movementVector = context.ReadValue<Vector2>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        updateAnimations();
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

    void updateAnimations()
    {
        animator.SetFloat("Horizontal", movementVector.x);
        animator.SetFloat("Vertical", movementVector.y);
    }
}
