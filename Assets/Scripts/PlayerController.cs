using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private int _healthValue;
    [SerializeField] private GameObject _pointPrefab;

    private Mover _mover;
    private Pointer _pointer;
    private PlayerView _playerView;
    private Health _health;
    private DamageTaker _damageTaker;

    private bool _isDead;
    private bool _isAnimationRunning = true;

    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;

        _pointer = new Pointer(_camera, _groundLayer, _pointPrefab);
        _mover = new Mover(_agent, _pointer);
        _playerView = GetComponent<PlayerView>();
        _health = new Health(_healthValue);
        _damageTaker = GetComponent<DamageTaker>();
        _damageTaker.Initialize(_health);
    }

    private void Update()
    {
        _isDead = _health.HealthValue <= 0 ? true : false;

        Debug.Log(_health.HealthValue);

        if (_isDead == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _mover.Move();
            }

            if (_agent.velocity.magnitude > 0.1f)
            {
                _playerView.StartRunning();
            }
            else
            {
                _playerView.StopRunning();
            }

            if (_health.HealthValue <= ((_healthValue * 30) / 100))
            {
                _playerView.ChangeAnimationLayer(2);
            }
        }
        else
        {
            if (_isAnimationRunning)
            {
                _playerView.PlayDeadAnimation();
                _isAnimationRunning = false;
            }
        }
    }
}
