using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float speed = 0;
    [SerializeField] private float jumpForce = 0;
    [SerializeField] LayerMask groundMask;

    private Rigidbody _rbody;
    private SphereCollider _collider;

    private void Awake()
    {
        _rbody = GetComponent<Rigidbody>();
        _collider = GetComponent<SphereCollider>();
    }

    public void Roll(Vector3 direction)
    {
        if (IsOnGround())
        {
            _rbody.AddForce(direction * speed, ForceMode.Force);
        }
    }

    public void Jump()
    {
        if (IsOnGround())
        {
            Push(Vector3.up * jumpForce);
        }
    }

    public void Push(Vector3 force)
    {
        _rbody.AddForce(force, ForceMode.Impulse);
    }

    public void MoveAt(Vector3 position)
    {
        _rbody.velocity = Vector3.zero;
        transform.position = position;
    }

    private bool IsOnGround()
    {
        Vector3 boxCenter = new Vector3(transform.position.x, transform.position.y - _collider.radius, transform.position.z);
        Vector3 boxSize = new Vector3(_collider.radius / 2, _collider.radius / 10, _collider.radius / 2);

        Collider[] colliders = Physics.OverlapBox(boxCenter, boxSize, Quaternion.identity, groundMask);
        return colliders.Length > 0;
    }
}
