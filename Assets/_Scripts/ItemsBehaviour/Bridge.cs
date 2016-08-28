using UnityEngine;
using System.Collections;

public class Bridge : MonoBehaviour
{
    private PlaceSpawnedObject _placeSpawnedObject;

    void Start ()
    {
        _placeSpawnedObject = GameObject.FindObjectOfType<PlaceSpawnedObject>();
        _placeSpawnedObject.PlaceObjectDetectRange = 6f;
    }
}
