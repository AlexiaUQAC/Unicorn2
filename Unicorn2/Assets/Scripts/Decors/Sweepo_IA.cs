using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Sweepo_IA : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private float _range = 3f;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (_agent.remainingDistance <= _agent.stoppingDistance && !_agent.isStopped)
        {
            // Randomly stop the enemy from moving.
            if (Random.Range(0, 100) < 35)
            {
                _agent.isStopped = true;
                Invoke("Resume", Random.Range(1, 3));
            }
            else
            {
                Debug.Log("Search destination");
                SetDestinationAndMoveTo();
            }
        }
    }

    private void Resume()
    {
        _agent.isStopped = false;
    }

    /// <summary>
    /// Stop the enemy from moving.
    /// </summary>
    public void Stop()
    {
        _agent.ResetPath();
        _agent.isStopped = true;
        Invoke("SetDestinationAndMoveTo", 1.0f);
    }

    /// <summary>
    /// Make the enemy move to a random point on the NavMesh.
    /// </summary>
    private void SetDestinationAndMoveTo()
    {
        if (RandomPoint(transform.position, _range, out var point))
        {
            Debug.Log(point);
            _agent.SetDestination(point);
        }
    }

    /// <summary>
    /// Return a random point on the NavMesh in a given range from a given center.
    /// </summary>
    private bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        Vector3 randomPoint = center + Random.insideUnitSphere * range;
        if (NavMesh.SamplePosition(randomPoint, out var hit, 1.0f, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }

}
