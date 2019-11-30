﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLogic : MonoBehaviour
{
    [SerializeField] GameObject _winLabel;
    [SerializeField] GameObject _loseLabel;
    [SerializeField] float _waitToLoad = 5f;

    private int _numberOfAttacker = 0;
    private bool _levelTimerFinished = false;

    private void Awake()
    {
        Time.timeScale = 1f;

        FindObjectOfType<GameTimerSlider>().OnTimesOut += LevelEnded;
        FindObjectOfType<PlayerLivesDisplay>().OnPlayerDeath += HandleLoseCondition;

        _winLabel.SetActive(false);
        _loseLabel.SetActive(false);
    }

    private void CountAliveAttackers()
    {
        _numberOfAttacker++;
    }

    private void DecreaseAttackerCount()
    {
        _numberOfAttacker--;

        if (_numberOfAttacker <= 0 && _levelTimerFinished)
            StartCoroutine(HandleWinCondition());
    }

    private IEnumerator HandleWinCondition()
    {
        _winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(_waitToLoad);

        FindObjectOfType<LevelLoader>().LoadNextScene();
    }

    public void AddListenersToNewAttacker(Attacker attacker)
    {
        attacker.OnSpawn += CountAliveAttackers;
        attacker.OnDeath += DecreaseAttackerCount;
    }

    private void LevelEnded()
    {
        _levelTimerFinished = true;
    }

    private void HandleLoseCondition()
    {
        _loseLabel.SetActive(true);
        Time.timeScale = 0f;
    }
}
