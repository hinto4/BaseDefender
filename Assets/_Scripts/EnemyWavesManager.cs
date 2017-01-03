using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class EnemyWavesManager : MonoBehaviour
{
    public AudioClip AlarmSound;
    public Text Timer;
    public Text EnemyCounter;

    private AudioSource _audioSource;
    private readonly List<GameObject> _enemySpawner = new List<GameObject>();
    public List<GameObject> EnemyList = new List<GameObject>();                 // Keep count of the spawned Enemies.
    private float _startTime;                                                   // When the enemy spanwers are enabled.
    private float _spawnTimer;                                                  // How long the enemy spawners are enabled.
    private float _timer;
    private bool _isInvoked;

    enum WaveState
    {
        WaveStarted,
        Warmup,
        PrepareMode,
        FightWave
    }

    WaveState states = WaveState.Warmup;

    void Start ()
	{
	    _startTime = Time.time + 20;
	    _audioSource = GetComponent<AudioSource>();
	    foreach (var spawner in GameObject.FindGameObjectsWithTag("EnemySpawner"))
	    {
            _enemySpawner.Add(spawner);
	        spawner.SetActive(false);
	    }
	}
	
	void Update ()
	{
	    EnemyCounter.text = EnemyList.Count.ToString();

	    if (states == WaveState.Warmup)
	    {
	        _startTime = Time.time + 20;
            states = WaveState.PrepareMode;
        }

	    if (states == WaveState.PrepareMode)
	    {
            _timer = Mathf.Round(_startTime - Time.time);
            if (_timer >= 0)
            {
                Timer.text = _timer.ToString();
            }
	        if (_timer <= 0)
	        {
	            states = WaveState.WaveStarted;
	        }
        }

	    if (states == WaveState.WaveStarted)
	    {
	        EnableSpawners();
	        if (!_isInvoked)
	        {
                Invoke("DisableSpawners", 40f);
	            _isInvoked = true;
	        }
	    }

	    if (states == WaveState.FightWave)
	    {
	        if (EnemyList.Count <= 0)
	        {
	            states = WaveState.Warmup;
	            _isInvoked = false;
	        }
	    }
    }

    void DisableSpawners()
    {
        _audioSource.Stop();
        foreach (var spawner in _enemySpawner)
        {
            spawner.SetActive(false);
            Debug.Log("Enemy spawners Disabled.");
        }
        states = WaveState.FightWave;

    }

    void EnableSpawners()
    {
        if (!_audioSource.isPlaying)
        {
            foreach (var spawner in _enemySpawner)
            {
                spawner.SetActive(true);
                Debug.Log("Enemy spawners Enabled.");
            }
            _audioSource.clip = AlarmSound;
            _audioSource.Play();
        }
    }
}
