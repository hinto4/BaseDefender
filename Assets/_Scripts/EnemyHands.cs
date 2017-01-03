using UnityEngine;
using System.Collections;

public class EnemyHands : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        GameObject obj = col.gameObject;

        if (obj.tag == "Player")
        {
            if (!GetComponentInParent<EnemyAI>()._isDead)
            {
                obj.GetComponent<PlayerStats>().DamagePlayer(GetComponentInParent<EnemyAI>().Damage);
                
            }
        }

        if (obj.tag == "ImprovisedFence_1")
        {
            if (!GetComponentInParent<EnemyAI>()._isDead)
            {
                obj.GetComponent<Wall>().DamageWall(GetComponentInParent<EnemyAI>().Damage);
            }
        }
    }
}
