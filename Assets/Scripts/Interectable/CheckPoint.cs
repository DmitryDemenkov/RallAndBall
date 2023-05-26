using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public static event Action<Vector3, Vector3> StartPointChanged;

    private void Awake()
    {
        Complexity complexity = SettingsUtil.GetComplexity();
        gameObject.SetActive(complexity == Complexity.EASY);
    }

    private void OnTriggerEnter(Collider other)
    {
        Ball ball = other.GetComponent<Ball>();
        if (ball != null)
        {
            StartPointChanged?.Invoke(transform.position + Vector3.up, transform.forward);
            gameObject.SetActive(false);
        }
    }
}
