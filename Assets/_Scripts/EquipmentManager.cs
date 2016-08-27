using UnityEngine;
using System.Collections;

public class EquipmentManager : MonoBehaviour
{
    public GameObject Weapon;
    public bool HandsModeActive;
    public AudioClip Sounds;
    public GameObject CrossHair;

    private AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        
    }

    void Update()
    {
        SetEquipment();
    }

    void SetEquipment()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Weapon.SetActive(true);
            Weapon.GetComponent<WeaponBehaviour>().DrawWeapon();
            HandsModeActive = false;
            CrossHair.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _audioSource.clip = Sounds;
            _audioSource.Play();

            Weapon.SetActive(false);
            HandsModeActive = true;
            CrossHair.SetActive(true);
        }
    }
}


