using UnityEngine;
using System.Collections;

public class BuildStructureHandler : MonoBehaviour
{
    private GameObject _structureToBuild;

    public float SpawnerTime = 0.2f;

    void Update()
    {
        if (_structureToBuild != null)
        {
            _structureToBuild.transform.position += Vector3.up*Time.deltaTime* SpawnerTime;
        }   
    }

    public void StartBuilding(GameObject structure)
    {
        structure.transform.position = new Vector3(
                structure.transform.position.x,
                structure.transform.position.y - 2f,
                structure.transform.position.z);

        _structureToBuild = structure;
    }
}
