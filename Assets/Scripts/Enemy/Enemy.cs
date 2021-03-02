﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _helth;
    [SerializeField] private int _reward;

    [SerializeField] private Player _target;

    public Player Target => _target;

    public event UnityAction Dying;

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
        Destroy(gameObject);
    }
}