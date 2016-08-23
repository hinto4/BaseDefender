using UnityEngine;
using System.Collections;

public class StructureType : MonoBehaviour
{
    public virtual void SpawnItem(Animator animator)
    {
        animator.SetTrigger("Spawn");
    }
}
