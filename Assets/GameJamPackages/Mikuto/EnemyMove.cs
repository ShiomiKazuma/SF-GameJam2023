using UnityEngine;
/// <summary>
/// エネミーの移動に関するコンポーネント
/// </summary>
public class EnemyMove : MonoBehaviour
{
    [Tooltip("エネミーの移動速度パラメータ")]
    [SerializeField] float _moveSpeed = 1f;
    [Tooltip("ターゲット")]
    [SerializeField] GameObject _target;
    [Tooltip("移動の種類")]
    [SerializeField] MoveType _moveType = MoveType.Default;
    Rigidbody _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (_target == null) return;
        //正面をターゲットの方向に向ける
        transform.forward = (_target.transform.position - transform.position).normalized;
        switch (_moveType)
        {
            case MoveType.Default:
                Vector3 velo = (_target.transform.position - transform.position).normalized * _moveSpeed;
                _rb.velocity = new Vector3(velo.x, _rb.velocity.y, velo.z);
                break;
            case MoveType.NoGravity:
                _rb.velocity = (_target.transform.position - transform.position).normalized * _moveSpeed;
                break;
            case MoveType.Ghost:
                float sin = Mathf.Sin(Time.time*2);
                Vector3 velo2 = (_target.transform.position - transform.position).normalized * _moveSpeed;
                _rb.velocity = new Vector3(velo2.x, 2*sin, velo2.z);
                break;
        }
    }
}
enum MoveType
{
    /// <summary>重力がある状態でターゲットに向かって移動させる</summary>
    Default,
    /// <summary>重力を無視した状態でターゲットに向かって移動させる</summary>
    NoGravity,
    Ghost,
}