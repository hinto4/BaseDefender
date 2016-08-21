using UnityEngine;
using System.Collections;

public class PlaceSpawnedObject : MonoBehaviour
{
    private GameObject Item;

    void Update()
    {
        if (Item != null)
        {
            //TODO if objectPlacing is active, change shader opacity, if ray distance is > 5 change object shader to red, otherwise green.
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
