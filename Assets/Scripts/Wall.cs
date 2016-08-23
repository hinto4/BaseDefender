using UnityEngine;
using System.Collections;

public class Wall : BuildingsType
{
   public override void SpawnItem(Animator animator)
    {
        animator.SetTrigger("Spawn");
    }
}
