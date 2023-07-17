using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class E_Attack : MonoBehaviour
{
    [SerializeField] private float _enemyAtk = 10f;
    [SerializeField] private string _plyaerTag = null;


    private void OnCollisionEnter(Collision collision)
    {
        //�Ԃ������Ώۂ��v���C���[�̃^�O�������Ă�����
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHp>().PlayerDamage(_enemyAtk);
        }
    }

}
