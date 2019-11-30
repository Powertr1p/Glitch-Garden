using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLogic : MonoBehaviour
{
    [SerializeField] GameObject _winLabel;
    [SerializeField] float _waitToLoad = 5f;

    private int _numberOfAttacker = 0;
    private bool _levelTimerFinished = false;



    private void Awake()
    {
        FindObjectOfType<GameTimerSlider>().OnTimesOut += LevelEnded;
        _winLabel.SetActive(false);
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


}
