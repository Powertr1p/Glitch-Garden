using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] private Slider _volumeSlider;
    [SerializeField] private float _defaultVolume = 0.5f;

    private void Start()
    {
        _volumeSlider.value = PlayerPrefsController.GetMasterVolume();
    }

    private void Update()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if (musicPlayer)
            musicPlayer.SetVolume(_volumeSlider.value);
        else
            Debug.LogWarning("No music player found");
    }

    public void SaveAndExit()
    {
        PlayerPrefsController.SetMasterVolume(_volumeSlider.value);
        FindObjectOfType<LevelLoader>().LoadMainMenu();
    }

    public void SetToDefault()
    {
        _volumeSlider.value = _defaultVolume;
    }


}
