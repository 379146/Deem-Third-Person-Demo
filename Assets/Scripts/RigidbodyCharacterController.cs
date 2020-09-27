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

    private new Rigidbody rigidbody;
    private Vector2 input;

    private void Start()
    {

        rigidbody = GetComponent<Rigidbody>();

    }

    private void FixedUpdate()
    {

        var inputDirection = new Vector3(input.x, 0, input.y);
        if (rigidbody.velocity.magnitude < maxSpeed)
        {
        
            rigidbody.AddForce(inputDirection * accelerationForce);

        }
    
    }

    private void Update()
    {

        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
    
    }

}
