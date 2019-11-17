using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _lizard;
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
        Instantiate(_lizard, transform.position, Quaternion.identity);
    }

}
