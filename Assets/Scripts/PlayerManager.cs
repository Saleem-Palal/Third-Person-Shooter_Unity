using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    InputManager inputManager;
    [SerializeField] CameraManager cameraManager;
    PlayerController playerController;
    void Awake()
    {
        inputManager = GetComponent<InputManager>();
        playerController = GetComponent<PlayerController>();
        //cameraManager = FindObjectOfType<CameraManager>();
    }

    // Update is called once per frame
    void Update()
    {
        inputManager.HandleAllInputs();
    }

    private void FixedUpdate()
    {
        playerController.HandleAllMovements();
    }

    private void LateUpdate()
    {
        cameraManager.HandleAllCameraMovement();
    }
}
