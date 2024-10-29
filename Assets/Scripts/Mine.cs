using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private float _timeToExplode = 5f;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private int _damage;
    [SerializeField] private float _damageRadius = 5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerController>(out PlayerController enemyController))
        {
            StartCoroutine(ExplodeBomb());
        }
    }

    private IEnumerator ExplodeBomb()
    {
        float time = _timeToExplode;

        while (time > 0)
        {
            time -= Time.deltaTime;
            yield return null;
        }

        Instantiate(_particleSystem, transform.position, Quaternion.identity);

        Collider[] colliders = Physics.OverlapSphere(transform.position, _damageRadius);

        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.TryGetComponent<IDamagable>(out IDamagable damagableObject))
            {
                damagableObject.TakeDamage(_damage);
            }
        }

        Destroy(gameObject);
    }
}
