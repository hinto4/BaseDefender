using System;
using UnityEngine;
using System.Collections;
using System.Security.Cryptography;

public class Wall : BuildingsType
{
    private GameObject _point1;
    private GameObject _point2;
    private PlaceSpawnedObject _placeSpawnedObject;

    private float _xPos;
    private float _yPos;
    private float _xCenterMovementPos;

    void Start()
    {
        _placeSpawnedObject = FindObjectOfType<PlaceSpawnedObject>();
        DetectBoxColliderSides();

        Debug.Log(_xPos);
        Debug.Log(_yPos);
    }

    void DetectBoxColliderSides()
    {
        _xCenterMovementPos = Mathf.Abs(this.GetComponent<BoxCollider>().center.x);                  // If collider has changed center Position, use it to subtract from it's position to get center.

        _xPos = this.GetComponent<BoxCollider>().size.x / 2;                                   // Get the end points of the collider.
        _yPos = this.GetComponent<BoxCollider>().size.y / 2;                                   // Get the end points of the collider.

        _point1 = Instantiate(new GameObject(), this.transform.position, Quaternion.identity) as GameObject;
        _point2 = Instantiate(new GameObject(), this.transform.position, Quaternion.identity) as GameObject;

        if (_point1 != null && _point2 != null)
        {
            _point1.name = "Point_1";
            _point2.name = "Point_2";
            _point1.tag = "Clip";
            _point2.tag = "Clip";

            _point1.transform.parent = this.transform;
            _point2.transform.parent = this.transform;

            _point1.transform.localPosition = new Vector3(_xPos - _xCenterMovementPos, 0, 0);
            _point2.transform.localPosition = new Vector3(-_xPos - _xCenterMovementPos, 0, 0);

            _point1.AddComponent<Rigidbody>();
            _point1.AddComponent<SphereCollider>();
            _point1.GetComponent<SphereCollider>().radius = 0.10f;
            _point1.AddComponent<ClippingDetector>();
            _point1.GetComponent<Rigidbody>().isKinematic = true;
            _point1.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            _point1.GetComponent<SphereCollider>().isTrigger = true;

            _point2.AddComponent<Rigidbody>();
            _point2.AddComponent<SphereCollider>();
            _point2.AddComponent<ClippingDetector>();
            _point2.GetComponent<Rigidbody>().isKinematic = true;
            _point2.GetComponent<SphereCollider>().radius = 0.10f;
            _point2.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            _point1.GetComponent<SphereCollider>().isTrigger = true;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5F);

        if (_point1 != null && _point2 != null)
        {
            Gizmos.DrawSphere(_point1.transform.position, 0.2f);
            Gizmos.DrawSphere(_point2.transform.position, 0.2f);
        }
    }

    public override void SpawnItem(Animator animator)
    {
        animator.SetTrigger("Spawn");
    }
}
