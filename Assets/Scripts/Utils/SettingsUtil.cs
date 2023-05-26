using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsUtil
{
    public static void Set—omplexity(Complexity complexity)
    {
        PlayerPrefs.SetInt("Complexity", (int)complexity);
    }

    public static Complexity GetComplexity()
    {
        return (Complexity)PlayerPrefs.GetInt("Complexity", 1);
    }

    public static void SetSensitivity(float sensitivity)
    {
        PlayerPrefs.SetFloat("Sensitivity", sensitivity);
    }

    public static float GetSensitivity()
    {
        return PlayerPrefs.GetFloat("Sensitivity", 30);
    }
}
