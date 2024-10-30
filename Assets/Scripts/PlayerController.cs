using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour, IDamagable
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private int _healthValue;
    [SerializeField] private GameObject _pointPrefab;
    [SerializeField] private AnimationCurve _jumpCurve;
    [SerializeField] private float _jumpAnimationDuration;

    private Mover _mover;
    private Pointer _pointer;
    private PlayerView _playerView;
    private Health _health;
    private Jumper _jumper;

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
        _jumper = new Jumper(_agent, _jumpCurve, _jumpAnimationDuration, this, _playerView);
    }

    private void Update()
    {
        _isDead = _health.HealthValue <= 0 ? true : false;

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

            _jumper.Jump();
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

    public void TakeDamage(int damage)
    {
        _health.RemoveHealth(damage);
    }
}
