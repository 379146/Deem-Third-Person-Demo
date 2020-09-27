using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class RigidbodyCharacterController : MonoBehaviour
{

    [SerializeField]
    private float accelerationForce = 10;

    [SerializeField]
    private float maxSpeed = 8;

    [SerializeField]
    private PhysicMaterial stoppingPhysicsMaterial, movingPhysicsMaterial;

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
        
            rigidbody.AddForce(inputDirection * accelerationForce, ForceMode.Acceleration);

        }
    
    }

    private void Update()
    {

        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
    
    }

}
