using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _health = 100f;
    [SerializeField] private GameObject _deathVFX;

    public void ApplyDamage(float damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            TriggerDeathVFX();
            Destroy(gameObject);
        }
    }

    private void TriggerDeathVFX()
    {
        if(!_deathVFX) { return; }
        GameObject deathEffects = Instantiate(_deathVFX, transform.position, transform.rotation);
        Destroy(deathEffects, 1f);
    }
}
