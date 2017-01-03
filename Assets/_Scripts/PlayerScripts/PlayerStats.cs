using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerStats : MonoBehaviour
{
    public float Health = 100f;
    public Slider HealthBar;
    public GameObject DeathPanel;
    public Text ResourceIndicatorPanelUi;
    public AudioClip[] HurtSounds;
    public bool IsDead;

    public float Resources;

    private Vector3 _playerPosition;
    private AudioSource _audioSource;
    private GameObject _playerWeapon;

    void Start()
    {
        _playerPosition = this.transform.position;
        _audioSource = GetComponent<AudioSource>();
        _playerWeapon = GameObject.FindGameObjectWithTag("Weapon");
    }

    public void DamagePlayer(float damage)      // Enemy hands calling this atm, if enemy hands collides with player.
    {
        Health -= damage;

        _audioSource.clip = HurtSounds[Random.Range(0, HurtSounds.Length)];
        _audioSource.Play();

        HealthBar.value = Health;

        if (Health <= 0 && !IsDead)
        {
            _audioSource.Stop();
            DeathPanel.SetActive(true);
            GetComponent<FirstPersonController>().enabled = false;
            GetComponent<FirstPersonController>().SetMouseCursorLock(false);

            if (_playerWeapon != null)
            {
                _playerWeapon.SetActive(false);
            }
            IsDead = true;
        }
    }
            
    public void RespawnPlayer()
    {
        IsDead = false;
        DeathPanel.SetActive(false);
        GetComponent<FirstPersonController>().enabled = true;
        GetComponent<FirstPersonController>().SetMouseCursorLock(true);
        _playerWeapon.SetActive(true);
        transform.position = _playerPosition;
        Health = 100f;
        HealthBar.value = Health;
    }

    public void UpdatePlayerResources(float value)
    {
        Resources += value;
        ResourceIndicatorPanelUi.text = Resources.ToString();
    }
}
