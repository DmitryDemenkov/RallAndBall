using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text _text;
    [SerializeField] private GameObject _victoryText;

    private int _score = 0;
    private string _scoreStr = "Score: ";
    private int _maxScore = 0;

    private Complexity _complexity;

    private void Awake()
    {
        Point.Grabed += OnPointGrabed;
        _victoryText.SetActive(false);
        _maxScore = GameObject.FindObjectsOfType<Point>().Sum(p => p.Count);
        ChangeScoreText();

        _complexity = SettingsUtil.GetComplexity();
        PlayerController.BallFallen += OnBallFalling;
    }

    private void ChangeScoreText()
    {
        _text.text = _scoreStr + _score + "/" + _maxScore;
    }

    private void OnPointGrabed(Point point)
    {
        _score += point.Count;
        ChangeScoreText();
        if (_score >= _maxScore)
        {
            _victoryText.SetActive(true);
        }
    }

    private void OnBallFalling()
    {
        if (_complexity == Complexity.HARD)
        {
            _score = 0;
            ChangeScoreText();
        }
    }

    private void OnDestroy()
    {
        Point.Grabed -= OnPointGrabed;
        PlayerController.BallFallen -= OnBallFalling;
    }
}
