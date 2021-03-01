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
 
    private void Start()
    {
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
}