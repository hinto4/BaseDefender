using UnityEngine;
using System.Collections;

public abstract class BuildStructures : MonoBehaviour
{
    public float Damage;
    public float Health;
    public string ItemName;
    public string ItemSpecs;
    public string ItemDescription;

    public abstract void Shoot();
}
