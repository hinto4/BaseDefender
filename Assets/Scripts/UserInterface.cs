using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class UserInterface : MonoBehaviour
{
    public GameObject DefensiveBuildPanel;
    public GameObject BuildMenuPanel;
    public bool IsPanelActive;

    private FirstPersonController _firstPersonController;

    void Start()
    {
        BuildMenuPanel.SetActive(false);
        DefensiveBuildPanel.SetActive(false);

        _firstPersonController = GameObject.FindObjectOfType<FirstPersonController>();
    }

    void Update()
    {
        BuildMenu();
    }

    void BuildMenu()
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

    public void PanelManager(GameObject panelName)  // Disables or enables panel.
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
}
