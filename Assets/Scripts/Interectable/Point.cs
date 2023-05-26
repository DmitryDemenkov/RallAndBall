using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public static event Action<Point> Grabed;

    [SerializeField] private int _count = 0;
    [SerializeField] private int _rotatingSpeed = 0;

    public int Count { get { return _count; } }

    private Complexity _complexity;

    private void Awake()
    {
        _complexity = SettingsUtil.GetComplexity();
        PlayerController.BallFallen += OnBallFallen;
    }

    private void OnTriggerEnter(Collider other)
    {
        Ball ball = other.GetComponent<Ball>();
        if (ball != null)
        {
            Grabed?.Invoke(this);
            gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        transform.localEulerAngles = transform.localEulerAngles + Vector3.up * _rotatingSpeed * Time.deltaTime;
    }

    private void OnBallFallen()
    {
        if (_complexity == Complexity.HARD)
        {
            gameObject.SetActive(true);
        }
    }

    private void OnDestroy()
    {
        PlayerController.BallFallen -= OnBallFallen;
    }
}
