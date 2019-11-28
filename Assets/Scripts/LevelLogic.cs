using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLogic : MonoBehaviour
{ 
    private int _numberOfAttacker = 0;
    private bool _levelTimerFinished = false;

    private void Awake()
    {
        FindObjectOfType<GameTimerSlider>().OnTimesOut += LevelEnded;
    }

    private void CountAliveAttackers()
    {
        _numberOfAttacker++;
    }

    private void DecreaseAttackerCount()
    {
        _numberOfAttacker--;

        if (_numberOfAttacker <= 0 && _levelTimerFinished)
            Debug.Log("END LEVEL PLS");
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
