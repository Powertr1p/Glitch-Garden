using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject _projectile;
    [SerializeField] private Transform _gunPosition;

   public void Shoot()
   {
        Instantiate(_projectile, _gunPosition.transform.position, transform.rotation);
   }
}
