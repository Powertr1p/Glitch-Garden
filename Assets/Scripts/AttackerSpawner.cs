﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] private Attacker[] _attackersPrefabs;
    [SerializeField] private float _minSpawnDelay = 1f;
    [SerializeField] private float _maxSpawnDelay = 5f;

    private bool _spawn = true;

    private IEnumerator Start()
    {
        while (_spawn)
        {
           yield return new WaitForSeconds(Random.Range(_minSpawnDelay, _maxSpawnDelay));
           SpawnAttacker();
        }
    }

    private void SpawnAttacker()
    {
        Attacker newAttacker = Instantiate(PickAttacker(), transform.position, transform.rotation) as Attacker;
        newAttacker.transform.parent = transform;
        FindObjectOfType<LevelLogic>().AddListenersToNewAttacker(newAttacker);
    }

    private Attacker PickAttacker()
    {
        return _attackersPrefabs[Random.Range(0, _attackersPrefabs.Length)];
    }

}
