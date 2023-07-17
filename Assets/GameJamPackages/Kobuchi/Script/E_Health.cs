using UnityEngine;

public class E_Health : MonoBehaviour
{
    [SerializeField] private float _initHealth;
    [SerializeField] private string _bulletTag;
    
    private float _health;

    // Start is called before the first frame update
    void Start()
    {
        _health = _initHealth;
    }

    public void EnemyDamaged(float damage)
    {
        _health -= damage;
        if (_health <= 0) Destroy();
    }

    private void Destroy()
    {
        Destroy(this.gameObject);
    }
}
