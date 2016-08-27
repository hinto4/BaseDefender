using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class BuildingClippingSystem : MonoBehaviour
{
    public Text DefensiveBuildNotationText;
    public GameObject DefensiveBuildPanel;

    void Start()
    {
        DefensiveBuildPanel.SetActive(false);
    }

    void Update()
    {
        DetectBuildingBlocks();
    }

    void DetectBuildingBlocks()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 3))
        {
            if (hit.collider.tag == "DefensiveBuildPlatform")
            {
                Debug.Log("Building");
                DefensiveBuildNotationText.text = "Press E";

                if (Input.GetButtonDown("DefensiveBuildMenu"))
                {
                    DefensiveBuildPanel.SetActive(true);
                }
            }
            else
            {
                DefensiveBuildNotationText.text = String.Empty;
                DefensiveBuildPanel.SetActive(false);
            }
        }
    }
}
