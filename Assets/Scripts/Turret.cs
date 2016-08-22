using UnityEngine;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine.Networking;

public class Turret : WeaponType
{
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
        
    }

    public void SpawnItem()
    {
        _animator.SetTrigger("Spawn");
        
    }

}
