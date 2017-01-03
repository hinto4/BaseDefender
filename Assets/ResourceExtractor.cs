using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResourceExtractor : MonoBehaviour
{
    public GameObject NotationInformation;
    public GameObject RadiationZone;
    public Slider ResourceSlider;
    public AudioClip AlarmClip;          //todo Make different class for handling the sound effects.
    public float Capacity = 2000f;
    public float ExtractingRate = 20f;
    public int ExtractingRangeMax = 50;
    public int ExtractingRangeMin = 2;

    private GameObject _player;
    private float _collectedResources;
    private AudioSource _audioSource;
    private float _startTime;
    private float _explosionTimer;
    private bool _explosionTimerSet;
    private float _halfTime;

    void Start()
    {
        _startTime = Time.time + 1f;
        _audioSource = GetComponent<AudioSource>();
        ResourceSlider.maxValue = Capacity;
        _collectedResources = 0;
    }
    
    void Update()
    {
        ExtractResources(ExtractingRate, ExtractingRangeMin, ExtractingRangeMax);
        DangerTimer();
    }

    void DangerTimer()                          // If extractor is left full, start danger timer. 
    {
        if (_collectedResources >= Capacity)
        {
            if (!_explosionTimerSet)
            {
                _explosionTimer = Time.time + 20;
                _halfTime = _explosionTimer/2;
                _explosionTimerSet = true;
            }

            if (_explosionTimer - Time.time <= _halfTime)
            {
                Debug.Log("Playing alarm");
                if (!_audioSource.isPlaying)
                {
                    _audioSource.clip = AlarmClip;
                    _audioSource.Play();
                }

                if (_explosionTimer - Time.time <= 0)
                {
                    Explode();
                    _explosionTimerSet = false;
                }
            }
        }
        else
        {
            if (_audioSource.isPlaying)
            {
                _audioSource.Stop();
            }
        }
    }

    void Explode()
    {
        Debug.Log("Explosion");

        Instantiate(RadiationZone, this.transform.position, Quaternion.identity);

        DestroyObject(this.gameObject);
    }

    void ExtractResources(float extractorSpeed, int haulRangeMin, int haulRangeMax)
    {
        if (_startTime - Time.time <= 0)
        {
            if (_collectedResources <= Capacity)
            {
                float resource = Random.Range(haulRangeMin, haulRangeMax);

                if (resource + _collectedResources < Capacity)
                {
                    _collectedResources += resource;
                    UpdateExtractorNotation();
                }
                else
                {
                    var remainder = Capacity - _collectedResources;
                    _collectedResources += remainder % resource;
                    UpdateExtractorNotation();
                }
            }
            else
            {
                UpdateExtractorNotation();
            }
            _startTime = Time.time + Random.Range(2,extractorSpeed);
        }
    }

    void UpdateExtractorNotation()
    {
        NotationInformation.GetComponentInChildren<TextMesh>().text = 
            "Atomic matter " + _collectedResources + "/" + Capacity;

        ResourceSlider.value = _collectedResources;        
    }

    void OnTriggerEnter(Collider col)
    {
        GameObject obj = col.gameObject;

        if (obj.tag == "Player")
        {
            NotationInformation.SetActive(true);
            UpdateExtractorNotation();
            _player = obj;
        }
    }

    void OnTriggerStay(Collider col)
    {
        GameObject obj = col.gameObject;

        if (obj.tag == "Player")
        {
            float distance = Vector3.Distance(obj.transform.position, this.transform.position);
            if (distance < 4f)      // allow interaction with extractor.
            {
                if (Input.GetKeyDown(KeyCode.F))        //todo change for inputManager.
                {
                   obj.GetComponent<PlayerStats>().UpdatePlayerResources(_collectedResources);
                    _collectedResources -= _collectedResources;
                    UpdateExtractorNotation();
                }
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (_player != null)
        {
            NotationInformation.SetActive(false);
        }   
    }
}
