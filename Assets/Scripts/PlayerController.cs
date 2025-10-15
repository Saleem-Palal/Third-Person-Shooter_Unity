using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    InputManager inputManager;
    Rigidbody rb;

    Vector3 moveDirection;

    public Transform camObejct;


    [SerializeField] float moveSpeed = 7f;
    [SerializeField] float rotationSpeed = 15.0f;

    

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        rb = GetComponent<Rigidbody>();
    }

    private void HandleMovement()
    {
        moveDirection = camObejct.forward * inputManager.verticalInput;
        moveDirection = moveDirection + camObejct.right * -inputManager.horizontalInput;

        moveDirection.Normalize();

        moveDirection.y = 0;

        moveDirection *= moveSpeed;

        Vector3 movementVelocity = moveDirection;

        rb.velocity = movementVelocity;
    }

    private void HandleRotation()
    {
        Vector3 targetDirection = Vector3.zero;

        targetDirection = camObejct.up * inputManager.verticalInput;

        targetDirection = targetDirection + camObejct.right * -inputManager.horizontalInput;

        targetDirection.Normalize();
        targetDirection.y = 0;

        if(targetDirection == Vector3.zero)
            targetDirection = transform.forward;

        Quaternion targetRotaion = Quaternion.LookRotation(targetDirection);

        Quaternion playerRotaion = Quaternion.Slerp(transform.rotation, targetRotaion, rotationSpeed*Time.deltaTime);

        transform.rotation = playerRotaion;
    }

    public void HandleAllMovements()
    {
        HandleMovement();
        HandleRotation();
    }

    private void FixedUpdate()
    {
        
    }
}
