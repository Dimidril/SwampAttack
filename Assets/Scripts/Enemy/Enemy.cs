using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _helth;
    [SerializeField] private int _reward;

    private Player _target;

    public Player Target => _target;
    public int Reward => _reward;

    public event UnityAction<Enemy> Dying;

    public void Init(Player target)
    {
        _target = target;
    }

    public void TakeDamage(int damage)
    {
        _helth -= damage;

        if(_helth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Dying?.Invoke(this);
        Destroy(gameObject);
    }
}