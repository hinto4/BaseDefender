using System;
using UnityEngine;
using UnityEngine.UI;

public class ItemHandler : MonoBehaviour
{
    public GameObject[] Items;

    private GameObject _clickedGameObject;
    private GameObject _gameObject;
    private PlaceSpawnedObject _placeSpawnedObject;

    void Start()
    {
        _placeSpawnedObject = GameObject.FindObjectOfType<PlaceSpawnedObject>();
    }

    public void GetClickedGameObject(GameObject item)
    {
        ReturnGameObjectFromTag(item);
        SpawnGameObject();
    }

    void SpawnGameObject()
    {
        if (_gameObject != null)
        {
            _placeSpawnedObject.PlaceItem(_gameObject);
        }
    }

    public GameObject ReturnGameObjectFromTag(GameObject item)      // Associates object tag with gameobject tag and returns gameobject.  
    {                                                               // Used for 2d sprite buttons, to get their gameObjects and link them.
        if (item == null)
            throw new NullReferenceException();

        foreach (var itemName in Items)
        {
            if (itemName.tag == item.tag)
            {
                _gameObject = itemName.gameObject;
            }
        }
        return _gameObject;
    }
}
