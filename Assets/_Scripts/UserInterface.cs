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
    public Text WarningText;

    public bool IsPanelActive;

    private FirstPersonController _firstPersonController;
    private ItemHandler _itemHandler;
    private EquipmentManager _equipmentManager;

    void Start()
    {
        BuildMenuPanel.SetActive(false);
        DefensiveBuildPanel.SetActive(false);
        ItemInformationPanel.SetActive(false);

        _itemHandler = FindObjectOfType<ItemHandler>();
        _firstPersonController = GameObject.FindObjectOfType<FirstPersonController>();
        _equipmentManager = GameObject.FindObjectOfType<EquipmentManager>();
    }

    void Update()
    {
        BuildMenu();
        SetWarningText();
        EnableUiFollowMouse(ItemInformationPanel);
    }

    void BuildMenu()                                                // Enable interface panel when player presses button.
    {
        if (Input.GetButtonDown("BuildMenu") && _equipmentManager.HandsModeActive)
        {
            PanelManager(BuildMenuPanel);
        }
        if (Input.GetButtonDown("InteractionButton") && _equipmentManager.HandsModeActive)
        {
            PanelManager(DefensiveBuildPanel);
        }
        else if (!_equipmentManager.HandsModeActive)
        {
            
        }
    }

    void SetWarningText()
    {
        string warningText = "Warning: Please un-equipt your weapon before building.";

        if (!_equipmentManager.HandsModeActive && Input.GetButtonDown("BuildMenu"))
        {
            WarningText.text = warningText;
            Invoke("ClearWarningText", 2f);
        }
        if (!_equipmentManager.HandsModeActive && Input.GetButtonDown("InteractionButton"))
        {
            WarningText.text = warningText;
            Invoke("ClearWarningText", 2f);
        }
        else if(_equipmentManager.HandsModeActive)
        {
            WarningText.text = String.Empty;
        }
    }

    void ClearWarningText()
    {
        WarningText.text = String.Empty;
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
                ItemInformationPanel.SetActive(false);              // Disable item hover panel.
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

    public void ShowItemStats(GameObject item, bool showPanel, IStructures structureType)      // Print item stats on the UI Panel.
    {
        if (item == null)
            throw new NullReferenceException();

        if (showPanel)
            ItemInformationPanel.SetActive(true);
        else
            ItemInformationPanel.SetActive(false);

        GameObject gameObjectFromTag = _itemHandler.ReturnGameObjectFromTag(item);

        ItemName.text = gameObjectFromTag.GetComponent<IStructures>().ItemName;
        ItemDescription.text = gameObjectFromTag.GetComponent<IStructures>().ItemDescription;
    }
}
