using UnityEngine;

public class E_Health : MonoBehaviour
{
    [SerializeField] private float _initHealth;
    [SerializeField] private string _bulletTag;
    
    public float _health;
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();

        _health = _initHealth;
    }

    private void Update()
    {
        if (_health <= 0) DeadAnim();
    }

    public void EnemyDamaged(float damage)
    {
        _health -= damage;
    }

    private void DeadAnim()
    {
        _animator.SetTrigger("IsDead");
    }

    private void EndDeadAnim()
    {
        Destroy(this.gameObject);
    }
}
