using System;
using UnityEngine;
using System.Collections;
using System.Net.Mime;
using UnityEngine.UI;

public class BuildingSystem : MonoBehaviour
{
    public bool IsBuildingToolEquipt;
    public Text BuildingSystemText;

    public GameObject BuildingNotation;
    public GameObject BuildingBlock;

    //private GameObject _buildingNotationOriginal;

    void Start()
    {
        BuildingNotation.SetActive(false);
        //_buildingNotationOriginal = BuildingNotation.transform.gameObject;
    }

    void Update()
    {
        if (IsBuildingToolEquipt)
        {
            Build();
        }
        else
        {
            BuildingSystemText.text = String.Empty;
            BuildingNotation.SetActive(false);
        }
    }

    void Build()
    {
        BuildingSystemText.text = "BuildingSystem Active";
        BuildingNotation.SetActive(true);

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(BuildingBlock,
                new Vector3(BuildingNotation.transform.position.x, BuildingNotation.transform.position.y,
                    BuildingNotation.transform.position.z), BuildingNotation.transform.rotation);
        }

        // Mouse scale object system

        //    if (Input.GetButton("Fire1"))
        //    {
        //        TransformBuildingNotationScale();
        //    }
        //    else if (Input.GetButtonUp("Fire1"))
        //    {
        //        GameObject b = Instantiate(BuildingBlock,
        //            new Vector3(BuildingNotation.transform.position.x, BuildingNotation.transform.position.y,
        //                BuildingNotation.transform.position.z), BuildingNotation.transform.rotation) as GameObject;
        //        b.transform.localScale = BuildingNotation.transform.localScale;

        //        BuildingNotation.transform.localScale = new Vector3(1, 1, 1);
        //    }
        //}

        //void TransformBuildingNotationScale()
        //{
        //    if (Input.GetAxis("Mouse Y") > 0)
        //    {
        //        BuildingNotation.transform.localScale += new Vector3(0, 0.1f, 0);
        //    }
        //    if (Input.GetAxis("Mouse Y") < 0)
        //    {
        //        BuildingNotation.transform.localScale -= new Vector3(0, 0.1f, 0);
        //    }
        //    if (Input.GetAxis("Mouse X") > 0)
        //    {
        //        BuildingNotation.transform.localScale -= new Vector3(0.1f, 0, 0);
        //    }
        //    if (Input.GetAxis("Mouse X") < 0)
        //    {
        //        BuildingNotation.transform.localScale += new Vector3(0.1f, 0, 0);
        //    }
        //}
    }
}
