using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostPlatform : MonoBehaviour
{
    [SerializeField] private float _forceModule;

    private void OnTriggerEnter(Collider other)
    {
        Ball ball = other.GetComponent<Ball>();
        if (ball != null)
        {
            Vector3 direction = Quaternion.AngleAxis(45f, transform.right) * -transform.forward;
            ball.Push(direction * _forceModule);
        }
    }
}
