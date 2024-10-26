using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private float _timeToExplode = 5f;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private int _damage;
    private float _time;

    private bool _isRunning = false;

    public bool IsMineExplode { get; private set; } = false;
    public int Damage { get => _damage; }

    private void Awake()
    {
        _time = _timeToExplode;
    }

    private void Update()
    {
        if (IsMineExplode)
        {
            Instantiate(_particleSystem, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (_isRunning == true)
        {
            _time -= Time.deltaTime;
            if (_time < 0)
            {
                IsMineExplode = true;
            }
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerController>(out PlayerController enemyController))
        {
            _isRunning = true;
        }
    }
}
