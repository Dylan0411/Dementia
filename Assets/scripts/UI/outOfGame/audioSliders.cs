using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class audioSliders : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider masterVolumeSlider;
    public Slider SFXVolumeSlider;
    public Slider musicVolumeSlider;

    float defaultVolume = 1.0f;

    void Start() // Attach listeners once at the beginning
    {
        // Add listeners ONCE instead of every frame
        masterVolumeSlider.onValueChanged.AddListener(SetMasterVolume);
        musicVolumeSlider.onValueChanged.AddListener(SetMusicVolume);
        SFXVolumeSlider.onValueChanged.AddListener(SetSFXVolume);

        // Load saved values ONCE in Start()
        masterVolumeSlider.value = PlayerPrefs.GetFloat("masterVolumeSaveData", defaultVolume);
        musicVolumeSlider.value = PlayerPrefs.GetFloat("musicVolumeSaveData", defaultVolume);
        SFXVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolumeSaveData", defaultVolume);
    }

    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("masterVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("masterVolumeSaveData", volume);
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("musicVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicVolumeSaveData", volume);
    }

    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFXVolumeSaveData", volume);
    }
}