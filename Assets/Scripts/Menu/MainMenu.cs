using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private SettingsPanel _settingsPanel;

    public void StartGame()
    {
        _settingsPanel.Save();
        SceneUtil.NextScene();
    }

    public void OpenSettings()
    {
        if (!_settingsPanel.IsOpened)
        {
            _settingsPanel.Open();
        }
        else
        {
            _settingsPanel.Close();
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
}
