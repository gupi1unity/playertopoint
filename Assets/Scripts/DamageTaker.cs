using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTaker : MonoBehaviour
{
    private Health _health;
    private bool _isPlayerInRadius = false;

    public void Initialize(Health health)
    {
        _health = health;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.TryGetComponent<Mine>(out Mine mine))
        {
            if (mine.IsMineExplode == true)
            {
                _isPlayerInRadius = true;

                if (_isPlayerInRadius == true)
                {
                    _health.RemoveHealth(mine.Damage);
                    _isPlayerInRadius = false;
                }
            }
        }
    }
}
