using UnityEngine;

[RequireComponent (typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class BulletController : MonoBehaviour
{
    [SerializeField] float _damage = 10;
    [SerializeField] float _bulletSpeed = 100;
    Rigidbody _rb;

    private void Start()
    {
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
