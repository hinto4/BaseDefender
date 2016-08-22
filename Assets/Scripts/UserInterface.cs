using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class UserInterface : MonoBehaviour
{
    public GameObject DefensiveBuildPanel;
    public GameObject BuildMenuPanel;

    public GameObject ItemInformationPanel;
    public Text ItemName;
    public Text ItemDescription;

    public bool IsPanelActive;

    private FirstPersonController _firstPersonController;
    private ItemHandler _itemHandler;

    void Start()
    {
        BuildMenuPanel.SetActive(false);
        DefensiveBuildPanel.SetActive(false);
        ItemInformationPanel.SetActive(false);

        _itemHandler = FindObjectOfType<ItemHandler>();
        _firstPersonController = GameObject.FindObjectOfType<FirstPersonController>();
    }

    void Update()
    {
        BuildMenu();
        EnableUiFollowMouse(ItemInformationPanel);
    }

    void BuildMenu()                                                // Enable interface panel when player presses button.
    {
        if (Input.GetButtonDown("BuildMenu"))
        {
            PanelManager(BuildMenuPanel);
        }
        if (Input.GetButtonDown("InteractionButton"))
        {
            PanelManager(DefensiveBuildPanel);
        }
    }

    void EnableUiFollowMouse(GameObject panel)                      // Ui follow the mouse position.
    {
        if (panel.activeInHierarchy)
        {
            panel.transform.position = Input.mousePosition;
        }
    }

    public void PanelManager(GameObject panelName)                  // Disables or enables panels.
    {
        if (IsPanelActive)
        {
            if (panelName.activeInHierarchy)
            {
                panelName.SetActive(false);
            }
            IsPanelActive = false;
            _firstPersonController.SetMouseCursorLock(true);
            _firstPersonController.SetMouseLookSensitivity(1, 1);
        }
        else
        {
            panelName.SetActive(true);
            IsPanelActive = true;
            _firstPersonController.SetMouseCursorLock(false);
            _firstPersonController.SetMouseLookSensitivity(0, 0);
        }
    }

    public void ShowItemStats(GameObject item, bool showPanel)      // Print item stats on the UI Panel.
    {
        if (item == null)
            throw new NullReferenceException();

        if (showPanel)
            ItemInformationPanel.SetActive(true);
        else
            ItemInformationPanel.SetActive(false);

        GameObject gameObjectFromTag = _itemHandler.ReturnGameObjectFromTag(item);

        ItemName.text = gameObjectFromTag.GetComponent<WeaponType>().ItemName;
        ItemDescription.text = gameObjectFromTag.GetComponent<WeaponType>().ItemDescription;
    }
}
