using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0f, 5f)]
    private float _currentSpeed = 1.25f;

    private void Update()
    {
        transform.Translate(Vector2.left * _currentSpeed *Time.deltaTime);
    }

    public void SetMovementSpeed(float _speed)
    {
        _currentSpeed = _speed;
    }
}
