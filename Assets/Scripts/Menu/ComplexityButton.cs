using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComplexityButton : MonoBehaviour
{
    private static Action<Complexity> ComplexityChanged;

    [SerializeField] private Complexity _complexity;
    [SerializeField] private Image _backGround;

    private void Awake()
    {
        Complexity complexity = SettingsUtil.GetComplexity();
        SetActive(complexity == _complexity);

        Button button = GetComponent<Button>();
        button.onClick.AddListener(ChangeComplexity);

        ComplexityChanged += OnComplexityChanged;
    }

    public void ChangeComplexity()
    {
        if (IsActive()) { return; }

        SettingsUtil.Set—omplexity(_complexity);
        ComplexityChanged?.Invoke(_complexity);
    }

    private void OnComplexityChanged(Complexity complexity)
    {
        SetActive(complexity == _complexity);
    }

    private void SetActive(bool b)
    {
        _backGround.color = b ? Color.white : Color.black;
    }
    
    private bool IsActive()
    {
        return _backGround.color == Color.white;
    }

    private void OnDestroy()
    {
        ComplexityChanged -= OnComplexityChanged;
    }
}
