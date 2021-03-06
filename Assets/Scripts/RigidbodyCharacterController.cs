﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

public class RigidbodyCharacterController : MonoBehaviour
{

    [SerializeField]
    private float accelerationForce = 10;

    [SerializeField]
    private float maxSpeed = 8;

    [SerializeField]
    private PhysicMaterial stoppingPhysicsMaterial, movingPhysicsMaterial;

    [SerializeField]
    [Tooltip("0 = no turning, 1 = Instant turning")]
    [Range(0, 1)]
    private float turnSpeed = 0.1f;

    private new Rigidbody rigidbody;
    private Vector2 input;
    private new Collider collider;

    private void Start()
    {

        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();

    }

    private void FixedUpdate()
    {

        var inputDirection = new Vector3(input.x, 0, input.y);

        Vector3 cameraFlattenedForward = Camera.main.transform.forward;
        cameraFlattenedForward.y = 0;
        Quaternion cameraRotation = Quaternion.LookRotation(cameraFlattenedForward);

        Vector3 cameraRelativeInputDirection = cameraRotation * inputDirection;

        if (inputDirection.magnitude > 0)
        {

            collider.material = movingPhysicsMaterial;

        }
        else
        {
            collider.material = stoppingPhysicsMaterial;
        }
        if (rigidbody.velocity.magnitude < maxSpeed)
        {
        
            rigidbody.AddForce(cameraRelativeInputDirection * accelerationForce, ForceMode.Acceleration);

        }

        if (cameraRelativeInputDirection.magnitude > 0)
        {

            var targetRotation = Quaternion.LookRotation(cameraRelativeInputDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, turnSpeed);

        }

    }

    public void OnMove(InputAction.CallbackContext context)
    {

        input = context.ReadValue<Vector2>();

    }

}
