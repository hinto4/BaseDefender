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

    public override void SpawnItem(Animator animator)
    {
        base.SpawnItem(_animator);
    }
}
