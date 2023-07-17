using UnityEngine;
/// <summary>
/// エネミーがプレイヤーに当たった時、プレイヤーをノックバックさせるコンポーネント
/// </summary>
public class EnemyKnockback : MonoBehaviour
{
    [Tooltip("プレイヤーを吹っ飛ばす力")]
    [SerializeField] float _knockback = 2f;
    private void OnCollisionEnter(Collision collision)
    {
        //ぶつかった対象がプレイヤーのタグを持っていたら
        if (collision.gameObject.CompareTag("Player"))
        {
            //ぶつかったプレイヤーがrigidbodyコンポーネントを持っていたら
            if (collision.gameObject.TryGetComponent(out Rigidbody rb))
            {
                Vector3 velo = (collision.transform.position - transform.position).normalized * _knockback;
                rb.AddForce(velo, ForceMode.Impulse);
            }
        }
    }
}
