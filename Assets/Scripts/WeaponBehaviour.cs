using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponBehaviour : MonoBehaviour
{
    private GameObject _weapon;
    private Vector3 _startWeaponPostion;
    private Vector3 _ironSightPosition;
    private float _startTime;
    private float _journeyLengthToIronSight;
    private Camera _mainCamera;
    private FirstPersonController _firstPersonController;

    public float FieldOfView = 60f; // Default 60f

    void Start()
    {
        _mainCamera = FindObjectOfType<Camera>();
        _startWeaponPostion = this.transform.localPosition;
        _ironSightPosition = new Vector3(-0f, -0.307f, 0.799f);
        _startTime = Time.deltaTime;
        _journeyLengthToIronSight = Vector3.Distance(_startWeaponPostion, _ironSightPosition);
        _firstPersonController = GameObject.FindObjectOfType<FirstPersonController>();
    }

    void Update()
    {
        IronSight();
    }

    //TODO Improve IronSight system. Currently broken. Refactor smooth movement, fix mouseUp.
    private void IronSight()
    {
        if (Input.GetButton("Fire2"))
        {
            float distanceCovered = (Time.time - _startTime)*1.2f;
            float fracJourney = distanceCovered/_journeyLengthToIronSight;
            transform.localPosition = Vector3.Lerp(_startWeaponPostion, _ironSightPosition, fracJourney);

            _mainCamera.fieldOfView = FieldOfView - 40f;
            _firstPersonController.SetMouseLookSensitivity(0.2f, 0.2f);
        }
        else if (Input.GetButtonUp("Fire2"))
        {
            float distanceCovered = (Time.time - _startTime) * 1.2f;
            float fracJourney = distanceCovered / _journeyLengthToIronSight;

            transform.localPosition = Vector3.Lerp(_ironSightPosition, _startWeaponPostion, fracJourney);
            Debug.Log("Fire2 released");

            _mainCamera.fieldOfView = FieldOfView;
            _firstPersonController.SetMouseLookSensitivity(2, 2);
        }
    }
}
