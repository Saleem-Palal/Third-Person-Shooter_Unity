using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    NewActions inputActions;
    AnimationManager animationManager;

    [SerializeField] Vector2 movementInput;
   
    public float verticalInput;
    public float horizontalInput;


    private float moveAmount;
    private void Awake()
    {
        animationManager = GetComponent<AnimationManager>();
    }
    private void OnEnable()
    {
        if(inputActions == null)
        {
            inputActions = new NewActions();

            inputActions.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();

        }

        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }


    public void HandleAllInputs()
    {
        HandleMovementInput();
    }
    private void HandleMovementInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;

        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput)+Mathf.Abs(verticalInput));

        Debug.Log(moveAmount);

        animationManager.UpdateAnimationValues(0, moveAmount);

        
    }
}
