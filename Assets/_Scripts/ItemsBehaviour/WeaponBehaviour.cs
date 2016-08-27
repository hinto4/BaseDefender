using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponBehaviour : MonoBehaviour
{
    public float FieldOfView = 50f; // Default 60f
    public float WeaponDamage = 45;
    public AudioClip[] Sounds;
    public ParticleSystem MuzzleEffect;
    public GameObject Barrel;
    public GameObject Bullet;
    public GameObject BulletHit;
    
    private GameObject _weapon;
    private Vector3 _startWeaponPostion;
    private Vector3 _ironSightPosition;
    private float _startTime;
    private float _journeyLengthToIronSight;
    private Camera _mainCamera;
    private FirstPersonController _firstPersonController;
    private AudioSource _audioSource;

    private string _drawanim = "draw";
    private string _fireLeftAnim = "fire";
    private string _reloadAnim = "reload";
    private bool _drawWeapon;
    private bool _reloading;

    private float _firstShot;

    void Start()
    {
        _mainCamera = FindObjectOfType<Camera>();
        _startWeaponPostion = this.transform.localPosition;
        _ironSightPosition = new Vector3(-0.123f, -0.005f, 0.209f);
        _startTime = Time.deltaTime;
        _journeyLengthToIronSight = Vector3.Distance(_startWeaponPostion, _ironSightPosition);
        _firstPersonController = GameObject.FindObjectOfType<FirstPersonController>();
        _audioSource = GetComponent<AudioSource>();
        DrawWeapon();
    }

    void Update()
    {
        IronSight();
        UserInput();
    }

    ////TODO Improve IronSight system. Currently broken. Refactor smooth movement, fix mouseUp.
    private void IronSight()
    {
        if (Input.GetButton("Fire2"))
        {
            float distanceCovered = (Time.time - _startTime) * 1.2f;
            float fracJourney = distanceCovered / _journeyLengthToIronSight;
            transform.localPosition = Vector3.Lerp(_startWeaponPostion, _ironSightPosition, fracJourney);

            _mainCamera.fieldOfView = FieldOfView - 30f;
            _firstPersonController.SetMouseLookSensitivity(0.2f, 0.2f);
            
        }
        else if (Input.GetButtonUp("Fire2"))
        {
            float distanceCovered = (Time.time - _startTime) * 1.2f;
            float fracJourney = distanceCovered / _journeyLengthToIronSight;

            transform.localPosition = Vector3.Lerp(_ironSightPosition, _startWeaponPostion, fracJourney);
            Debug.Log("Fire2 released");

            _mainCamera.fieldOfView = FieldOfView;
            _firstPersonController.SetMouseLookSensitivity(1, 1);
        }
    }

    private void UserInput()
    {
        if (Input.GetKeyDown(KeyCode.R) && _reloading == false && _drawWeapon == false)
        {
            Reloading();
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && _reloading == false && _drawWeapon == false)
        {
            Fire();
        }
    }

    void SetAnimationState()
    {
        _drawWeapon = false;
        _reloading = false;
    }

    public void DrawWeapon()
    {
        this.GetComponent<Animation>().Play(_drawanim);
        _drawWeapon = true;
        Invoke("SetAnimationState", 0.6f);
        _audioSource.clip = Sounds[2];
        _audioSource.Play();
    }

    void Reloading()
    {
        this.GetComponent<Animation>().Play(_reloadAnim);
        _reloading = true;
        Invoke("SetAnimationState", 2.0f);
        _audioSource.clip = Sounds[1];
        _audioSource.Play();
    }

    void Fire()
    {
        this.GetComponent<Animation>().CrossFadeQueued(_fireLeftAnim, 0.08f, QueueMode.PlayNow);
        _audioSource.clip = Sounds[0];
        _audioSource.Play();

        if(MuzzleEffect != null)
            Instantiate(MuzzleEffect, Barrel.transform.position, Quaternion.identity);

        GameObject bullet = Instantiate(Bullet, Barrel.transform.position, Barrel.transform.rotation) as GameObject;

        if (bullet != null)
            bullet.GetComponent<Rigidbody>().AddForce(-transform.right * 2800f);

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 2000))
        {
            if (hit.collider != null && BulletHit != null)
            {
                if (hit.collider.gameObject.tag == "Enemy")
                {
                    //hit.transform.gameObject.GetComponentInParent<EnemyAI>().Health -= WeaponDamage;
                    //hit.transform.gameObject.GetComponentInParent<EnemyAI>().PlayEnemyHit();
                }
                else
                {
                    Instantiate(BulletHit, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
                }
                Debug.Log("HIT " + hit.collider.transform.gameObject.name);
                //hit.transform.gameObject.GetComponent<RagdollController>().DisableRagdoll();
            }
        }
    }
}
