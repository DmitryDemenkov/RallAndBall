using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public static event Action BallFallen;

    [SerializeField] private Ball ball;

    private float movementX;
    private float movementY;

    private Vector3 startPoint;
    private Vector3 startRotation;


    private void Awake()
    {
        CheckPoint.StartPointChanged += OnStartPointChanged;
        startPoint = ball.transform.position;
        startRotation = transform.forward;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        BallFallen += OnBallFallen;
    }

    private void OnStartPointChanged(Vector3 newPosition, Vector3 newRotation)
    {
        startPoint = newPosition;
        startRotation = newRotation;
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void OnLook(InputValue rotationValue)
    {
        if (!Cursor.visible)
        {
            Vector2 rotationVector = rotationValue.Get<Vector2>();
            Rotate(rotationVector);
        }
    }

    private void OnJump(InputValue jumpValue)
    {
        ball.Jump();
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0f, movementY);
        Vector3 direction = transform.TransformDirection(movement);

        ball.Roll(direction);
    }

    private void LateUpdate()
    {
        transform.position = ball.transform.position;
        CheckFalling();
    }

    private void CheckFalling()
    {
        if (transform.position.y < -10)
        {
            BallFallen?.Invoke();
        }
    }

    private void OnBallFallen()
    {
        ball.MoveAt(startPoint);
        transform.forward = startRotation;
    }

    private void Rotate(Vector3 rotation)
    {
        if (rotation.x == 0)
            return;

        float yRotation = transform.localEulerAngles.y + rotation.x * Sensitivity.Value * Time.deltaTime;

        transform.localRotation = Quaternion.Euler(0f, yRotation, 0f);
    }

    private void OnDestroy()
    {
        CheckPoint.StartPointChanged -= OnStartPointChanged;
        BallFallen -= OnBallFallen;
    }
}
