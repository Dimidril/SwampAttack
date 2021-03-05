using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    [SerializeField] private float _liveTime = 5f;

    private float _livedTime = 0f;

    private void Update()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime, Space.Self);
        if (_livedTime >= _liveTime)
            Destroy(gameObject);

        _livedTime += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}