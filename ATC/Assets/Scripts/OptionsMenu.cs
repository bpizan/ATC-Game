using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.Rendering;

public class OptionsMenu : MonoBehaviour
{


    [Header("Audio")]
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider masterVolumeSlider;
    [SerializeField] Slider musicVolumeSlider;
    [SerializeField] Slider sfxVolumeSlider;


    [Header("Resolution")]
    [SerializeField] TMP_Dropdown resDropdown;
    Resolution[] resolutions;
    [SerializeField] Toggle fullscreenToggle;

    [SerializeField] Canvas canvas;
    void Start()
    {
        masterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume");
        musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        sfxVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        GetResolutionOptions();
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

    /*void GetResolutionOptions(){
        resolutions = Screen.resolutions;
        resDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
    {
        string option = resolutions[i].width + " x " + resolutions[i].height;
        options.Add(option);

        // Check if the current iteration is the screen's current resolution
        if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
        {
            currentResIndex = i;
        }
    }
        resDropdown.AddOptions(options);
        resDropdown.value = currentResIndex;
        resDropdown.RefreshShownValue();
    }*/

    void GetResolutionOptions(){
        resDropdown.ClearOptions();
        resolutions = Screen.resolutions;
        for(int i = 0; i < resolutions.Length; i++){
            TMP_Dropdown.OptionData newOption;
            newOption = new TMP_Dropdown.OptionData(resolutions[i].width + " x " + resolutions[i].height);
            resDropdown.options.Add(newOption);
        }
    }

    public void SetResolution(){
        Screen.SetResolution(resolutions[resDropdown.value].width, resolutions[resDropdown.value].height, fullscreenToggle.isOn);
    }

    public void OpenOptionsMenu(){
        Debug.Log("Opening Options Menu");
        canvas.enabled = true;
        DeseelectCurrentUI();
    }

    public void CloseOptionsMenu(){
        Debug.Log("Closing Options Menu");
        canvas.enabled = false;
        DeseelectCurrentUI();
    }

    private void DeseelectCurrentUI(){
        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(null);
    }
}
