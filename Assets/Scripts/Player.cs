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
    private int _currentWeaponNumber = 0;
    private int _currentHelth;
    private Animator _animator;
    
    public int Money { get; private set; }

    public event UnityAction<int, int> HelthChanged;
    public event UnityAction<int> MoneyChanged;
 
    private void Start()
    {
        ChangeWeapon(_weapons[_currentWeaponNumber]);
        _currentHelth = _helth;
        _animator = GetComponent<Animator>();
    }

    public void Shoot()
    {
        _currentWeapon.Shoot(_shootPoint);
    }

    public void AddMobey(int money)
    {
        Money += money;
        MoneyChanged?.Invoke(Money);
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

    public void BuyWeapon(Weapon weapon)
    {
        Money -= weapon.Price;
        _weapons.Add(weapon);
        MoneyChanged?.Invoke(Money);
    }

    public void NextWeapon()
    {
        if (_currentWeaponNumber == _weapons.Count - 1)
            _currentWeaponNumber = 0;
        else
            _currentWeaponNumber++;

        ChangeWeapon(_weapons[_currentWeaponNumber]);
    }

    public void PreviusWeapon()
    {
        if (_currentWeaponNumber == 0)
            _currentWeaponNumber = _weapons.Count - 1;
        else
            _currentWeaponNumber--;

        ChangeWeapon(_weapons[_currentWeaponNumber]);
    }

    private void ChangeWeapon(Weapon weapon)
    {
        _currentWeapon = weapon;
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