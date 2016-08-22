using UnityEngine;
using System.Collections;
using System.Linq.Expressions;
using UnityEngine.Networking;

public class PlaceSpawnedObject : MonoBehaviour
{
    private GameObject _item;

    private float smooth = 20f;
    private float _registeredMouseMovement;
    private bool _gameObjectRotationEnabled;

    void Update()
    {
        if (_item != null)
        {
            //TODO if objectPlacing is active, change shader opacity, if ray distance is > 5 change object shader to red, otherwise green.
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 5))
            {
                if (!_gameObjectRotationEnabled)                // _gameObjectRotation is enabled while holding down R to rotate. Disable object movment.
                {
                    _item.transform.position = hit.point;
                }
            }
            //TODO make dedicated method for objects rotation, include fps camera lock while rotating.
            if (Input.GetKey(KeyCode.R)) // Temporary key, later changed for real Input. Enables GameObject rotation.
            {
                _gameObjectRotationEnabled = true;                          
                Debug.Log("Rotation object");                   
                if (Input.GetAxis("Mouse X") < 0)               // Mouse movement left
                {
                    _registeredMouseMovement++;
                }
                if (Input.GetAxis("Mouse X") > 0)               // Mouse movement right
                {
                    _registeredMouseMovement--;
                }
                _item.transform.rotation =
                    Quaternion.Slerp(transform.rotation,
                        Quaternion.Euler(0f, _registeredMouseMovement, 0f),
                        Time.deltaTime*smooth);
            }
            else
            {
                _gameObjectRotationEnabled = false;
            }
            if (Input.GetMouseButtonDown(0))
            {
                //_item.GetComponent<BuildStructureHandler>().StartBuilding(_item);       // Start building progress.
                _item.GetComponent<Turret>().SpawnItem();

                _item = new GameObject();                                               // After placing instantiated object, set Item to null (Makes empty gameobject).
                DestroyObject(_item, 2f);                                               // Destroy empty gameObject after 2 seconds.
                _registeredMouseMovement = 0;                                           // Reset mouse registered movement.
            }
            else if (Input.GetMouseButtonDown(1))
            {
                DestroyObject(_item);                                                   // Disable the placingItem.
            }
        }
    }

    public void PlaceItem(GameObject item)
    {
        GameObject spawnedItem = Instantiate(item, this.transform.position, Quaternion.identity) as GameObject;
        _item = spawnedItem;
    }
}
