using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 0;
    [SerializeField] private float sense = 0;

    private Rigidbody rb;

    private float movementX;
    private float movementY;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void OnLook(InputValue rotationValue)
    {
        Vector2 rotationVector = rotationValue.Get<Vector2>();
        Rotate(rotationVector);
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0f, movementY);

        Roll(movement);
    }
    
    private void Roll(Vector3 direction)
    {
        direction = transform.TransformDirection(direction);

        rb.AddForce(direction * speed);
    }

    private void Rotate(Vector3 rotation)
    {
        if (rotation.x == 0)
            return;

        float yRotation = transform.localEulerAngles.y + Mathf.Sign(rotation.x) * sense * Time.deltaTime;
        Debug.Log(Mathf.Sign(rotation.x));

        transform.localRotation = Quaternion.Euler(0f, yRotation, 0f);
    }
}
