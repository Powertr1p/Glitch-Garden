using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _damage = 50f;
    [SerializeField] private float _projectileSpeed = 10f;

    private void Update()
    {
        transform.Translate(Vector3.right * _projectileSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<Health>().ApplyDamage(_damage);
    }
}
