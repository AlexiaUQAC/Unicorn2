using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//This class is the base class for all the IA behaviours. 
// The agent walk in his the navMesh
public class IA_Behaviour : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Animator _animator;
    private float _range = 5f;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }
    
    private void Update()
    {
        if (_agent.remainingDistance <= _agent.stoppingDistance && !_agent.isStopped)
        {
            // Randomly stop the enemy from moving.
            if (Random.Range(0, 100) < 35)
            {
                _agent.isStopped = true;
                _animator.SetBool("isWalking", false);
                Invoke("Resume", Random.Range(1, 3));
            }
            else
            {
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
        _animator.SetBool("isWalking", false);
        Invoke("SetDestinationAndMoveTo", 1.0f);
    }
    
    /// <summary>
    /// Make the enemy move to a random point on the NavMesh.
    /// </summary>
    private void SetDestinationAndMoveTo()
    {
        if (RandomPoint(transform.position, _range, out var point))
        {
            _animator.SetBool("isWalking", true);
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
