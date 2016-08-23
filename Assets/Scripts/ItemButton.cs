using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine.EventSystems;

public class ItemButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    private ItemHandler _itemHandler;
    private UserInterface _userInterface;
    private Color _buttonDefaultColor;

    [Tooltip("Choose button main panel.")]
    public GameObject Panel;                

    void Start()
    {
        _itemHandler = FindObjectOfType<ItemHandler>();
        _userInterface = FindObjectOfType<UserInterface>();
        _buttonDefaultColor = this.transform.GetComponent<Image>().color;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _itemHandler.GetClickedGameObject(this.transform.gameObject);

        _userInterface.PanelManager(Panel);
        _userInterface.ShowItemStats(this.transform.gameObject, false);

        this.transform.GetComponent<Image>().color = _buttonDefaultColor;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Hover enter, enable panel.");
        _userInterface.ShowItemStats(this.transform.gameObject,true);

        this.transform.GetComponent<Image>().color = new Color(97f, 142f, 231f, 255f);      // temporary
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Hover exit, disable panel.");
        _userInterface.ShowItemStats(this.transform.gameObject, false);

        this.transform.GetComponent<Image>().color = _buttonDefaultColor;
    }
}
