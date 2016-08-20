using UnityEngine;
using System.Collections;

public class PlaceSpawnedObject : MonoBehaviour
{
    private GameObject Item;

    void Update()
    {
        if (Item != null)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 5))
            {
                Item.transform.position = hit.point;
            }
            if (Input.GetMouseButtonDown(0))
            {
                Item = new GameObject();
            }
        }
    }

    public void PlaceItem(GameObject item)
    {
        GameObject spawnedItem = Instantiate(item, this.transform.position, Quaternion.identity) as GameObject;
        Item = spawnedItem;
    }
}
