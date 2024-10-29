using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Jumper
{
    private NavMeshAgent _agent;

    private Coroutine _jumpCoroutine;

    private AnimationCurve _jumpCurve;

    private float _duration;

    private MonoBehaviour _context;

    public Jumper(NavMeshAgent agent, AnimationCurve jumpCurve, float duration, MonoBehaviour context)
    {
        _agent = agent;
        _jumpCurve = jumpCurve;
        _duration = duration;
        _context = context;
    }

    public void Jump()
    {
        if (_agent.isOnOffMeshLink)
        {
            if (_jumpCoroutine == null)
            {
                _jumpCoroutine = _context.StartCoroutine(JumpCoroutine());
            }
        }
    }

    private IEnumerator JumpCoroutine()
    {
        OffMeshLinkData data = _agent.currentOffMeshLinkData;
        Vector3 startPosition = _agent.transform.position;
        Vector3 endPosition = data.endPos + Vector3.up * _agent.baseOffset;

        float progress = 0;

        while (progress < _duration)
        {
            float yOffset = _jumpCurve.Evaluate(progress/_duration);
            _agent.transform.position = Vector3.Lerp(startPosition, endPosition, progress / _duration) + yOffset * Vector3.up;
            _agent.transform.rotation = Quaternion.LookRotation(endPosition - startPosition);
            progress += Time.deltaTime;
            yield return null;
        }

        _agent.CompleteOffMeshLink();
        _jumpCoroutine = null;
    }
}
