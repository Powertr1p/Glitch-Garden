using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    private const string _MASTER_VOLUME_KEY = "master volume";
    private const string _DIFFICULTY_KEY = "difficulty";

    private const float _MIN_VOLUME = 0f;
    private const float _MAX_VOLUME = 1f;

    public static void SetMasterVolume (float volume)
    {
        if (volume >= _MIN_VOLUME && volume <= _MAX_VOLUME)
            PlayerPrefs.SetFloat(_MASTER_VOLUME_KEY, volume);
        else
            Debug.LogError("Master volume is out of range");
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(_MASTER_VOLUME_KEY);
    }
}
