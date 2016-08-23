using UnityEngine;
using System.Collections;

public interface IStructures
{
    string ItemName { get; set; }
    string ItemDescription { get; set; }

    void SpawnItem(Animator animator);
}
