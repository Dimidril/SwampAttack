using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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

    public event UnityAction<int, int> HelthChanged;
 
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

    public void AddMobey(int money)
    {
        Money += money;
    }

    public void ApplyDamage(int damage)
    {
        _currentHelth -= damage;
        HelthChanged?.Invoke(_currentHelth, _helth);

        if (_currentHelth <= 0)
        {
            Die();
            _currentHelth = 0;
        }
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