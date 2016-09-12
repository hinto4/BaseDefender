using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerStats : MonoBehaviour
{
    public float Health = 100f;
    public Slider HealthBar;
    public GameObject DeathPanel;

    private Vector3 _playerPosition;

    void Start()
    {
        _playerPosition = this.transform.position;
    }

    public void DamagePlayer(float damage)
    {
        Health -= damage;
        HealthBar.value = Health;

        if (Health <= 0)
        {
            DeathPanel.SetActive(true);
            GetComponent<FirstPersonController>().enabled = false;
            GetComponent<FirstPersonController>().SetMouseCursorLock(false);
        }
    }

    public void RespawnPlayer()
    {
        DeathPanel.SetActive(false);
        GetComponent<FirstPersonController>().enabled = true;
        GetComponent<FirstPersonController>().SetMouseCursorLock(true);
        transform.position = _playerPosition;
        Health = 100f;
        HealthBar.value = Health;
    }

    //void OnCollisionEnter(Collision col)
    //{
    //    if (col.gameObject.tag == "Enemy" && !col.gameObject.GetComponentInParent<EnemyAI>()._isDead)
    //    {
    //        Hit(col.gameObject);        // TODO make system that calls this method only once in every second Or make it collider based, as arm hit detected then call this.
    //    }
    //}

    //void Hit(GameObject enemy)
    //{
    //    Health -= enemy.gameObject.GetComponentInParent<EnemyAI>().Damage;
    //}
}
