using System.Collections;
using UnityEngine;

[RequireComponent (typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class BulletController : MonoBehaviour
{
    [SerializeField] PlayerMuzzle _playerMuzzle;
    float _damage;
    float _bulletSpeed;
    Rigidbody _rb;

    private void Start()
    {
        //_damage = _playerMuzzle.;
        //_bulletSpeed = _playerMuzzle.;
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
