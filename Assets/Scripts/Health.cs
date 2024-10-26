using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health
{
    private int _health;

    public int HealthValue { get => _health; }

    public Health(int health)
    {
        _health = health;
    }

    public void AddHealth(int health)
    {
        if (health < 0)
        {
            return;
        }

        _health += health;
    }

    public void RemoveHealth(int health)
    {
        if (health < 0)
        {
            return;
        }

        _health -= health;
    }
}
