using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Projectile _projectile;
    [SerializeField] private GameObject _gun;
    private Animator _animator;

    private AttackerSpawner _myLaneSpawner;

    private GameObject _projectileParent;
    private const string _PROJECTILE_PARENT_NAME = "Projectiles";

    private void Start()
    {
        _animator = GetComponent<Animator>();
        SetLaneSpawner();
        CreatePaprentProjectile();
    }

    private void CreatePaprentProjectile()
    {
        _projectileParent = GameObject.Find(_PROJECTILE_PARENT_NAME);
        if (!_projectileParent)
            _projectileParent = new GameObject(_PROJECTILE_PARENT_NAME);
    }

    private void Update()
    {
        if (IsAttackerInLane())
            _animator.SetBool("isAttacking", true);
        else
            _animator.SetBool("isAttacking", false);
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        foreach(AttackerSpawner spawner in spawners)
        {
            bool isCloseEnough = (Mathf.Abs(Mathf.RoundToInt(spawner.transform.position.y) - transform.position.y) <= Mathf.Epsilon);

            if (isCloseEnough)
                _myLaneSpawner = spawner;
        }
    }

    private bool IsAttackerInLane()
    {
        if (_myLaneSpawner.transform.childCount <= 0)
            return false;
        else
            return true;
    }

    public void Shoot()
   {
        Projectile newProjectile = Instantiate(_projectile, _gun.transform.position, transform.rotation)as Projectile;
        newProjectile.transform.parent = _projectileParent.transform;
   }
}
