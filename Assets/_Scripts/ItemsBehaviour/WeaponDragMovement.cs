using UnityEngine;
using System.Collections;

public class WeaponDragMovement : MonoBehaviour
{

    public float amount = 3f;
    public float maxamount = 8f;
    public float smooth = 3;
    private Quaternion def;

    void Start()
    {
        def = transform.localRotation;
    }

    void Update()
    {

        float factorZ = -(Input.GetAxis("Horizontal"))*amount;

        if (factorZ > maxamount)
            factorZ = maxamount;

        if (factorZ < -maxamount)
            factorZ = -maxamount;

        Quaternion Final = Quaternion.Euler(0, 90, def.z + factorZ);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, Final, (Time.deltaTime*amount)*smooth);
    }

    
}
