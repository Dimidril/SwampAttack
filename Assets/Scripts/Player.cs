using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _helth;
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Transform _shootPoint;

    private Weapon _currentWeapon;
    private int _currentHelth;
    private Animator _animator;
    
    public int Money { get; private set; }
 
    private void Start()
    {
        _currentHelth = _helth;
        _currentWeapon = _weapons[0];
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _currentWeapon.Shoot(_shootPoint);
        }
    }

    public void ApplyDamage(int damage)
    {
        _currentHelth -= damage;
        if (_currentHelth <= 0)
            Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void OnEnemyDied(int reward)
    {
        Money += reward;
    }
}