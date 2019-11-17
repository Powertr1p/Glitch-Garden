using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject _projectile;
    [SerializeField] private GameObject _gun;

   public void Shoot()
   {
        Instantiate(_projectile, _gun.transform.position, transform.rotation);
   }
}
