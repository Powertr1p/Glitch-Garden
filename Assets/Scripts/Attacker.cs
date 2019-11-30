using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Attacker : MonoBehaviour
{
    public UnityAction OnSpawn;
    public UnityAction OnDeath;

    private float _currentSpeed = 1.25f;
    private GameObject _currentTarget;

    private void Start()
    {
        OnSpawn?.Invoke();
    }

    private void Update()
    {
        transform.Translate(Vector2.left * _currentSpeed *Time.deltaTime);
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (!_currentTarget)
            GetComponent<Animator>().SetBool("isAttacking", false);
    }

    public void SetMovementSpeed(float _speed)
    {
        _currentSpeed = _speed;
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("isAttacking", true);
        _currentTarget = target;
    }

    public void StrikeCurrentTarget(float damage)
    {
        if (!_currentTarget)
            return;

        Health health = _currentTarget.GetComponent<Health>();

        if (health)
            health.ApplyDamage(damage);
    }

    private void OnDestroy()
    {
            OnDeath?.Invoke();
    }
}
