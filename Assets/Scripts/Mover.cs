using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover
{
    private NavMeshAgent _agent;

    private Pointer _pointer;

    public Mover(NavMeshAgent agent, Pointer pointer)
    {
        _agent = agent;
        _pointer = pointer;
    }

    public void Move()
    {
        NavMeshPath path = new NavMeshPath();

        if (GetPath(path))
        {
            _agent.SetDestination(_pointer.GetPoint());
        }
    }

    private bool GetPath(NavMeshPath path)
    {
        path.ClearCorners();

        if (_agent.CalculatePath(_pointer.GetPoint(), path) && path.status != NavMeshPathStatus.PathInvalid)
        {
            return true;
        }

        return false;
    }
}
