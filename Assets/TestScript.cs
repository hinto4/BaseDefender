using UnityEngine;
using System.Collections;

public class TestScript : MonoBehaviour
{
    private float smooth = 20f;
    private float _registeredMouseMovement;

    void Update ()
    {
        if (Input.GetKey(KeyCode.R))                 // Temporary key, later changed for real Input.
        {
            Debug.Log("Rotation object");
            if (Input.GetAxis("Mouse X") < 0)       // Mouse movement left
            {
                _registeredMouseMovement++;
            }
            if (Input.GetAxis("Mouse X") > 0)       // Mouse movement right
            {
                _registeredMouseMovement--;
            }
            transform.rotation =
                Quaternion.Slerp(transform.rotation,
                Quaternion.Euler(0f, _registeredMouseMovement, 0f),
                Time.deltaTime * smooth);
        }
    }
}
