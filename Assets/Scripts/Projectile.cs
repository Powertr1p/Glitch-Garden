using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _projectileSpeed = 10f;

    private void Update()
    {
        transform.Translate(Vector3.right * _projectileSpeed * Time.deltaTime);
    }
}
