using UnityEngine;
using System.Collections;
using System.Threading;

public class RadiationZone : MonoBehaviour
{
    public float RadiationDamage = 12f;
    public float DamageRate = 2f;

    private float _damageRate;

    void Start()
    {
        _damageRate = Time.time + DamageRate;
    }

    void OnTriggerStay(Collider col)
    {
        GameObject obj = col.gameObject;

        if (obj.tag == "Player")
        {
            if (_damageRate - Time.time <= 0)
            {
                obj.GetComponent<PlayerStats>().DamagePlayer(RadiationDamage);
                _damageRate = Time.time + DamageRate;
            }
            
        }
    }
}
