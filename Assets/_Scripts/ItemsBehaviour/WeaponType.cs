using UnityEngine;
using System.Collections;

public abstract class WeaponType : MonoBehaviour, IStructures
{
    public float Damage;
    public float Health;
    public string itemName;
    public string itemDescription;

    public string ItemName
    {
        set { this.ItemName = itemName; }
        get { return itemName; }
    }

    public string ItemDescription
    {
        set { this.ItemDescription = itemDescription; }
        get { return DisplayItemSpecs() + itemDescription; }
    }

    string DisplayItemSpecs()
    {
        string ItemSpecs = "\n Damage - " + Damage + "\n Health - " + Health + "\n\n";
        return ItemSpecs;
    }

    public abstract void SpawnItem(Animator animator);
}
