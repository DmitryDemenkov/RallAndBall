using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private GameObject _explosion;

    private int forceModule = 10;

    private Complexity _complexity;

    private void Awake()
    {
        _complexity = SettingsUtil.GetComplexity();
        PlayerController.BallFallen += OnBallFallen;
    }

    private void OnBallFallen()
    {
        if (_complexity == Complexity.HARD)
        {
            gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Ball ball = other.GetComponent<Ball>();
        if (ball != null)
        {
            Vector3 forceDirection = other.transform.position - this.transform.position;
            ball.Push(forceDirection * forceModule);

            Instantiate(_explosion, transform.position, _explosion.transform.rotation);

            gameObject.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        PlayerController.BallFallen -= OnBallFallen;
    }
}
