using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.Characters.ThirdPerson;

public class EnemyAI : AICharacterControl
{
    private Animator _animator;
    private AudioSource _audioSource;
    private FirstPersonController _player;
 
    public bool _isDead;
    public float Health = 100f;
    public float Damage = 20f;
    public AudioClip Sounds;
    public float EnemyDetectArea = 50f;
    public float EnemyStartRunning = 20f;

    enum EnemyState
    {
        Attacking,
        Running,
        Walking,
        Idle
    }

    EnemyState _state = EnemyState.Walking;     // default Idle

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        StartMethod();
        _animator = GetComponent<Animator>();
        _audioSource.clip = Sounds;
        _player = GameObject.FindObjectOfType<FirstPersonController>();
        target = _player.transform;

        GameObject.FindObjectOfType<EnemyWavesManager>().EnemyList.Add(this.gameObject);
    }

    void Update()
    {
        FindTarget();

        if (Health <= 0)
        {
            DisableRagdoll();
            Destroy(this.gameObject, 120f);
            GameObject.FindObjectOfType<EnemyWavesManager>().EnemyList.Remove(this.gameObject);     // remove enemy from the list @ EnemyWaveManager class.
        }
    }

    public override void FindTarget()
    {
        if (target != null)
            agent.SetDestination(target.position);

        agent.stoppingDistance = Vector3.Distance(this.transform.position, target.transform.position);
        if (agent.remainingDistance < EnemyDetectArea)
        {
            agent.stoppingDistance = 3.5f;
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                _state = EnemyState.Attacking;
                EnemyStateController();
            }
            else
            {
                if (agent.remainingDistance > EnemyStartRunning)
                {
                    _state = EnemyState.Walking;
                    EnemyStateController();
                }
                else
                {
                    if (agent.remainingDistance > agent.stoppingDistance)
                    {
                        _state = EnemyState.Running;
                        EnemyStateController();
                    }
                    else
                    {
                        _state = EnemyState.Attacking;
                        EnemyStateController();
                    }
                }
            }
        }
        else
        {
            _state = EnemyState.Walking;       // bug is here, should be idle, current temp fix for walking mode.
            EnemyStateController();
        }
    }

    public void PlayEnemyHit()
    {
        _animator.SetTrigger("Hit");
    }

    

    void EnemyStateController()
    {
        if (_state == EnemyState.Walking)
        {
            _animator.SetBool("IsWalking", true);
            _animator.SetBool("IsRunning", false);
            _animator.SetBool("Attack", false);
            agent.speed = 2f;
            character.Move(agent.desiredVelocity, false, false);
        }
        if (_state == EnemyState.Attacking)
        {
            _animator.SetBool("IsWalking", false);
            _animator.SetBool("IsRunning", false);
            _animator.SetBool("Attack", true);
            character.Move(Vector3.zero, false, false);
        }
        if (_state == EnemyState.Idle)
        {
            _animator.SetBool("IsWalking", false);
            _animator.SetBool("IsRunning", false);
            _animator.SetBool("Attack", false);
            character.Move(Vector3.zero, false, false);
        }
        if (_state == EnemyState.Running)
        {
            agent.speed = 6f;
            _animator.SetBool("IsWalking", false);
            _animator.SetBool("IsRunning", true);
            _animator.SetBool("Attack", false);
            character.Move(agent.desiredVelocity, false, false);
        }
    }

    void DisableRagdoll()
    {
        _animator.SetBool("IsRunning",false);
        GetComponent<ThirdPersonCharacter>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<EnemyAI>().enabled = false;
        GetComponent<Collider>().enabled = false;
        _isDead = true;
        _animator.SetTrigger("Die");
        _animator.enabled = false;
    }
}
