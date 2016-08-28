using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    private WeaponBehaviour _equiptWeapon;
    private int _randomNumber;

    void Start()
    {
        _equiptWeapon = FindObjectOfType<WeaponBehaviour>();
        _randomNumber = Random.Range(0, 10);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.transform.gameObject.GetComponentInParent<EnemyAI>().Health -= _equiptWeapon.WeaponDamage;
            col.transform.gameObject.GetComponentInParent<EnemyAI>().PlayEnemyHit();
            
            DestroyObject(this.transform.gameObject);
            Debug.Log("Bullet hit: " + col.gameObject);
        }
        if (_randomNumber != 2)
        {
            DestroyObject(this.transform.gameObject);
        }
    }
	
}
