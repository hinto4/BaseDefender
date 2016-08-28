using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class RagdollController : MonoBehaviour
{
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void DisableRagdoll()
    {
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<EnemyAI>().enabled = false;
        GetComponent<ThirdPersonCharacter>().enabled = false;
        _animator.SetTrigger("Die");

        //foreach (var rb in GetComponentsInChildren<Rigidbody>())
        //{
        //    GetComponent<NavMeshAgent>().enabled = false;
        //    GetComponent<EnemyAI>().enabled = false;
        //    GetComponent<ThirdPersonCharacter>().enabled = false;
        //    rb.isKinematic = false;
        //    _animator.enabled = false;

        //    GetComponent<Rigidbody>().isKinematic = true;
        //    GetComponent<Collider>().isTrigger = true;
        //}
    }

    public void EnableRagdoll()
    {
        foreach (var rb in GetComponentsInChildren<Rigidbody>())
        {
            rb.isKinematic = true;
            _animator.enabled = true;
            GetComponent<NavMeshAgent>().enabled = true;
            GetComponent<EnemyAI>().enabled = true;
            GetComponent<ThirdPersonCharacter>().enabled = true;
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Collider>().isTrigger = false;
        }
    }
}
