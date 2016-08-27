using System;
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DefensiveSystem : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        throw new NotImplementedException();
    }

    //public GameObject DefensiveBuildPlatform;
    //public GameObject Turret;

    //private BuildMenuUI _buildMenuUi;
    //private GameObject _spawnedTurret;
    //private bool _spawningTurret;
    //private float _startTime;
    //private float _journeyLengthToTop;

    //void Start()
    //{

    //    _journeyLengthToTop = Vector3.Distance(DefensiveBuildPlatform.transform.position, 
    //        new Vector3(DefensiveBuildPlatform.transform.position.x,
    //        DefensiveBuildPlatform.transform.position.y - 1.5f, DefensiveBuildPlatform.transform.position.z));

    //    _startTime = Time.deltaTime;
    //    _buildMenuUi = GameObject.FindObjectOfType<BuildMenuUI>();
    //}

    //void Update()
    //{
    //    if (_spawningTurret)
    //    {
    //        float distanceCovered = (Time.time - _startTime) * 0.1f * Time.deltaTime;
    //        float fracJourney = distanceCovered / _journeyLengthToTop;

    //        _spawnedTurret.transform.localPosition = Vector3.Lerp(_spawnedTurret.transform.position, 
    //            new Vector3(DefensiveBuildPlatform.transform.position.x, 
    //            DefensiveBuildPlatform.transform.position.y - 0.2f, DefensiveBuildPlatform.transform.position.z), fracJourney);
    //    }
    //    else
    //    {
    //        Debug.Log("Nothing has spawned.");
    //    }
    //}

    //public void SpawnTurret()
    //{
    //    _buildMenuUi.PanelManager(_buildMenuUi.DefensiveBuildPanel);
    //    Debug.Log("Instantiate object. ");

    //    GameObject spawnTurret = Instantiate(Turret, 
    //        DefensiveBuildPlatform.transform.position, Quaternion.identity) as GameObject;

    //    if (spawnTurret != null)
    //    {
    //        spawnTurret.transform.position = new Vector3(DefensiveBuildPlatform.transform.position.x, 
    //            -2, DefensiveBuildPlatform.transform.position.z);

    //        _spawnedTurret = spawnTurret;
    //    }
    //    _spawningTurret = true;
    //}

}
