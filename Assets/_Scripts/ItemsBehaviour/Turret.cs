using UnityEngine;
using System.Collections;
using JetBrains.Annotations;

public class Turret : WeaponType
{
    public GameObject BarrelPrefab;
    public GameObject BulletPrefab;
    public GameObject MuzzleEffectPrefab;
    public GameObject RotatorPrefab;
    public float FireRate;
    public AudioClip ShotSound;

    private AudioSource _audioSource;
    public GameObject _target;
    private float _nextShot;
    private float _shotDelay = 1f;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = ShotSound;
        _nextShot = Time.time + _shotDelay;
    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(BarrelPrefab.transform.position, BarrelPrefab.transform.forward);

        if (Physics.Raycast(ray, out hit, 200f))
        {
            if (hit.collider.gameObject.tag == "Enemy" && _target == null)
            {
                if (hit.transform.GetComponentInParent<EnemyAI>() != null)
                {
                    _target = hit.transform.GetComponentInParent<EnemyAI>().gameObject;
                }
                if (hit.transform.GetComponent<EnemyAI>() != null)
                {
                    _target = hit.transform.GetComponent<EnemyAI>().gameObject;
                }
            }
        }

        if (_target != null)
        {
            if (_target.GetComponentInParent<EnemyAI>()._isDead || _target.GetComponent<EnemyAI>()._isDead)
            {
                _target = new GameObject();
                DestroyObject(_target, 0.1f);
                GetComponent<Animator>().enabled = true;
                GetComponent<Animator>().SetBool("Scanning", true);
            }
            else
            {
                Debug.Log("Calling shoot()");
                Shoot();
            }

        }
    }

    void Shoot()
    {
        this.GetComponent<Animator>().enabled = false;
        Vector3 targetPosition = new Vector3(_target.transform.position.x, this.transform.position.y, _target.transform.position.z);
        this.transform.LookAt(targetPosition);

        if (_nextShot <= Time.time)
        {
            if (MuzzleEffectPrefab != null)
                Instantiate(MuzzleEffectPrefab, BarrelPrefab.transform.position, Quaternion.identity);

            GameObject bullet = Instantiate(BulletPrefab, BarrelPrefab.transform.position,
                BarrelPrefab.transform.rotation) as GameObject;

            if (bullet != null)
                bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 2800f);
            _audioSource.Play();
            _nextShot = Time.time + _shotDelay;
        }
    }

    public override void SpawnItem(Animator animator)
    {
        animator.SetTrigger("Spawn");
    }
}
