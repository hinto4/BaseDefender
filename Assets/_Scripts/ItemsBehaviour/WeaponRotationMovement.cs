using UnityEngine;
using System.Collections;

public class WeaponRotationMovement : MonoBehaviour
{
    public float amount = 3f;
    public float maxamount = 6f;
    public float smooth = 10;
    private Quaternion def;
    private bool Paused = false;

    void Start()
    {
        def = transform.localRotation;
    }

    void Update()
    {
        float factorX = (Input.GetAxis("Mouse Y")) * amount;
        float factorY = -(Input.GetAxis("Mouse X")) * amount;
        float factorZ = -Input.GetAxis("Vertical") * amount;
        //float factorZ = 0 * amount;

        if (!Paused)
        {
            if (factorX > maxamount)
                factorX = maxamount;

            if (factorX < -maxamount)
                factorX = -maxamount;

            if (factorY > maxamount)
                factorY = maxamount;

            if (factorY < -maxamount)
                factorY = -maxamount;

            if (factorZ > maxamount)
                factorZ = maxamount;

            if (factorZ < -maxamount)
                factorZ = -maxamount;

            Quaternion Final = Quaternion.Euler(def.x + factorX, def.y + factorY + 90f, def.z + factorZ);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, Final, (Time.deltaTime * smooth));
        }
    }
}
