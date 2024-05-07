using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class OptionsMenu : MonoBehaviour
{


    [Header("Aiudio")]
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider masterVolumeSlider;
    [SerializeField] Slider musicVolumeSlider;
    [SerializeField] Slider sfxVolumeSlider;
    [SerializeField] Canvas canvas;
    void Start()
    {
        masterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume");
        musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        sfxVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolume");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMasterVolume(){
        audioMixer.SetFloat("MasterVolume", ConvertToDec(masterVolumeSlider.value));
        PlayerPrefs.SetFloat("MasterVolume", masterVolumeSlider.value);
    }

    public void SetMusicVolume(){
        audioMixer.SetFloat("MusicVolume", ConvertToDec(musicVolumeSlider.value));
        PlayerPrefs.SetFloat("MusicVolume", musicVolumeSlider.value);
    }

    public void SetSFXVolume(){
        audioMixer.SetFloat("SFXVolume", ConvertToDec(sfxVolumeSlider.value));
        PlayerPrefs.SetFloat("SFXVolume", sfxVolumeSlider.value);
    }

    float ConvertToDec(float sliderValue){
        return Mathf.Log10(Mathf.Max(sliderValue, 0.0001f)) * 20;
    }
    public void OpenOptionsMenu(){
        Debug.Log("Opening Options Menu");
        canvas.enabled = true;
    }

    public void CloseOptionsMenu(){
        Debug.Log("Closing Options Menu");
        canvas.enabled = false;
    }
}
