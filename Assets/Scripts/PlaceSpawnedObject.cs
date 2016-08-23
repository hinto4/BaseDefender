using UnityEngine;
using System.Collections;
using System.Linq.Expressions;
using UnityEngine.Networking;
using UnityStandardAssets.Characters.FirstPerson;

public class PlaceSpawnedObject : MonoBehaviour
{
    private GameObject _item;

    private float _rotationSpeed = 200f;
    private float _registeredMouseMovement;
    private bool _gameObjectRotationEnabled;

    //TODO Make seperate class for locking and enabling the camera.
    private FirstPersonController _firstPersonController;       // temp

    void Start()
    {
        _firstPersonController = GameObject.FindObjectOfType<FirstPersonController>();
    }

    private float movementTest;
    void Update()
    {
        if (_item != null)
        {
            //TODO if objectPlacing is active, change shader opacity, if ray distance is > 5 change object shader to red, otherwise green.
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 10))
            {
                if (!_gameObjectRotationEnabled)                                        // _gameObjectRotation is enabled while holding down R to rotate. Disable object movment.
                {
                    _item.transform.position = hit.point;

                }
            }
            //TODO make dedicated method for objects rotation, include fps camera lock while rotating.
            if (Input.GetKey(KeyCode.R))                                                // Temporary key, later changed for real Input. Enables GameObject rotation.
            {
                _gameObjectRotationEnabled = true;  
                _firstPersonController.SetMouseLookSensitivity(0,0);                    // Disable fps controller camera movement.                       
                Debug.Log("Rotation object");                   
                if (Input.GetAxis("Mouse X") < 0)                                       // Mouse movement left
                {
                    Debug.Log(Input.GetAxis("Mouse X"));
                    _registeredMouseMovement++;
                }
                if (Input.GetAxis("Mouse X") > 0)                                       // Mouse movement right
                {
                    Debug.Log(Input.GetAxis("Mouse X"));
                    _registeredMouseMovement--;
                }
                _item.transform.rotation =
                    Quaternion.Slerp(transform.rotation,
                    Quaternion.Euler(0f, _registeredMouseMovement, 0f),
                    Time.deltaTime*_rotationSpeed);
            }
            else if(Input.GetKeyUp(KeyCode.R))
            {
                _gameObjectRotationEnabled = false;
                _firstPersonController.SetMouseLookSensitivity(1f, 1f);                 // Enable fps controller camera movement
            }
            if (Input.GetMouseButtonDown(0))
            {
                _item.GetComponent<IStructures>().SpawnItem(_item.GetComponent<Animator>());
                SetItemCollider(_item, true);                                           // Enables item collider.
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
        SetItemCollider(spawnedItem, false);
    }

    void SetItemCollider(GameObject item, bool value)
    {
        Collider[] spawnedItemColliders = item.transform.GetComponentsInChildren<Collider>();

        if (spawnedItemColliders != null)
        {
            foreach (var collider in spawnedItemColliders)
            {
                collider.enabled = value;
            }
        }
        else
        {
            Debug.Log("Item has no collider.");
        }
        
    }
}
