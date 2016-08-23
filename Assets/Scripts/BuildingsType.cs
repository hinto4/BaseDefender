using UnityEngine;
using System.Collections;

public abstract class BuildingsType : MonoBehaviour, IStructures
{
    public string itemName;
    public string itemDescription;
    public float Health;

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
        string ItemSpecs = "\n Health - " + Health + "\n\n";
        return ItemSpecs;
    }

    public abstract void SpawnItem(Animator animator);
}
