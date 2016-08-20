using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemHandler : MonoBehaviour
{
    public GameObject[] Items;
    public GameObject ItemInformationPanelUI;
    public Text ItemName;
    public Text ItemSpecs;
    public Text ItemDescription;

    private GameObject _clickedGameObject;
    private GameObject _gameObject;

    void Start()
    {
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

    public void SpawnGameObject()
    {
        if (_gameObject != null)
        {
            Debug.Log("Spawning " + _gameObject.name);
            Instantiate(_gameObject, Vector3.zero, Quaternion.identity);
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
