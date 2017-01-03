using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour
{
    public GameObject Enemy;
    public float _totalTime = 5f;

    private float _startTime;
    private GameObject SpawnedEnemy;

    void Start()
    {
        _startTime = Time.time + Random.Range(5,_totalTime);
    }

    private float test;
    void Update()
    {
        if (_startTime - Time.time <= 0)
        {
            SpawnedEnemy = Instantiate(Enemy, transform.position, Quaternion.identity) as GameObject;

            if (SpawnedEnemy != null)
            {
                _startTime = Time.time + Random.Range(1,_totalTime);
                SpawnedEnemy.transform.position = this.transform.position;
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 1);
    }
}
