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

    public void LoadNextScene()
    {
        SceneManager.LoadScene(++_currentSceneIndex);
    }

    public void StartGameFormFirstLevel()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void LoseScreen()
    {
        SceneManager.LoadScene("LoseScreen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
