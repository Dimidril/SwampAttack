using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    [SerializeField] private int _bulletCount = 3;
    [SerializeField] private float _spread = 10f;

    public override void Shoot(Transform shootPoint)
    {
        float curentEuler = -_spread / 2;
        float step = _spread / _bulletCount;
        for (int i = 0; i < _bulletCount; i++)
        {
            Instantiate(Bullet, shootPoint.position, Quaternion.Euler(0, 0, curentEuler));
            curentEuler += step;
        }
    }
}