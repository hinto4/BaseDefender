using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ObjectsInteraction : MonoBehaviour
{
    public Text InteractionText;

    private UserInterface _userInterface;
    private readonly List<String> _interactableObjectsTagList;          // Stores tags which should enable Interactable Text.

    public ObjectsInteraction()
    {
        _interactableObjectsTagList = new List<string>();
    }

    void Start()
    {
        _interactableObjectsTagList.Add("DefensiveBuildPlatform");

        _userInterface = GameObject.FindObjectOfType<UserInterface>();
    }

    void Update ()
    {
        DetectInteractableObjects();
    }

    void DetectInteractableObjects()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 3))
        {
            foreach (var tag in _interactableObjectsTagList)
            {
                if (hit.collider.tag == tag && !_userInterface.IsPanelActive)
                {
                    InteractionText.text = "Press E";
                }
                if (_userInterface.IsPanelActive)
                    InteractionText.text = String.Empty;
            }
        }
        else
        {
            InteractionText.text = String.Empty;
        }
    }
}
