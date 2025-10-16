using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform targetTransform;
    private InputManager inputManager;

    public Transform cameraPivot;
    public float cameraFollowSpeed = 0.2f;
    public float cameraLookSpeed = 2;
    public float cameraPivotSpeed = 2;

    public Vector3 Offset;

    Vector3 targetPosition;
    Vector3 cameraFollowVelocity=Vector3.zero;

    float lookAngle;
    float pivotAngle;
    float lookSpeed;
    public  float minPivot = -35;
    public float maxPivot = 35;

    private void Awake()
    {
        targetTransform = FindObjectOfType<PlayerManager>().transform;
        inputManager = FindObjectOfType<InputManager>();
    }

    public void HandleAllCameraMovement()
    {
        FollowTarget();
        RotateCamera();
    }

    private void FollowTarget()
    {
        targetPosition = Vector3.SmoothDamp
            (transform.position, targetTransform.position, ref cameraFollowVelocity,cameraFollowSpeed);


        transform.position = targetPosition ;
    }

    private void RotateCamera()
    {
        lookAngle = lookAngle + (inputManager.horizontalCamInput * cameraLookSpeed * Time.deltaTime);

        pivotAngle -= (inputManager.verticalCamInput * cameraPivotSpeed * Time.deltaTime);
        pivotAngle = Mathf.Clamp(pivotAngle, minPivot, maxPivot);

        Vector3 rotation = Vector3.zero;

        rotation.y = lookAngle;

        Quaternion targetRotation = Quaternion.Euler(rotation);

        transform.rotation = targetRotation;



        rotation = Vector3.zero;

        rotation.x = pivotAngle;

        targetRotation = Quaternion.Euler(rotation);

        cameraPivot.localRotation = targetRotation;


    }

}
