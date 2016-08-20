using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemHandler : MonoBehaviour
{
    public GameObject[] Items;
    public GameObject ItemInformationPanelUI;

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
            //TODO TEMP solution. Later calculate position for informationPanel hover through screen witdh/height.
            ItemInformationPanelUI.transform.position = new Vector2(Input.mousePosition.x + 110f,
                Input.mousePosition.y + -150f);
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

        Text textObject = ItemInformationPanelUI.GetComponentInChildren<Text>();

        GameObject gameObjectFromTag = ReturnGameObjectFromTag(item);

        textObject.text = "Damage - " + gameObjectFromTag.GetComponent<Turret>().Damage;
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
