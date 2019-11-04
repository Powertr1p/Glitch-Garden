using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private int _currentSceneIndex;
    [SerializeField] private float _timeToWaitBeforeLoad = 3f;

    private void Start()
    {
        _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (_currentSceneIndex == 0)
            StartCoroutine(WaitForTime());
    }

    private IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(_timeToWaitBeforeLoad);
        LoadNextScene();
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(++_currentSceneIndex);
    }
}
