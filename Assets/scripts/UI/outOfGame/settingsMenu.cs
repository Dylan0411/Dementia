using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class settingsMenu : MonoBehaviour
{

    public Slider sensXSlider;
    public Slider sensYSlider;
    public Text sensXText;
    public Text sensYText;

    public Toggle invertedXToggle;
    public Toggle invertedYToggle;

    int defaultSensitivityValue = 300;

    public Slider camFOVSlider;
    public Text FOVText;

    public GameObject settingsResetPopup;

    private void Start()
    {
        settingsResetPopup.SetActive(false);
        //
        if (!PlayerPrefs.HasKey("camFOV")) //if player prefs doesnt exist then make it a default value
        {
            PlayerPrefs.SetFloat("camFOV", 70);
        }
        if (!PlayerPrefs.HasKey("sensitivityX")) //if player prefs doesnt exist then make it a default value
        {
            PlayerPrefs.SetFloat("sensitivityX", defaultSensitivityValue);
        }
        if (!PlayerPrefs.HasKey("sensitivityY")) //if player prefs doesnt exist then make it a default value
        {
            PlayerPrefs.SetFloat("sensitivityY", defaultSensitivityValue);
        }
        loadSettings();//load previous save data

        invertedXToggle.onValueChanged.AddListener(SaveToggleStateinvX);//check for changes to toggle to invert the X-Axis
        invertedYToggle.onValueChanged.AddListener(SaveToggleStateinvY);//check for changes to toggle to invert the Y-Axis
    }

    void SaveToggleStateinvX(bool isOn)//save the X-Axis's toggle state
    {
        PlayerPrefs.SetInt("invertedX", isOn ? 1 : 0);
        PlayerPrefs.Save();
    }
    void SaveToggleStateinvY(bool isOn)//save the Y-Axis's toggle state
    {
        PlayerPrefs.SetInt("invertedY", isOn ? 1 : 0);
        PlayerPrefs.Save();
    }


    //settings menu
    public void adjustsensX() //adjust the sensitivity of the X-Axis (attached to slider) + print the sliders value
    {
        PlayerPrefs.SetFloat("sensitivityX", sensXSlider.value);
        sensXText.text = sensXSlider.value.ToString();
    }
    public void adjustsensY() //adjust the sensitivity of the Y-Axis (attached to slider) + print the sliders value
    {
        PlayerPrefs.SetFloat("sensitivityY", sensYSlider.value);
        sensYText.text = sensYSlider.value.ToString();
    }
    public void loadSettings() //make the sliders already in the corrct positions/toggles enabled or disabled
    {
        sensXSlider.value = PlayerPrefs.GetFloat("sensitivityX");
        sensYSlider.value = PlayerPrefs.GetFloat("sensitivityY");
        invertedXToggle.isOn = PlayerPrefs.GetInt("invertedX", 0) == 1;
        invertedYToggle.isOn = PlayerPrefs.GetInt("invertedY", 0) == 1;
        camFOVSlider.value = PlayerPrefs.GetFloat("camFOV");

    }
    public void fullScreenButton() //make the game fullscreen
    {
        Cursor.lockState = CursorLockMode.Confined;//stop cursor going off screen
        Screen.fullScreen = true;
    }
    public void windowedScreenButton() //make the game windowed
    {
        Cursor.lockState = CursorLockMode.None;//let the player move the cursor
        Screen.fullScreen = false;
    }
    public void resetToDefaultSettings() //reset everything within the settings menu
    {
        PlayerPrefs.SetFloat("masterVolumeSaveData", 1f);
        PlayerPrefs.SetFloat("musicVolumeSaveData", 1f);
        PlayerPrefs.SetFloat("SFXVolumeSaveData", 1f);
        PlayerPrefs.SetFloat("invertedX", 0);
        PlayerPrefs.SetFloat("invertedY", 0);
        PlayerPrefs.SetFloat("sensitivityX", defaultSensitivityValue);
        PlayerPrefs.SetFloat("sensitivityY", defaultSensitivityValue);
        Screen.fullScreen = true;
        PlayerPrefs.SetFloat("camFOV", 70);
        loadSettings();//reload this new save data
        //
        settingsResetPopup.SetActive(true);

    }
    public void adjustFOV() //adjust the FOV of the camera (attached to slider) + print the sliders value
    {
        PlayerPrefs.SetFloat("camFOV", camFOVSlider.value);
        FOVText.text = camFOVSlider.value.ToString();
    }
    public void OKAYButtonResetSettings()
    {
        settingsResetPopup.SetActive(false);
    }
}
