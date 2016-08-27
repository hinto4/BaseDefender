using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour
{
    public float Health = 100f;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy" && !col.gameObject.GetComponentInParent<EnemyAI>()._isDead)
        {
            Hit(col.gameObject);        // TODO make system that calls this method only once in every second Or make it collider based, as arm hit detected then call this.
        }
    }

    void Hit(GameObject enemy)
    {
        Health -= enemy.gameObject.GetComponentInParent<EnemyAI>().Damage;
    }
}
