using UnityEngine;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine.EventSystems;

public class ItemButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    private ItemHandler _itemHandler;

    void Start()
    {
        _itemHandler = FindObjectOfType<ItemHandler>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _itemHandler.GetClickedGameObject(this.transform.gameObject);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Hover enter, enable panel.");
        _itemHandler.ShowItemStats(this.transform.gameObject,true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Hover exit, disable panel.");
        _itemHandler.ShowItemStats(this.transform.gameObject, false);
    }
}
