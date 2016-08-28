using UnityEngine;
using System.Collections;

public class ClippingDetector : MonoBehaviour
{
    private PlaceSpawnedObject _placeSpawnedObject;

    void Start()
    {
        _placeSpawnedObject = FindObjectOfType<PlaceSpawnedObject>();
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log(col.gameObject);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Clip")
        {
            _placeSpawnedObject.IsClipped = true;
        }
    }
}
