﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Attacker : MonoBehaviour
{
    private float _currentSpeed = 1.25f;
    private GameObject _currentTarget;

    private void Update()
    {
        transform.Translate(Vector2.left * _currentSpeed *Time.deltaTime);
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
}
