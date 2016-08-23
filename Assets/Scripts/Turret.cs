using UnityEngine;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine.Networking;

public class Turret : WeaponType
{
    public override void SpawnItem(Animator animator)
    {
        animator.SetTrigger("Spawn");
    }
}
