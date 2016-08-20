using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class ItemHandler : MonoBehaviour
{
    public GameObject[] Items;
    public GameObject ItemInformationPanelUI;
    public Text ItemName;
    public Text ItemSpecs;
    public Text ItemDescription;

    private GameObject _player;
    private GameObject _clickedGameObject;
    private GameObject _gameObject;
    private PlaceSpawnedObject _placeSpawnedObject;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _placeSpawnedObject = GameObject.FindObjectOfType<PlaceSpawnedObject>();

        ItemInformationPanelUI.SetActive(false);
    }

    void Update()
    {
        if (ItemInformationPanelUI.activeInHierarchy)
        {
            ItemInformationPanelUI.transform.position = Input.mousePosition;
        }
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

    public void ShowItemStats(GameObject item, bool showPanel)
    {
        if (item == null)
            throw new NullReferenceException();

        if(showPanel)
            ItemInformationPanelUI.SetActive(true);
        else
            ItemInformationPanelUI.SetActive(false);

        GameObject gameObjectFromTag = ReturnGameObjectFromTag(item);

        //TODO Make this more dynamic, to work with different Types.
        ItemName.text = gameObjectFromTag.GetComponent<Turret>().WeaponName;
        ItemSpecs.text = "Damage " + gameObjectFromTag.GetComponent<Turret>().Damage + "\n Health " 
            + gameObjectFromTag.GetComponent<Turret>().Health;
        ItemDescription.text = gameObjectFromTag.GetComponent<Turret>().WeaponDescription;
    }

    public GameObject ReturnGameObjectFromTag(GameObject item)
    {
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
