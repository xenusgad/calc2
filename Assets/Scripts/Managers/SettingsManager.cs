using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] private Settings settings;
    [SerializeField] private Slider slider;
    [SerializeField] private TMP_Dropdown dropdown;
    [SerializeField] private TMP_Text textPercentage;
    private void OnEnable()
    {
        settings = FindFirstObjectByType<SaveManager>().settings;
        UpdateVisualsSettings();
    }
    public void SliderChanged(float value)
    {
        settings.volume = value;
        textPercentage.text = Convert.ToString(Math.Round(value * 100)) + "%";
    }
    public void DropBoxChanged(int value)
    {
        switch (value)
        {
            case 0:
                settings.language = Languages.ENG;
            break;
            case 1:
                settings.language = Languages.RUS;
            break;
        }
    }
    public void UpdateVisualsSettings()
    {
        slider.value = (float)settings.volume;
        dropdown.value = (int)settings.language;
    }
}
