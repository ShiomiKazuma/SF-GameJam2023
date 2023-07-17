using System.Collections;
using UnityEngine;

[RequireComponent (typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class BulletController : MonoBehaviour
{
    float _damage;
    float _bulletSpeed;
    Rigidbody _rb;

    private void Start()
    {
        if (GameObject.FindObjectOfType<PlayerMuzzle>().TryGetComponent(out PlayerMuzzle _playerMuzzle))
        {
            _damage = _playerMuzzle._currentBulletPower;
            _bulletSpeed = _playerMuzzle._currentBulletSpeed;
        }
        Debug.Log(_bulletSpeed);
        _rb = GetComponent<Rigidbody>();
        _rb.velocity = Camera.main.transform.TransformDirection(Vector3.forward) * _bulletSpeed;
        Destroy(gameObject, 3);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out E_Health enemyHealth))
        {
            enemyHealth.EnemyDamaged(_damage);
        }
        Destroy(gameObject);
    }
}
