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
    private Turret _turret;

    [Tooltip("Choose button main panel.")]
    public GameObject Panel;                

    void Start()
    {
        _turret = FindObjectOfType<Turret>();
        _itemHandler = FindObjectOfType<ItemHandler>();
        _userInterface = FindObjectOfType<UserInterface>();
        _buttonDefaultColor = this.transform.GetComponent<Image>().color;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _itemHandler.GetClickedGameObject(this.transform.gameObject);

        _userInterface.PanelManager(Panel);
        _userInterface.ShowItemStats(this.transform.gameObject, false, _turret);

        this.transform.GetComponent<Image>().color = _buttonDefaultColor;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _userInterface.ShowItemStats(this.transform.gameObject,true, _turret);

        this.transform.GetComponent<Image>().color = new Color(97f, 142f, 231f, 255f);      // temporary
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _userInterface.ShowItemStats(this.transform.gameObject, false,_turret);

        this.transform.GetComponent<Image>().color = _buttonDefaultColor;
    }
}
