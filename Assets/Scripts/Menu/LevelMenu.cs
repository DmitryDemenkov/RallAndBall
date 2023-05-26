using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LevelMenu : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private TMPro.TMP_Text _complexityText;
    [SerializeField] private Sensitivity _sensitivity;

    private void Awake()
    {
        Complexity complexity = SettingsUtil.GetComplexity();
        _complexityText.text = "Complexity: " + complexity.ToString();

        _panel.SetActive(false);
    }

    private void OnOpenMenu(InputValue input)
    {
        if (_panel.activeSelf)
        {
            _sensitivity.Save();
        }

        Cursor.visible = !Cursor.visible;
        Cursor.lockState = Cursor.lockState == CursorLockMode.Locked ? CursorLockMode.None : CursorLockMode.Locked;
        _panel.SetActive(!_panel.activeSelf);
    }

    public void Retry()
    {
        _sensitivity.Save();
        SceneUtil.ReloadScene();
    }

    public void ToMenu()
    {
        _sensitivity.Save();
        SceneUtil.ToMenu();
    }
}
